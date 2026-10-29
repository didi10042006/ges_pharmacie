using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.DAL.Repositories;

public interface IAuditLogRepository
{
    Task<int> AddAsync(AuditLog log);
    void Add(AuditLog log);
    Task<IEnumerable<AuditLog>> GetRecentLogsAsync(int count = 100);
    Task<IEnumerable<AuditLog>> GetLogsByUserAsync(int userId, int count = 100);
}
