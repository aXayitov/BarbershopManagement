using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.EnrollmentDtos
{
    public class EnrollmentDto
    {
        public int Id { get; init; }
        public int CustomerId { get; init; }
        public string Customer { get; init; }
        public int EmployeeId { get; init; }
        public string Employee { get; init; }
        public decimal InitialPayment { get; init; }
        public decimal TotalPrice { get; init; }
        public DateTime Date { get; init; }
    }
}
