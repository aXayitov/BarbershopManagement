using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.Common
{
    public class PaginatedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int PagesCount { get; private set; }
        public int ItemsCount { get; private set; }

        public PaginatedList(List<T> items, int currentPage, int pageSize, int itemsCount) 
        {
            AddRange(items);

            CurrentPage = currentPage;
            PageSize = pageSize;
            ItemsCount = itemsCount;
            PagesCount = (int)Math.Ceiling((double)itemsCount / pageSize);
        }
    }
}
