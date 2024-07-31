using BarbershopManagement_Domain.Common;
using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Domain.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.Interfaces
{
    public interface IBarberRepository : IRepositoryBase<Barber>
    {
        List<Barber> FindAll(BarberQueryParameters queryParameters);
        Barber FindBarberById(int id);
        Barber CreateBarber(Barber barber);
        Barber UpdateBarber(Barber barber);
        void DeleteBarber(int id);
    }
}
