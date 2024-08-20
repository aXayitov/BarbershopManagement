using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.CustomerDtos;

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
