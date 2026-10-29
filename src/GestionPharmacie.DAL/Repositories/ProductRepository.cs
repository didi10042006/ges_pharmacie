using Dapper;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.Models.DTOs;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.DAL.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public ProductRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "SELECT * FROM Products WHERE Id = @Id;";
        return await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
    }

    public async Task<Product?> GetByReferenceAsync(string reference)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "SELECT * FROM Products WHERE Reference = @Reference COLLATE NOCASE;";
        return await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Reference = reference });
    }

    public async Task<IEnumerable<ProductListItemDto>> GetProductsListAsync(
        string? searchTerm = null, 
        string? category = null, 
        bool includeArchived = false)
    {
        using var connection = _connectionFactory.CreateConnection();

        var searchPattern = string.IsNullOrWhiteSpace(searchTerm) ? null : $"%{searchTerm.Trim()}%";
        var filterCategory = string.IsNullOrWhiteSpace(category) || category == "Toutes" ? null : category;

        const string sql = @"
            SELECT 
                p.Id, 
                p.Reference, 
                p.Name, 
                p.Category, 
                p.Dosage, 
                p.Form, 
                p.SellingPrice, 
                p.MinStockThreshold, 
                p.IsArchived,
                COALESCE(SUM(CASE WHEN l.IsBlocked = 0 AND date(l.ExpiryDate) >= date('now') THEN l.Quantity ELSE 0 END), 0) AS CurrentStock
            FROM Products p
            LEFT JOIN StockLots l ON p.Id = l.ProductId
            WHERE (@IncludeArchived = 1 OR p.IsArchived = 0)
              AND (@SearchPattern IS NULL OR p.Name LIKE @SearchPattern OR p.Reference LIKE @SearchPattern)
              AND (@Category IS NULL OR p.Category = @Category)
            GROUP BY p.Id
            ORDER BY p.Name ASC;
        ";

        return await connection.QueryAsync<ProductListItemDto>(sql, new
        {
            IncludeArchived = includeArchived ? 1 : 0,
            SearchPattern = searchPattern,
            Category = filterCategory
        });
    }

    public async Task<IEnumerable<string>> GetCategoriesAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = @"
            SELECT DISTINCT Category 
            FROM Products 
            WHERE Category IS NOT NULL AND TRIM(Category) != ''
            ORDER BY Category ASC;
        ";
        return await connection.QueryAsync<string>(sql);
    }

    public async Task<int> CreateAsync(Product product)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = @"
            INSERT INTO Products (Reference, Name, Category, Dosage, Form, SellingPrice, MinStockThreshold, IsArchived)
            VALUES (@Reference, @Name, @Category, @Dosage, @Form, @SellingPrice, @MinStockThreshold, @IsArchived);
            SELECT last_insert_rowid();
        ";
        return await connection.ExecuteScalarAsync<int>(sql, product);
    }

    public async Task<bool> UpdateAsync(Product product)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = @"
            UPDATE Products
            SET Reference = @Reference,
                Name = @Name,
                Category = @Category,
                Dosage = @Dosage,
                Form = @Form,
                SellingPrice = @SellingPrice,
                MinStockThreshold = @MinStockThreshold,
                IsArchived = @IsArchived
            WHERE Id = @Id;
        ";
        var rows = await connection.ExecuteAsync(sql, product);
        return rows > 0;
    }

    public async Task<bool> SetArchiveStatusAsync(int id, bool isArchived)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "UPDATE Products SET IsArchived = @IsArchived WHERE Id = @Id;";
        var rows = await connection.ExecuteAsync(sql, new { Id = id, IsArchived = isArchived ? 1 : 0 });
        return rows > 0;
    }

    public async Task<bool> HasTransactionsHistoryAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = @"
            SELECT 
                (SELECT COUNT(1) FROM StockLots WHERE ProductId = @Id) +
                (SELECT COUNT(1) FROM StockAdjustments WHERE ProductId = @Id);
        ";
        var count = await connection.ExecuteScalarAsync<int>(sql, new { Id = id });
        return count > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "DELETE FROM Products WHERE Id = @Id;";
        var rows = await connection.ExecuteAsync(sql, new { Id = id });
        return rows > 0;
    }
}
