﻿using BarbershopManagement_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.Entity
{
    public class Barber : EntityBase
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
