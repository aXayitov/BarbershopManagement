﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.CustomerDtos
{
    public class CustomerDto
    {
        public int Id { get; init; }
        public string FullName { get; init; }
        public string PhoneNumber { get; init; }
        public string? Email { get; init; }
    }
}
