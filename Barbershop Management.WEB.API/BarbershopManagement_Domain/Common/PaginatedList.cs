using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.Common
{
    public class PaginatedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int PagesCount { get; set; }
        public int ItemsCount { get; set; }

        public PaginatedList(List<T> items, int currentPage, int pageSize, int pageCount, int itemsCount) 
        {
            AddRange(items);
        }
    }
}
