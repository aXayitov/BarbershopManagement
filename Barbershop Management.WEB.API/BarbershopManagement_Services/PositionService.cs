using AutoMapper;
using BarbershopManagemen_Infrastructure.Persistence;
using BarbershopManagemen_Services.Extensions;
using BarbershopManagement_Domain.Common;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.PositionDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using WMS.Domain.Exceptions;

namespace BarbershopManagement_Services
{
    public class PositionService(IMapper mapper, BarbershopDbContext context) : IPositionService
    {
        private readonly IMapper _mapper = mapper
           ?? throw new ArgumentNullException(nameof(mapper));
        private readonly BarbershopDbContext _context = context
            ?? throw new ArgumentNullException(nameof(context));

        public async Task<PaginatedList<PositionDto>> GetAllPositionsAsync(PositionQueryParameters queryParameter)
        {
            var query = _context.Positions.AsNoTracking().AsQueryable();

            if(!string.IsNullOrWhiteSpace(queryParameter.Search))
            {
                query = query.Where(x => x.Name.Contains(queryParameter.Search)||
                        x.Description != null && x.Description.Contains(queryParameter.Search));
            }

            var result = await query.PaginatedListAsync<PositionDto, Position>(_mapper.ConfigurationProvider, queryParameter.PageNumber, queryParameter.PageSize);
            
            return result;
        }

        public async Task<PositionDto> GetPositionByIdAsync(int id)
        {
            var entity = await _context.Positions.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                throw new EntityNotFoundException($"Position with id: {id} does not exist.");
            }

            var positionDto = _mapper.Map<PositionDto>(entity);
            return positionDto;
        }

        public async Task<PositionDto> CreatePositionAsync(PositionForCreateDto positionForCreateDto)
        {
            var entity = _mapper.Map<Position>(positionForCreateDto);

            var createdEntity = await _context.Positions.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<PositionDto>(createdEntity.Entity);
        }

        public async Task<PositionDto> UpdatePositionAsync(PositionForUpdateDto positionForUpdateDto)
        {
            if (!_context.Positions.Any(x => x.Id == positionForUpdateDto.Id))
            {
                throw new EntityNotFoundException($"Position with id: {positionForUpdateDto.Id} does not exist.");
            }

            var entity = _mapper.Map<Position>(positionForUpdateDto);

            _context.Positions.Update(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<PositionDto>(entity);
        }

        public async Task DeletePositionAsync(int id)
        {
            var entity = await _context.Positions.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new EntityNotFoundException($"Position with id: {id} does not exist.");

            _context.Positions.Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}
