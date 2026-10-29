using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.BLL.Services;

public interface IAuditLogService
{
    void LogAction(int? userId, string action, string? details);
    Task LogActionAsync(int? userId, string action, string? details);
    void LogCurrentSessionAction(string action, string? details);
    Task LogCurrentSessionActionAsync(string action, string? details);
    Task<IEnumerable<AuditLog>> GetRecentLogsAsync(int count = 100);
}
