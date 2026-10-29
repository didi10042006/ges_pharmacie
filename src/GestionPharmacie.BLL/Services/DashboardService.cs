using GestionPharmacie.DAL.Repositories;
using GestionPharmacie.Models.DTOs;

namespace GestionPharmacie.BLL.Services;

public interface IDashboardService
{
    Task<DashboardMetricsDto> GetMetricsAsync();
}

public class DashboardService : IDashboardService
{
    private readonly IReportRepository _reportRepository;

    public DashboardService(IReportRepository reportRepository)
    {
        _reportRepository = reportRepository;
    }

    public async Task<DashboardMetricsDto> GetMetricsAsync()
    {
        return await _reportRepository.GetDashboardMetricsAsync(expiryDaysThreshold: 90);
    }
}
