using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.Common
{
    public class PaginatedList<T> 
    {
        public List<T> Data { get; set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int PagesCount { get; private set; }
        public int ItemsCount { get; private set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public PaginatedList(List<T> items, int currentPage, int pageSize, int itemsCount) 
        {
            Data = (items);

            CurrentPage = currentPage;
            PageSize = pageSize;
            ItemsCount = itemsCount;
            PagesCount = (int)Math.Ceiling((double)itemsCount / pageSize);
            HasNextPage = currentPage < PagesCount;
            HasPreviousPage = currentPage > 1;
        }
    }
}
