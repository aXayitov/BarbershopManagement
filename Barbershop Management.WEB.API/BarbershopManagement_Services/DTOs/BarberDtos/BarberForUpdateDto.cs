﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.BarberDtos
{
    public record BarberForUpdateDto(int Id, string FirstName, string? LastName, string PhoneNumber);
}
