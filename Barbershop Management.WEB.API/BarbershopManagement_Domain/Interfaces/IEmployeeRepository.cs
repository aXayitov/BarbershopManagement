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
    public interface IEmployeeRepository : IRepositoryBase<Position>
    {
        List<Position> FindAll(EmployeeQueryParameters queryParameters);
        Position FindBarberById(int id);
        Position CreateBarber(Position barber);
        Position UpdateBarber(Position barber);
        void DeleteBarber(int id);
    }
}
