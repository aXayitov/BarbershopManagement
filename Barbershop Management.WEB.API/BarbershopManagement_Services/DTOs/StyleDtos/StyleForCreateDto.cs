using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.StyleDtos
{
    public record StyleForCreateDto(string Name, string? Description, decimal Price, string ExecutionTime);
}
