using AutoMapper;
using BarbershopManagemen_Infrastructure.Persistence;
using BarbershopManagemen_Services.Extensions;
using BarbershopManagement_Domain.Common;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.CustomerDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using WMS.Domain.Exceptions;

namespace BarbershopManagement_Services
{
    public class CustomerService(IMapper mapper, BarbershopDbContext context) : ICustomerService
    {
        private readonly IMapper _mapper = mapper
           ?? throw new ArgumentNullException(nameof(mapper));
        private readonly BarbershopDbContext _context = context
            ?? throw new ArgumentNullException(nameof(context));

        public async Task<PaginatedList<CustomerDto>> GetAllCustomersAsync(CustomerQueryParameters queryParameter)
        {
            // Deffered execution
            var query = _context.Customers.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryParameter.Search))
            {
                query = query.Where(x => x.FirstName.Contains(queryParameter.Search) ||
                    (x.LastName != null && x.LastName.Contains(queryParameter.Search)));
            }

            var result = await query.PaginatedListAsync<CustomerDto, Customer>(_mapper.ConfigurationProvider, queryParameter.PageNumber, queryParameter.PageSize); ;

            return result;
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var entity = await _context.Customers.Include(x => x.Enrollments).FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new EntityNotFoundException($"Cusomter with id: {id} does not exist.");
            }

            return _mapper.Map<CustomerDto>(entity);
        }
        public async Task<CustomerDto> CreateCustomerAsync(CustomerForCreateDto customerForCreateDto)
        {
            var entity = _mapper.Map<Customer>(customerForCreateDto);

            var createdEntity = await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerDto>(createdEntity.Entity);
        }
        public async Task<CustomerDto> UpdateCustomerAsync(CustomerForUpdateDto customerForUpdate)
        {
            if (!_context.Customers.Any(x => x.Id == customerForUpdate.Id))
            {
                throw new EntityNotFoundException($"Customer with id: {customerForUpdate.Id} does not exist.");
            }

            var entity = _mapper.Map<Customer>(customerForUpdate);

            _context.Customers.Update(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerDto>(entity);
        }
        public async Task DeleteCustomerAsync(int id)
        {
            var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new EntityNotFoundException($"Customer with id: {id} does not exist.");
            }

            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
