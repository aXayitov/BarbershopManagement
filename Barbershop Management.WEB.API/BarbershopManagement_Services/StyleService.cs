using AutoMapper;
using BarbershopManagemen_Infrastructure.Persistence;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Domain.Exceptions;
using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.StyleDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BarbershopManagement_Services
{
    public class StyleService(IMapper mapper, BarbershopDbContext context) : IStyleService
    {
        private readonly IMapper _mapper = mapper
        ?? throw new ArgumentNullException(nameof(mapper));
        private readonly BarbershopDbContext _context = context
            ?? throw new ArgumentNullException(nameof(context));

        public async Task<List<StyleDto>> GetAllStylesAsync(StyleQueryParameters queryParameter)
        {
            var query = _context.Styles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryParameter.Search))
            {
                query = query.Where(x => x.Name.Contains(queryParameter.Search)||
                    (x.Description != null && x.Description.Contains(queryParameter.Search)));
            }

            if(queryParameter.MinPrice > 0) 
            {
                query = query.Where(x => x.Price >= queryParameter.MinPrice);
            }
            
            if(queryParameter.MaxPrice > 0)
            {
                query = query.Where(x => x.Price < queryParameter.MaxPrice);
            }

            if(!string.IsNullOrEmpty(queryParameter.ExcecutionTime))
            {
                query = query.Where(x => x.ExecutionTime == queryParameter.ExcecutionTime);
            }

            var result = await query.ToListAsync();

            return _mapper.Map<List<StyleDto>>(result);
        }
        public async Task<StyleDto> GetStyleByIdAsync(int id)
        {
            var entity = await _context.Styles.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new EntityNotFoundException($"Style with id: {id} does not exist.");
            }

            return _mapper.Map<StyleDto>(entity);
        }
        public async Task<StyleDto> CreateStyleAsync(StyleForCreateDto styleForCreated)
        {
            var entity = _mapper.Map<Style>(styleForCreated);

            var createdEntity = _context.Styles.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<StyleDto>(createdEntity.Result.Entity);
        }
        public async Task<StyleDto> UpdateStyleAsync(StyleForUpdateDto style)
        {
            if (!_context.Styles.Any(x => x.Id == style.Id))
            {
                throw new EntityNotFoundException($"Style with id: {style.Id} does not exist.");
            }

            var entity = _mapper.Map<Style>(style);

            _context.Styles.Update(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<StyleDto>(entity);
        }
        public async Task DeleteStyleAsync(int id)
        {
            var entity = await _context.Styles.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new EntityNotFoundException($"Style with id: {id} does not exist.");
            }

            _context.Styles.Remove(entity);
            await _context.SaveChangesAsync();
        }        
    }
}
