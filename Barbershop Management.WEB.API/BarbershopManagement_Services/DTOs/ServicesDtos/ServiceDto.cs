using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Services.DTOs.EnrollmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.ServicesDtos
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public TimeSpan? Duration { get; set; }
        public virtual ICollection<EnrollmentDto> Enrollments { get; set; }
    }
}
