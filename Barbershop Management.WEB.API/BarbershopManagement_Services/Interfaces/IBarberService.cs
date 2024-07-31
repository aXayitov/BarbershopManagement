using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.BarberDtos;
using BarbershopManagement_Services.DTOs.StyleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
