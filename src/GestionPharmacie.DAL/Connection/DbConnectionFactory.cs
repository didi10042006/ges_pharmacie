using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

namespace GestionPharmacie.DAL.Connection;

public class DbConnectionFactory : IDbConnectionFactory
{
    static DbConnectionFactory()
    {
        // Enregistre les convertisseurs de types robustes pour SQLite / Dapper
        SqlMapper.AddTypeHandler(new DecimalHandler());
    }

    public string DatabasePath { get; }
    public string ConnectionString { get; }

    public DbConnectionFactory(string? dbPath = null)
    {
        if (string.IsNullOrWhiteSpace(dbPath))
        {
            var appDataDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "GestionPharmacie"
            );
            Directory.CreateDirectory(appDataDir);
            DatabasePath = Path.Combine(appDataDir, "pharmacie.db");
        }
        else
        {
            DatabasePath = dbPath;
            var directory = Path.GetDirectoryName(DatabasePath);
            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        var builder = new SqliteConnectionStringBuilder
        {
            DataSource = DatabasePath,
            Mode = SqliteOpenMode.ReadWriteCreate,
            Cache = SqliteCacheMode.Default,
            DefaultTimeout = 5 // Busy timeout 5s in connection string
        };

        ConnectionString = builder.ToString();
    }

    /// <summary>
    /// Creates and returns an initialized SQLite connection with WAL mode, foreign keys, and busy timeout configured.
    /// </summary>
    public IDbConnection CreateConnection()
    {
        var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        using (var cmd = connection.CreateCommand())
        {
            // Crucial pragmas for reliability and multi-operation safety
            cmd.CommandText = @"
                PRAGMA foreign_keys = ON;
                PRAGMA journal_mode = WAL;
                PRAGMA busy_timeout = 5000;
                PRAGMA synchronous = NORMAL;
            ";
            cmd.ExecuteNonQuery();
        }

        return connection;
    }
}

public class DecimalHandler : SqlMapper.TypeHandler<decimal>
{
    public override void SetValue(IDbDataParameter parameter, decimal value) => parameter.Value = value;
    public override decimal Parse(object value) => Convert.ToDecimal(value);
}
