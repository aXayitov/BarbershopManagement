using AutoMapper;
using AutoMapper.QueryableExtensions;
using BarbershopManagement_Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace BarbershopManagemen_Services.Extensions
{

    public static class QueryableExtensions
    {
        public static async Task<PaginatedList<T>> PaginatedListAsync<T, K>(
            this IQueryable<K> source,
            IConfigurationProvider configurationProvider,
            int pageNumber = 1,
            int pageSize = 15)
        {
            var totalCount = await source.CountAsync();
            var items =  await source
                .Skip((pageNumber-1) * pageSize)
                .Take(pageSize)
                .ProjectTo<T>(configurationProvider)
                .ToListAsync();

            int g = 0;

            return new PaginatedList<T>(items, pageNumber, pageSize, totalCount);
        }
    }
}
