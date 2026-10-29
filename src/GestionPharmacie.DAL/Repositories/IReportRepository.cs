using GestionPharmacie.Models.DTOs;

namespace GestionPharmacie.DAL.Repositories;

public interface IReportRepository
{
    Task<DashboardMetricsDto> GetDashboardMetricsAsync(int expiryDaysThreshold = 90);
    Task<SalesPeriodReportDto> GetSalesReportByPeriodAsync(DateTime startDate, DateTime endDate);
}
