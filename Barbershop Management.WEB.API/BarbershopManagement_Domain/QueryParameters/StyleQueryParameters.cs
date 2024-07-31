using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.QueryParameters
{
    public class StyleQueryParameters : QueryParametersBase
    {
        public decimal? MinPrice {  get; set; }
        public decimal? MaxPrice { get; set; }
        public string? ExcecutionTime { get; set; }
    }
}
