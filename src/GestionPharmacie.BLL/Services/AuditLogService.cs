using GestionPharmacie.BLL.Security;
using GestionPharmacie.DAL.Repositories;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.BLL.Services;

public class AuditLogService : IAuditLogService
{
    private readonly IAuditLogRepository _auditLogRepository;

    public AuditLogService(IAuditLogRepository auditLogRepository)
    {
        _auditLogRepository = auditLogRepository;
    }

    public void LogAction(int? userId, string action, string? details)
    {
        var log = new AuditLog
        {
            UserId = userId,
            Action = action,
            Details = details,
            Timestamp = DateTime.Now
        };

        _auditLogRepository.Add(log);
    }

    public async Task LogActionAsync(int? userId, string action, string? details)
    {
        var log = new AuditLog
        {
            UserId = userId,
            Action = action,
            Details = details,
            Timestamp = DateTime.Now
        };

        await _auditLogRepository.AddAsync(log);
    }

    public void LogCurrentSessionAction(string action, string? details)
    {
        LogAction(UserSession.Instance.UserId, action, details);
    }

    public async Task LogCurrentSessionActionAsync(string action, string? details)
    {
        await LogActionAsync(UserSession.Instance.UserId, action, details);
    }

    public async Task<IEnumerable<AuditLog>> GetRecentLogsAsync(int count = 100)
    {
        return await _auditLogRepository.GetRecentLogsAsync(count);
    }
}
