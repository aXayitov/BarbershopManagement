using AutoMapper;
using BarbershopManagemen_Infrastructure.Persistence;
using BarbershopManagemen_Services.Extensions;
using BarbershopManagement_Domain.Common;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.CustomerDtos;
using BarbershopManagement_Services.DTOs.ServicesDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Domain.Exceptions;

namespace BarbershopManagement_Services
{
    public class ServicesServic(IMapper mapper, BarbershopDbContext context) : IServiceService
    {
        private readonly IMapper _mapper = mapper
          ?? throw new ArgumentNullException(nameof(mapper));
        private readonly BarbershopDbContext _context = context
            ?? throw new ArgumentNullException(nameof(context));

        public async Task<PaginatedList<ServiceDto>> GetAllServicesAsync(ServiceQueryParameters queryParameter)
        {
            var query = _context.Services.AsNoTracking().AsQueryable();

            if(!string.IsNullOrWhiteSpace(queryParameter.Search))
            {
                query = query.Where(x => x.Name.Contains(queryParameter.Search));
            }

            if(queryParameter.MinPrice > 0)
            {
                query = query.Where(x => x.Price == queryParameter.MinPrice);
            }

            if(queryParameter.MaxPrice > 0)
            {
                query = query.Where(x => x.Price == queryParameter.MaxPrice);
            }

            if(queryParameter.MinPrice > 0 && queryParameter.MaxPrice > 0)
            {
                query = query.Where(x => x.Price > queryParameter.MinPrice && x.Price < queryParameter.MaxPrice);
            }

            var result = await query.PaginatedListAsync<ServiceDto, Service>(_mapper.ConfigurationProvider, queryParameter.PageNumber, queryParameter.PageSize);

            return result;
        }

        public async Task<ServiceDto> GetServiceByIdAsync(int id)
        {
            var entity = await _context.Services
                .Include(x => x.Enrollments)
                .ThenInclude(x => x.Customer)
                .Include(x => x.Enrollments)
                .ThenInclude(x => x.Employee)
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new EntityNotFoundException($"Service with {id} does not exist.");

            return _mapper.Map<ServiceDto>(entity);
        }

        public async Task<ServiceDto> CreateServiceAsync(ServiceForCreateDto serviceForCreateDto)
        {
            var entity = _mapper.Map<Service>(serviceForCreateDto);

            var createdEntity = await _context.Services.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<ServiceDto>(createdEntity.Entity);
        }

        public async Task<ServiceDto> UpdateServiceAsync(ServiceForUpdateDto serviceForUpdateDto)
        {
            if (!_context.Services.Any(x => x.Id == serviceForUpdateDto.Id))
            {
                throw new EntityNotFoundException($"Service with id: {serviceForUpdateDto.Id} does not exist.");
            }

            var entity = _mapper.Map<Service>(serviceForUpdateDto);

            _context.Services.Update(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<ServiceDto>(entity);
        }

        public async Task DeleteServiceAsync(int id)
        {
            var entity = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new EntityNotFoundException($"Service with id: {id} does not exist.");
            }

            _context.Services.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
