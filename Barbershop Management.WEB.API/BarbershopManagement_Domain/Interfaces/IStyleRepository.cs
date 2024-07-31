using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Domain.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.Interfaces
{
    public interface IStyleRepository : IRepositoryBase<Style>
    {
        List<Style> FindAllStyles(StyleQueryParameters queryParameters);
        Style FindStyleById(int id);
        Style CreateStyle(Style style);
        Style UpdateStyle(Style style);
        void DeleteStyle(int id);
    }
}
