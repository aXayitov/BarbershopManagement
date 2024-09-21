using AutoMapper;
using BarbershopManagemen_Infrastructure.Persistence;
using BarbershopManagemen_Services.Extensions;
using BarbershopManagement_Domain.Common;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.PaymentDto;
using BarbershopManagement_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using WMS.Domain.Exceptions;

namespace BarbershopManagement_Services
{
    public class PaymentService(IMapper mapper, BarbershopDbContext context) : IPaymentService
    {
        private readonly IMapper _mapper = mapper
           ?? throw new ArgumentNullException(nameof(mapper));
        private readonly BarbershopDbContext _context = context
            ?? throw new ArgumentNullException(nameof(context));

        public async Task<PaginatedList<PaymentDto>> GetAllPaymentsAsync(PaymentQueryParameters queryParameter)
        {
            var query = _context.Payments.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryParameter.Search))
            {
                query = query.Where(x => x.Enrollment.Service.Name.Contains(queryParameter.Search) ||
                     x.Enrollment.Customer.FirstName.Contains(queryParameter.Search) ||
                     x.Enrollment.Customer.LastName != null && x.Enrollment.Customer.LastName.Contains(queryParameter.Search) ||
                     x.Enrollment.Employee.FirstName.Contains(queryParameter.Search) ||
                     x.Enrollment.Employee.LastName != null && x.Enrollment.Employee.LastName.Contains(queryParameter.Search));
            }

            if (queryParameter.EnrollmetnId > 0)
            {
                query = query.Where(x => x.EnrollmentId == queryParameter.EnrollmetnId);
            }

            if (queryParameter.Amount > 0)
            {
                query = query.Where(x => x.Amount == queryParameter.Amount);
            }

            if (queryParameter.PaymentDate.HasValue)
            {
                query = query.Where(x => x.PaymentDate.Day == queryParameter.PaymentDate.Value.Day);
            }

            if (queryParameter.PaymentMethod >= 0)
            {
                query = query.Where(x => x.PaymentType == queryParameter.PaymentMethod);
            }

            var result = await query.PaginatedListAsync<PaymentDto, Payment>(_mapper.ConfigurationProvider, queryParameter.PageNumber, queryParameter.PageSize);

            return result;
        }
        
        public async Task<PaymentDto> GetPaymentByIdAsync(int id)
        {
            var entity = await _context.Payments.FirstOrDefaultAsync(x => x.Id ==  id)
                ?? throw new EntityNotFoundException($"Payment with id: {id} does not exist.");

            var paymentDto = _mapper.Map<PaymentDto>(entity);

            return paymentDto;
        }

        public async Task<PaymentDto> CreatePaymentAsync(PaymentForCreateDto paymentForCreateDto)
        {
            var entity = _mapper.Map<Payment>(paymentForCreateDto);

            var createdEntity = await _context.Payments.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<PaymentDto>(createdEntity.Entity);
        }

        public async Task<PaymentDto> UpdatePaymentAsync(PaymentForUpdateDto paymentForUpdateDto)
        {
            if (!_context.Payments.Any(x => x.Id == paymentForUpdateDto.Id))
            {
                throw new EntityNotFoundException($"Payment with id: {paymentForUpdateDto.Id} does not exist.");
            }

            var entity = _mapper.Map<Payment>(paymentForUpdateDto);

            _context.Payments.Update(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<PaymentDto>(entity);
        }

        public Task DeletePaymentAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
