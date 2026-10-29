using Dapper;
using GestionPharmacie.DAL.Connection;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.DAL.Repositories;

public class AuditLogRepository : IAuditLogRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public AuditLogRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<int> AddAsync(AuditLog log)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = @"
            INSERT INTO AuditLogs (UserId, Action, Details, Timestamp)
            VALUES (@UserId, @Action, @Details, @Timestamp);
            SELECT last_insert_rowid();
        ";
        return await connection.ExecuteScalarAsync<int>(sql, new
        {
            log.UserId,
            log.Action,
            log.Details,
            Timestamp = log.Timestamp.ToString("o")
        });
    }

    public void Add(AuditLog log)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = @"
            INSERT INTO AuditLogs (UserId, Action, Details, Timestamp)
            VALUES (@UserId, @Action, @Details, @Timestamp);
        ";
        connection.Execute(sql, new
        {
            log.UserId,
            log.Action,
            log.Details,
            Timestamp = log.Timestamp.ToString("o")
        });
    }

    public async Task<IEnumerable<AuditLog>> GetRecentLogsAsync(int count = 100)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = @"
            SELECT a.Id, a.UserId, a.Action, a.Details, a.Timestamp,
                   u.Id, u.Username, u.Role, u.IsActive
            FROM AuditLogs a
            LEFT JOIN Users u ON a.UserId = u.Id
            ORDER BY a.Id DESC
            LIMIT @Count;
        ";

        return await connection.QueryAsync<AuditLog, User, AuditLog>(
            sql,
            (log, user) =>
            {
                log.User = user;
                return log;
            },
            new { Count = count },
            splitOn: "Id"
        );
    }

    public async Task<IEnumerable<AuditLog>> GetLogsByUserAsync(int userId, int count = 100)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = @"
            SELECT * FROM AuditLogs
            WHERE UserId = @UserId
            ORDER BY Id DESC
            LIMIT @Count;
        ";
        return await connection.QueryAsync<AuditLog>(sql, new { UserId = userId, Count = count });
    }
}
