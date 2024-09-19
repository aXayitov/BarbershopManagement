﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.EnrollmentDtos
{
    public record EnrollmentForCreateDto()
    {
        public int CustomerId { get; init; }
        public int BarberId { get; init; }
        public decimal InitialPayment { get; init; }
        public decimal TotalPrice { get; init; }
        public DateTime Date { get; init; }
    }
}
