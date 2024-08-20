using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.QueryParameters
{
    public class QueryParametersBase
    {
        public string? Search { get; set; }
        private const int MAX_PAGESIZE = 50;
        private int _pageSize = 15;
        public int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize = value > MAX_PAGESIZE ? MAX_PAGESIZE : value;
            }
        }
        public int PageNumber { get; set; } = 1;
    }
}
