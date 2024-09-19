using AutoMapper;
using BarbershopManagemen_Infrastructure.Persistence;
using BarbershopManagemen_Services.Extensions;
using BarbershopManagement_Domain.Common;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.EnrollmentDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using WMS.Domain.Exceptions;

namespace BarbershopManagement_Services
{
    public class EnrollmentService(IMapper mapper, BarbershopDbContext context) : IEnrollmentService
    {
        private readonly IMapper _mapper = mapper
           ?? throw new ArgumentNullException(nameof(mapper));
        private readonly BarbershopDbContext _context = context
            ?? throw new ArgumentNullException(nameof(context));

        public async Task<PaginatedList<EnrollmentDto>> GetAllEnrollmentsAsync(EnrollmentQueryParameters enrollmentQueryParameters)
        {
            var query = _context.Enrollments.Include(x => x.Employee).Include(x => x.Customer).AsQueryable();

            if(enrollmentQueryParameters.EnrollmentDate is not null)
            {
                query = query.Where(x => x.Date == enrollmentQueryParameters.EnrollmentDate);
            }

            if(enrollmentQueryParameters.InitialPayment is not null)
            {
                query = query.Where(x => x.InitialPayment ==  enrollmentQueryParameters.InitialPayment);
            }

            if(enrollmentQueryParameters.Search is not null)
            {
                query = query.Where(x => x.Customer.FirstName.Contains(enrollmentQueryParameters.Search)||
                        x.Customer.LastName.Contains(enrollmentQueryParameters.Search)||
                        x.Employee.FirstName.Contains(enrollmentQueryParameters.Search)||
                        x.Employee.LastName.Contains(enrollmentQueryParameters.Search));
            }

            var result = await query.PaginatedListAsync<EnrollmentDto, Enrollment>(_mapper.ConfigurationProvider ,enrollmentQueryParameters.PageNumber, enrollmentQueryParameters.PageSize);

            return result;
        }

        public async Task<EnrollmentDto> GetEnrollmentByIdAsync(int id)
        {
            var entity = await _context.Enrollments.Include(x => x.Employee).Include(x => x.Customer).FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new EntityNotFoundException($"Enrollment with id: {id} does not exist");
            }

            return _mapper.Map<EnrollmentDto>(entity);
        }
        public async Task<EnrollmentDto> CreateEnrollmentAsync(EnrollmentForCreateDto enrollmentForCreateDto)
        {
            var entity = _mapper.Map<Enrollment>(enrollmentForCreateDto);

            var createdEntrollment = await _context.Enrollments.AddAsync(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<EnrollmentDto>(createdEntrollment.Entity);
        }

        public async Task<EnrollmentDto> UpdateEnrollmentAsync(EnrollmentForUpdateDto enrollmentForUpdateDto)
        {
            if (!_context.Enrollments.Any(x => x.Id == enrollmentForUpdateDto.Id))
            {
                throw new EntityNotFoundException($"Enrollment with id: {enrollmentForUpdateDto.Id} does not exist.");
            }

            var entity = _mapper.Map<Enrollment>(enrollmentForUpdateDto);

            _context.Enrollments.Update(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<EnrollmentDto>(entity);
        }

        public async Task DeleteEnrollmentAsync(int id)
        {
            var entity = await _context.Enrollments.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new EntityNotFoundException($"Enrollment with id: {id} does not exist.");
            }

            _context.Enrollments.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
