using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.StyleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Interfaces
{
    public interface IStyleService
    {
        Task<List<StyleDto>> GetAllStylesAsync(StyleQueryParameters query);
        Task<StyleDto> GetStyleByIdAsync(int id);
        Task<StyleDto> CreateStyleAsync(StyleForCreateDto style);
        Task<StyleDto> UpdateStyleAsync(StyleForUpdateDto style);
        Task DeleteStyleAsync(int id);
    }
}
