using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.CustomerDtos;
using BarbershopManagement_Services.DTOs.EnrollmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task<List<EnrollmentDto>> GetAllEnrollmentsAsync(EnrollmentQueryParameters enrollmentQueryParameters);
        Task<EnrollmentDto> GetEnrollmentByIdAsync(int id);
        Task<EnrollmentDto> CreateEnrollmentAsync(EnrollmentForCreateDto enrollmentForCreateDto);
        Task<EnrollmentDto> UpdateEnrollmentAsync(EnrollmentForUpdateDto enrollmentForUpdateDto);
        Task DeleteEnrollmentAsync(int id);
    }
}
