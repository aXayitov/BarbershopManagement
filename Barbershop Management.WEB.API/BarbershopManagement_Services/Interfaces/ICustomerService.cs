using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.CustomerDtos;
using BarbershopManagement_Services.DTOs.StyleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarbershopManagement_Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetAllCustomersAsync(CustomerQueryParameters queryParameter);
        Task<CustomerDto> GetCustomerByIdAsync(int id);
        Task<CustomerDto> CreateCustomerAsync(CustomerForCreateDto customerForCreateDto);
        Task<CustomerDto> UpdateCustomerAsync(CustomerForUpdateDto customerForUpdateDto);
        Task DeleteCustomerAsync(int id);
    }
}
