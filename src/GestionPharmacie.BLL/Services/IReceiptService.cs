using GestionPharmacie.Models.DTOs;

namespace GestionPharmacie.BLL.Services;

public interface IReceiptService
{
    Task<string> GenerateReceiptTextAsync(SaleDetailDto sale);
}
