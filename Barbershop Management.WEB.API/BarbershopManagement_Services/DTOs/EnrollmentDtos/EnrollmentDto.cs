using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.EnrollmentDtos
{
    public class EnrollmentDto
    {
        public int CustomerId { get; init; }
        public string Customer { get; init; }
        public int StyleId { get; init; }
        public string Style { get; init; }
        public int BarberId { get; init; }
        public string Barber { get; init; }
        public DateTime Date { get; init; }
    }
}
