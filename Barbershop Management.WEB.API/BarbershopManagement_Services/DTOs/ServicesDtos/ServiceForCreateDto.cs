using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.ServicesDtos
{
    public record ServiceForCreateDto(
        string Name,
        decimal Price,
        TimeSpan? Duration);
}
