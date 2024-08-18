using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagemen_Infrastructure.Extensions
{
    
    public static class QueryableExtensions
    {
        public static async Task<List<T>> PaginatedListAsync<T>(
            this IQueryable<T> source,
            int pageNumber,
            int pageSize)
        {
            var totalCount = source.Count();
            var items =  await source
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return items;
        }
    }
}
