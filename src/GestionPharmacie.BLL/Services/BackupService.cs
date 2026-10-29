using Dapper;
using GestionPharmacie.BLL.Security;
using GestionPharmacie.DAL.Connection;
using Microsoft.Data.Sqlite;

namespace GestionPharmacie.BLL.Services;

public interface IBackupService
{
    string DefaultBackupFolder { get; }
    Task<string> CreateBackupAsync(string? destinationFolder = null);
    Task<bool> RestoreBackupAsync(string backupFilePath);
    IEnumerable<FileInfo> GetExistingBackups();
}

public class BackupService : IBackupService
{
    private readonly IDbConnectionFactory _connectionFactory;
    private readonly IAuditLogService _auditLogService;

    public string DefaultBackupFolder { get; }

    public BackupService(IDbConnectionFactory connectionFactory, IAuditLogService auditLogService)
    {
        _connectionFactory = connectionFactory;
        _auditLogService = auditLogService;

        var appData = Path.GetDirectoryName(_connectionFactory.DatabasePath) 
                      ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GestionPharmacie");
        DefaultBackupFolder = Path.Combine(appData, "Backups");
        Directory.CreateDirectory(DefaultBackupFolder);
    }

    /// <summary>
    /// Crée une sauvegarde consistante à chaud via la commande SQLite 'VACUUM INTO'.
    /// </summary>
    public async Task<string> CreateBackupAsync(string? destinationFolder = null)
    {
        var targetDir = string.IsNullOrWhiteSpace(destinationFolder) ? DefaultBackupFolder : destinationFolder;
        Directory.CreateDirectory(targetDir);

        var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        var backupFileName = $"pharmacie_backup_{timestamp}.db";
        var backupFilePath = Path.Combine(targetDir, backupFileName);

        using (var connection = _connectionFactory.CreateConnection())
        {
            // VACUUM INTO requiert des chemins avec des slashes normaux dans SQLite
            var sanitizedPath = backupFilePath.Replace("\\", "/");
            var vacuumSql = $"VACUUM INTO '{sanitizedPath}';";
            await connection.ExecuteAsync(vacuumSql);
        }

        await _auditLogService.LogCurrentSessionActionAsync(
            "BACKUP_CREATED",
            $"Sauvegarde de la base de données créée avec succès : {backupFileName}"
        );

        return backupFilePath;
    }

    /// <summary>
    /// Restaure une sauvegarde SQLite. Réservé exclusivement à l'Administrateur.
    /// </summary>
    public async Task<bool> RestoreBackupAsync(string backupFilePath)
    {
        // Contrôle de sécurité strict RBAC
        if (!UserSession.Instance.IsAdmin)
        {
            throw new UnauthorizedAccessException("La restauration de base de données est exclusivement réservée à l'administrateur.");
        }

        if (!File.Exists(backupFilePath))
        {
            throw new FileNotFoundException("Le fichier de sauvegarde spécifié est introuvable.", backupFilePath);
        }

        var currentDbPath = _connectionFactory.DatabasePath;

        // 1. Libérer toutes les connexions actives dans le pool SQLite
        SqliteConnection.ClearAllPools();
        GC.Collect();
        GC.WaitForPendingFinalizers();

        // 2. Créer une sauvegarde de sécurité préalable avant remplacement
        var safetyBackup = currentDbPath + $".pre_restore_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
        if (File.Exists(currentDbPath))
        {
            File.Copy(currentDbPath, safetyBackup, overwrite: true);
        }

        // 3. Remplacer la base de données actuelle
        try
        {
            File.Copy(backupFilePath, currentDbPath, overwrite: true);

            // Supprimer les fichiers résiduels WAL et SHM pour garantir la consistance immédiate
            var walFile = currentDbPath + "-wal";
            var shmFile = currentDbPath + "-shm";
            if (File.Exists(walFile)) { try { File.Delete(walFile); } catch { } }
            if (File.Exists(shmFile)) { try { File.Delete(shmFile); } catch { } }

            // 4. Trace d'audit dans la nouvelle base
            await _auditLogService.LogCurrentSessionActionAsync(
                "DATABASE_RESTORED",
                $"Base de données restaurée depuis : {Path.GetFileName(backupFilePath)}"
            );

            return true;
        }
        catch (Exception ex)
        {
            // En cas d'échec de copie, tenter de restaurer la copie de sécurité
            if (File.Exists(safetyBackup))
            {
                try { File.Copy(safetyBackup, currentDbPath, overwrite: true); } catch { }
            }
            throw new InvalidOperationException($"Échec de la restauration SQLite : {ex.Message}", ex);
        }
    }

    public IEnumerable<FileInfo> GetExistingBackups()
    {
        if (!Directory.Exists(DefaultBackupFolder))
            return Enumerable.Empty<FileInfo>();

        var dir = new DirectoryInfo(DefaultBackupFolder);
        return dir.GetFiles("pharmacie_backup_*.db").OrderByDescending(f => f.CreationTime);
    }
}
