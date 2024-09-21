using BarbershopManagement_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.EnrollmentDtos
{
    public class EnrollmentForUpdateDto
    {
        public int Id { get; init; }
        public int CustomerId { get; init; }
        public int BarberId { get; init; }
        public int ServiceId { get; set; }
        public DateTime Date {  get; init; }
        public Status Status { get; init; }
    }
}
