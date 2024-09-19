using BarbershopManagement_Domain.Common;
using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.BarberDtos;

namespace BarbershopManagement_Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<PaginatedList<EmployeeDto>> GetAllBarbersAsync(EmployeeQueryParameters barber);
        Task<EmployeeDto> GetBarberByIdAsync(int id);
        Task<EmployeeDto> CreateBarberAsync(EmployeeForCreateDto barber);
        Task<EmployeeDto> UpdateBarberAsync(EmployeeForUpdateDto barber);
        Task DeleteBarberAsync(int id);
    }
}
