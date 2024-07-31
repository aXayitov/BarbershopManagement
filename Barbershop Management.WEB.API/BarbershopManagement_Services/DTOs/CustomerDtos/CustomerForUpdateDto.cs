using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.CustomerDtos
{
    public record CustomerForUpdateDto(
        int Id,
        string FirstName,
        string? LastName,
        string PhoneNumber,
        string? Email);
}
