using BarbershopManagement_Domain.Common;
using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.PositionDtos;
using BarbershopManagement_Services.DTOs.ServicesDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Interfaces
{
    public interface IServiceService
    {
        Task<PaginatedList<ServiceDto>> GetAllServicesAsync(ServiceQueryParameters queryParameter);
        Task<ServiceDto> GetServiceByIdAsync(int id);
        Task<ServiceDto> CreateServiceAsync(ServiceForCreateDto serviceForCreateDto);
        Task<ServiceDto> UpdateServiceAsync(ServiceForUpdateDto serviceForUpdateDto);
        Task DeleteServiceAsync(int id);
    }
}
