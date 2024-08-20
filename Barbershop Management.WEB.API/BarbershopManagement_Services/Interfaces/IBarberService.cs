using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.BarberDtos;

namespace BarbershopManagement_Services.Interfaces
{
    public interface IBarberService
    {
        Task<List<BarberDto>> GetAllBarbersAsync(BarberQueryParameters barber);
        Task<BarberDto> GetBarberByIdAsync(int id);
        Task<BarberDto> CreateBarberAsync(BarberForCreateDto barber);
        Task<BarberDto> UpdateBarberAsync(BarberForUpdateDto barber);
        Task DeleteBarberAsync(int id);
    }
}
