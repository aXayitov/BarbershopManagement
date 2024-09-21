using BarbershopManagement_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.QueryParameters
{
    public class PaymentQueryParameters : QueryParametersBase
    {
        public int? EnrollmetnId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
    }
}
