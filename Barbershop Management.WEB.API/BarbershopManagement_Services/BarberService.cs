using AutoMapper;
using BarbershopManagemen_Infrastructure.Extensions;
using BarbershopManagemen_Infrastructure.Persistence;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Domain.Exceptions;
using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.BarberDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services
{
    public class BarberService(IMapper mapper, BarbershopDbContext context) : IBarberService
    {
        private readonly IMapper _mapper = mapper
            ?? throw new ArgumentNullException(nameof(mapper));
        private readonly BarbershopDbContext _context = context
            ?? throw new ArgumentNullException(nameof(context));

        public async Task<List<BarberDto>> GetAllBarbersAsync(BarberQueryParameters queryParameters)
        {
            var query = _context.Barbers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryParameters.Search))
            {
                query = query.Where(x => x.FirstName.Contains(queryParameters.Search)||
                    (x.LastName != null && x.LastName.Contains(queryParameters.Search)));
            }

            var result = await query.PaginatedListAsync(queryParameters.PageNumber, queryParameters.PageSize);

            return _mapper.Map<List<BarberDto>>(result);    
        }
        public async Task<BarberDto> GetBarberByIdAsync(int id)
        {
            var entity = await _context.Barbers.FirstOrDefaultAsync(x => x.Id == id);

            if(entity == null)
            {
                throw new EntityNotFoundException($"Barber with id: {id} does not exist.");
            }

            return _mapper.Map<BarberDto>(entity);
        }
        public async Task<BarberDto> CreateBarberAsync(BarberForCreateDto barber)
        {
            var entity = _mapper.Map<Barber>(barber);

            var createdEntity = await _context.Barbers.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<BarberDto>(createdEntity.Entity);
        }
        public async Task<BarberDto> UpdateBarberAsync(BarberForUpdateDto barber)
        {
            if (!_context.Barbers.Any(x => x.Id == barber.Id))
            {
                throw new EntityNotFoundException($"Barber with id: {barber.Id} does not exist.");
            }

            var entity = _mapper.Map<Barber>(barber);

            _context.Barbers.Update(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<BarberDto>(entity);
        }
        public async Task DeleteBarberAsync(int id)
        {
            var entity = await _context.Barbers.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new EntityNotFoundException($"Barber with id: {id} does not exist.");
            }

            _context.Barbers.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
