using System.Data;
using System.Reflection;
using BCrypt.Net;
using Dapper;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.Models.Entities;
using GestionPharmacie.Models.Enums;

namespace GestionPharmacie.DAL.Initialization;

public class DatabaseInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DatabaseInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
    }

    /// <summary>
    /// Initializes SQLite database schema, seeds default admin user and initial settings if not present.
    /// </summary>
    public void Initialize()
    {
        var dbDirectory = Path.GetDirectoryName(_connectionFactory.DatabasePath);
        if (!string.IsNullOrWhiteSpace(dbDirectory) && !Directory.Exists(dbDirectory))
        {
            Directory.CreateDirectory(dbDirectory);
        }

        using var connection = _connectionFactory.CreateConnection();

        // 1. Execute SQL Initialization Script
        var script = LoadInitializationScript();
        connection.Execute(script);

        // 2. Seed Default Users (Admin + Vendeur) if missing
        SeedDefaultUsers(connection);

        // 3. Seed Default Application Settings
        SeedInitialSettings(connection);

        // 4. Seed Initial Demonstration Data (Suppliers & Products)
        SeedInitialDemoData(connection);
    }

    private string LoadInitializationScript()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "GestionPharmacie.DAL.Scripts.InitDatabase.sql";

        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null)
        {
            throw new FileNotFoundException($"Embedded resource '{resourceName}' not found in assembly.");
        }

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    private void SeedDefaultUsers(IDbConnection connection)
    {
        var adminCount = connection.ExecuteScalar<int>("SELECT COUNT(1) FROM Users WHERE Username = 'admin';");
        if (adminCount == 0)
        {
            var adminPasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123", workFactor: 11);
            const string insertAdminSql = @"
                INSERT INTO Users (Username, PasswordHash, Role, IsActive)
                VALUES (@Username, @PasswordHash, @Role, @IsActive);
            ";

            connection.Execute(insertAdminSql, new
            {
                Username = "admin",
                PasswordHash = adminPasswordHash,
                Role = UserRole.Admin.ToString(),
                IsActive = 1
            });

            // Log initialization in AuditLogs
            const string insertLogSql = @"
                INSERT INTO AuditLogs (UserId, Action, Details, Timestamp)
                VALUES (1, 'SYSTEM_INIT', 'Base de données initialisée avec le compte administrateur par défaut.', @Timestamp);
            ";

            connection.Execute(insertLogSql, new
            {
                Timestamp = DateTime.UtcNow.ToString("o")
            });
        }

        var vendeurCount = connection.ExecuteScalar<int>("SELECT COUNT(1) FROM Users WHERE Username = 'vendeur';");
        if (vendeurCount == 0)
        {
            var vendeurPasswordHash = BCrypt.Net.BCrypt.HashPassword("vendeur123", workFactor: 11);
            const string insertVendeurSql = @"
                INSERT INTO Users (Username, PasswordHash, Role, IsActive)
                VALUES (@Username, @PasswordHash, @Role, @IsActive);
            ";

            connection.Execute(insertVendeurSql, new
            {
                Username = "vendeur",
                PasswordHash = vendeurPasswordHash,
                Role = UserRole.Vendeur.ToString(),
                IsActive = 1
            });
        }
    }

    private void SeedInitialSettings(IDbConnection connection)
    {
        var defaultSettings = new Dictionary<string, string>
        {
            { "Pharmacy_Name", "Pharmacie Centrale" },
            { "Pharmacy_Address", "123 Avenue de la Santé, Paris" },
            { "Pharmacy_Phone", "+33 1 23 45 67 89" },
            { "Pharmacy_TaxRate", "0.20" },
            { "Currency_Symbol", "€" },
            { "LowStock_AlertThresholdDefault", "5" },
            { "Expiry_AlertDaysDefault", "90" },
            { "Db_Version", "1.0.0" }
        };

        const string checkSql = "SELECT COUNT(1) FROM AppSettings WHERE Key = @Key;";
        const string insertSql = "INSERT INTO AppSettings (Key, Value) VALUES (@Key, @Value);";

        foreach (var (key, value) in defaultSettings)
        {
            var exists = connection.ExecuteScalar<int>(checkSql, new { Key = key }) > 0;
            if (!exists)
            {
                connection.Execute(insertSql, new { Key = key, Value = value });
            }
        }
    }

    private void SeedInitialDemoData(IDbConnection connection)
    {
        // 1. Fournisseurs
        var suppliersCount = connection.ExecuteScalar<int>("SELECT COUNT(1) FROM Suppliers;");
        if (suppliersCount == 0)
        {
            const string insertSupSql = @"
                INSERT INTO Suppliers (Name, Phone, Email, Address, IsArchived)
                VALUES (@Name, @Phone, @Email, @Address, 0);
            ";

            connection.Execute(insertSupSql, new[]
            {
                new { Name = "Sanofi Distribution", Phone = "01 40 00 00 00", Email = "contact@sanofi.fr", Address = "Paris, France" },
                new { Name = "Biogaran Génériques", Phone = "01 55 00 00 00", Email = "contact@biogaran.fr", Address = "Colombes, France" },
                new { Name = "Grossiste Répartiteur OCP", Phone = "01 49 00 00 00", Email = "contact@ocp.fr", Address = "Saint-Ouen, France" }
            });
        }

        // 2. Produits initiaux
        var productsCount = connection.ExecuteScalar<int>("SELECT COUNT(1) FROM Products;");
        if (productsCount == 0)
        {
            const string insertProdSql = @"
                INSERT INTO Products (Reference, Name, Category, Dosage, Form, SellingPrice, MinStockThreshold, IsArchived)
                VALUES (@Reference, @Name, @Category, @Dosage, @Form, @SellingPrice, @MinStockThreshold, 0);
            ";

            connection.Execute(insertProdSql, new[]
            {
                new { Reference = "DOL-1000", Name = "Doliprane", Category = "Analgésique", Dosage = "1000mg", Form = "Comprimé", SellingPrice = 2.18m, MinStockThreshold = 10 },
                new { Reference = "AMO-500", Name = "Amoxicilline Biogaran", Category = "Antibiotique", Dosage = "500mg", Form = "Gélule", SellingPrice = 3.50m, MinStockThreshold = 8 },
                new { Reference = "ADV-400", Name = "Advil", Category = "Anti-inflammatoire", Dosage = "400mg", Form = "Comprimé", SellingPrice = 4.20m, MinStockThreshold = 5 },
                new { Reference = "SPA-80", Name = "Spasfon", Category = "Antispasmodique", Dosage = "80mg", Form = "Comprimé", SellingPrice = 3.12m, MinStockThreshold = 6 }
            });
        }
    }
}
