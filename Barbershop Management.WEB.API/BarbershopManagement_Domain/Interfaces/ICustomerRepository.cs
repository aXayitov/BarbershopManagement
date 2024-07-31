using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Domain.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Domain.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        List<Customer> FindAllCustomers(CustomerQueryParameters queryParameters);
        Customer FindCustomerById(int id);
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
