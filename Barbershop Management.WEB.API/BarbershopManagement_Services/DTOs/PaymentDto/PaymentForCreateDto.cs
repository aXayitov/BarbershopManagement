using BarbershopManagement_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.DTOs.PaymentDto
{
    public class PaymentForCreateDto
    {
        public int EnrollmentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentType { get; set; }
    }
}
