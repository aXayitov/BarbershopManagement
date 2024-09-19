using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.PositionDtos
{
    public record PositionForUpdateDto(
        int Id,
        string Name,
        string? Description);
}
