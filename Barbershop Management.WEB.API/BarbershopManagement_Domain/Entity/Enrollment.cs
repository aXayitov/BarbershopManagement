using BarbershopManagement_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.Entity
{
    public class Enrollment : EntityBase
    {
        public decimal InitialPayment { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int StyleId { get; set; }
        public Style Style { get; set; }
        public int BarberId { get; set; }
        public Barber Barber { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
