using BarbershopManagement_Domain.Common;
using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.CustomerDtos;
using BarbershopManagement_Services.DTOs.PositionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Interfaces
{
    public interface IPositionService
    {
        Task<PaginatedList<PositionDto>> GetAllPositionsAsync(PositionQueryParameters queryParameter);
        Task<PositionDto> GetPositionByIdAsync(int id);
        Task<PositionDto> CreatePositionAsync(PositionForCreateDto positionForCreateDto);
        Task<PositionDto> UpdatePositionAsync(PositionForUpdateDto positionForUpdateDto);
        Task DeletePositionAsync(int id);
    }
}
