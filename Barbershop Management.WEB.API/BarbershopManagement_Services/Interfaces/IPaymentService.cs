using BarbershopManagement_Domain.Common;
using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.PaymentDto;
using BarbershopManagement_Services.DTOs.PositionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Interfaces
{
    public interface IPaymentService
    {
        Task<PaginatedList<PaymentDto>> GetAllPaymentsAsync(PaymentQueryParameters queryParameter);
        Task<PaymentDto> GetPaymentByIdAsync(int id);
        Task<PaymentDto> CreatePaymentAsync(PaymentForCreateDto paymentForCreateDto);
        Task<PaymentDto> UpdatePaymentAsync(PaymentForUpdateDto paymentForUpdateDto);
        Task DeletePaymentAsync(int id);
    }
}
