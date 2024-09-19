using BarbershopManagement_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.Entity
{
    public class Service : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan? Duration { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
