using Dapper;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public UserRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "SELECT * FROM Users WHERE Id = @Id;";
        return await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "SELECT * FROM Users WHERE Username = @Username;";
        return await connection.QuerySingleOrDefaultAsync<User>(sql, new { Username = username });
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "SELECT * FROM Users ORDER BY Username ASC;";
        return await connection.QueryAsync<User>(sql);
    }

    public async Task<int> CreateAsync(User user)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = @"
            INSERT INTO Users (Username, PasswordHash, Role, IsActive)
            VALUES (@Username, @PasswordHash, @Role, @IsActive);
            SELECT last_insert_rowid();
        ";
        return await connection.ExecuteScalarAsync<int>(sql, user);
    }

    public async Task<bool> UpdateAsync(User user)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = @"
            UPDATE Users
            SET Username = @Username,
                Role = @Role,
                IsActive = @IsActive
            WHERE Id = @Id;
        ";
        var rows = await connection.ExecuteAsync(sql, user);
        return rows > 0;
    }

    public async Task<bool> UpdatePasswordAsync(int userId, string newPasswordHash)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "UPDATE Users SET PasswordHash = @PasswordHash WHERE Id = @Id;";
        var rows = await connection.ExecuteAsync(sql, new { Id = userId, PasswordHash = newPasswordHash });
        return rows > 0;
    }

    public async Task<bool> SetActiveStatusAsync(int userId, bool isActive)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "UPDATE Users SET IsActive = @IsActive WHERE Id = @Id;";
        var rows = await connection.ExecuteAsync(sql, new { Id = userId, IsActive = isActive ? 1 : 0 });
        return rows > 0;
    }
}
