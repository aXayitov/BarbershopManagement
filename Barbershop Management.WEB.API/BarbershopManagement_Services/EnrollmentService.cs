using AutoMapper;
using BarbershopManagemen_Infrastructure.Extensions;
using BarbershopManagemen_Infrastructure.Persistence;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Domain.Exceptions;
using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.CustomerDtos;
using BarbershopManagement_Services.DTOs.EnrollmentDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services
{
    public class EnrollmentService(IMapper mapper, BarbershopDbContext context) : IEnrollmentService
    {
        private readonly IMapper _mapper = mapper
           ?? throw new ArgumentNullException(nameof(mapper));
        private readonly BarbershopDbContext _context = context
            ?? throw new ArgumentNullException(nameof(context));

        public async Task<List<EnrollmentDto>> GetAllEnrollmentsAsync(EnrollmentQueryParameters enrollmentQueryParameters)
        {
            var query = _context.Enrollments.Include(x => x.Barber).Include(x => x.Customer).AsQueryable();

            if(enrollmentQueryParameters.EnrollmentDate is not null)
            {
                query = query.Where(x => x.Date == enrollmentQueryParameters.EnrollmentDate);
            }

            if(enrollmentQueryParameters.InitialPayment is not null)
            {
                query = query.Where(x => x.InitialPayment ==  enrollmentQueryParameters.InitialPayment);
            }

            var result = await query.PaginatedListAsync(enrollmentQueryParameters.PageNumber, enrollmentQueryParameters.PageSize);

            return _mapper.Map<List<EnrollmentDto>>(result);
        }

        public async Task<EnrollmentDto> GetEnrollmentByIdAsync(int id)
        {
            var entity = await _context.Enrollments.FirstOrDefaultAsync(x => x.Id == id);

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
