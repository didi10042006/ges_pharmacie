using Dapper;
using GestionPharmacie.DAL.Connection;

namespace GestionPharmacie.DAL.Repositories;

public class AppSettingRepository : IAppSettingRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public AppSettingRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<string?> GetValueAsync(string key)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "SELECT Value FROM AppSettings WHERE Key = @Key;";
        return await connection.QuerySingleOrDefaultAsync<string>(sql, new { Key = key });
    }

    public async Task<Dictionary<string, string>> GetAllSettingsAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "SELECT Key, Value FROM AppSettings;";
        var pairs = await connection.QueryAsync<(string Key, string Value)>(sql);
        return pairs.ToDictionary(p => p.Key, p => p.Value);
    }

    public async Task SetValueAsync(string key, string value)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = @"
            INSERT INTO AppSettings (Key, Value) VALUES (@Key, @Value)
            ON CONFLICT(Key) DO UPDATE SET Value = excluded.Value;
        ";
        await connection.ExecuteAsync(sql, new { Key = key, Value = value });
    }
}
