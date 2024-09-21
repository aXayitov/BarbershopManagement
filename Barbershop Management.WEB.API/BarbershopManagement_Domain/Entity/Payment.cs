using BarbershopManagement_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.Entity
{
    public class Payment : EntityBase
    {
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentType { get; set; }

    }

    public enum PaymentMethod
    {
        Cash,
        CreaditCard,
        OnlinePayment,
        DebitCard
    }
}
