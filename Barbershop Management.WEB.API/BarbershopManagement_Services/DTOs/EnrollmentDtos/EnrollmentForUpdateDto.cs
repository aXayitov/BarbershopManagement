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
        public decimal InitialPayment {  get; set; }
        public decimal TotalPrice { get; set; }
        public int BarberId { get; init; }
        public DateTime Date {  get; init; }
    }
}
