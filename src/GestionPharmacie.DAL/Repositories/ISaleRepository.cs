using System.Data;
using GestionPharmacie.Models.DTOs;
using GestionPharmacie.Models.Entities;

namespace GestionPharmacie.DAL.Repositories;

public interface ISaleRepository
{
    Task<int> CreateSaleAsync(Sale sale, IEnumerable<SaleItem> items, IDbConnection connection, IDbTransaction transaction);
    Task<SaleDetailDto?> GetSaleByIdAsync(int saleId);
    Task<SaleDetailDto?> GetSaleByNumberAsync(string saleNumber);
    Task<string> GenerateNextSaleNumberAsync(IDbConnection? connection = null, IDbTransaction? transaction = null);
    Task<ShiftSummaryDto> GetShiftSummaryAsync(DateTime date);
    Task<IEnumerable<SaleDetailDto>> GetRecentSalesAsync(int count = 50);
}
