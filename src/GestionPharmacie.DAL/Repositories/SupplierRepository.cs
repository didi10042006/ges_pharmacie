using Dapper;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.DAL.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public SupplierRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<Supplier?> GetByIdAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "SELECT * FROM Suppliers WHERE Id = @Id;";
        return await connection.QuerySingleOrDefaultAsync<Supplier>(sql, new { Id = id });
    }

    public async Task<IEnumerable<Supplier>> GetAllActiveAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "SELECT * FROM Suppliers WHERE IsArchived = 0 ORDER BY Name ASC;";
        return await connection.QueryAsync<Supplier>(sql);
    }

    public async Task<IEnumerable<Supplier>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "SELECT * FROM Suppliers ORDER BY Name ASC;";
        return await connection.QueryAsync<Supplier>(sql);
    }

    public async Task<int> CreateAsync(Supplier supplier)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = @"
            INSERT INTO Suppliers (Name, Phone, Email, Address, IsArchived)
            VALUES (@Name, @Phone, @Email, @Address, @IsArchived);
            SELECT last_insert_rowid();
        ";
        return await connection.ExecuteScalarAsync<int>(sql, supplier);
    }
}
