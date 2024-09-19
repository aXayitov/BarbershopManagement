using AutoMapper;
using BarbershopManagemen_Infrastructure.Persistence;
using BarbershopManagemen_Services.Extensions;
using BarbershopManagement_Domain.Common;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.BarberDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using WMS.Domain.Exceptions;

namespace BarbershopManagement_Services
{
    public class EmployeeService(IMapper mapper, BarbershopDbContext context) : IEmployeeService
    {
        private readonly IMapper _mapper = mapper
            ?? throw new ArgumentNullException(nameof(mapper));
        private readonly BarbershopDbContext _context = context
            ?? throw new ArgumentNullException(nameof(context));


        public async Task<PaginatedList<EmployeeDto>> GetAllBarbersAsync(EmployeeQueryParameters queryParameters)
        {
            var query = _context.Employees.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryParameters.Search))
            {
                query = query.Where(x => x.FirstName.Contains(queryParameters.Search)||
                    (x.LastName != null && x.LastName.Contains(queryParameters.Search)));
            }

            var result = await query.PaginatedListAsync<EmployeeDto, Employee>(_mapper.ConfigurationProvider, queryParameters.PageNumber, queryParameters.PageSize);

            return result;    
        }
        public async Task<EmployeeDto> GetBarberByIdAsync(int id)
        {
            var entity = await _context.Employees.Include(x => x.Enrollments).FirstOrDefaultAsync(x => x.Id == id);

            if(entity == null)
            {
                throw new EntityNotFoundException($"Barber with id: {id} does not exist.");
            }

            return _mapper.Map<EmployeeDto>(entity);
        }
        public async Task<EmployeeDto> CreateBarberAsync(EmployeeForCreateDto barber)
        {
            var entity = _mapper.Map<Employee>(barber);

            var createdEntity = await _context.Employees.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<EmployeeDto>(createdEntity.Entity);
        }
        public async Task<EmployeeDto> UpdateBarberAsync(EmployeeForUpdateDto barber)
        {
            if (!_context.Employees.Any(x => x.Id == barber.Id))
            {
                throw new EntityNotFoundException($"Barber with id: {barber.Id} does not exist.");
            }

            var entity = _mapper.Map<Employee>(barber);

            _context.Employees.Update(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<EmployeeDto>(entity);
        }
        public async Task DeleteBarberAsync(int id)
        {
            var entity = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new EntityNotFoundException($"Barber with id: {id} does not exist.");
            }

            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
