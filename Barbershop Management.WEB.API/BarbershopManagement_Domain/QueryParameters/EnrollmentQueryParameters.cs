using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.QueryParameters
{
    public class EnrollmentQueryParameters :QueryParametersBase
    {
        public decimal? InitialPayment { get; set; }
        public DateTime? EnrollmentDate { get; set; }
    }
}
