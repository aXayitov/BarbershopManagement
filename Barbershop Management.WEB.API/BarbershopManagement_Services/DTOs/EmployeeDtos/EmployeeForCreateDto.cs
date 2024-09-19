using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.BarberDtos
{
    public record EmployeeForCreateDto(
        int PositionId, 
        string FirstName, 
        string? LastName, 
        string PhoneNumber);
}
