using BarbershopManagement_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.Entity
{
    public class Position : EntityBase
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
