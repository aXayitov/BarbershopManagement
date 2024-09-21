using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Services.DTOs.BarberDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.PositionDtos
{
    public class PositionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<EmployeeDto> Employees { get; set; }
    }
}
