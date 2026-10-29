using GestionPharmacie.Models.DTOs;
using GestionPharmacie.Models.Entities;
using GestionPharmacie.Models.Enums;

namespace GestionPharmacie.BLL.Services;

public interface ISaleService
{
    Task<StockLot?> GetNextFifoLotForProductAsync(int productId);
    Task<int> GetTotalSellableStockAsync(int productId);
    Task<bool> ValidateDiscountApprovalAsync(string supervisorUsername, string supervisorPassword);
    Task<SaleDetailDto> ProcessSaleAsync(
        List<CartItemDto> cartItems, 
        PaymentMethod paymentMethod, 
        decimal discountAmount, 
        decimal paidAmount);
    Task<SaleDetailDto?> GetSaleByNumberAsync(string saleNumber);
    Task<ShiftSummaryDto> GetShiftSummaryAsync(DateTime date);
    Task<bool> RecordShiftCloseAsync(DateTime date, decimal countedCash, string? notes = null);
}
