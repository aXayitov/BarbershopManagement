using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.StyleDtos;
using BarbershopManagement_Services;
using BarbershopManagement_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BarbershopManagement_Services.DTOs.CustomerDtos;
using BarbershopManagement_Domain.Entity;

namespace Barbershop_Management.Controllers;
[Route("api/customers")]
[ApiController]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));

    [HttpGet]
    [HttpHead]
    public async Task<ActionResult<List<CustomerDto>>> Get([FromQuery] CustomerQueryParameters customerQueryParameters)
    {
        var result = await _customerService.GetAllCustomersAsync(customerQueryParameters);
        return Ok(result);
    }

    [HttpGet("{id:int}", Name = "GetCustomerById")]
    public async Task<ActionResult<CustomerDto>> GetById(int id)
    {
        var result = await _customerService.GetCustomerByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> Create(CustomerForCreateDto customerQueryParameters)
    {
        var result = await _customerService.CreateCustomerAsync(customerQueryParameters);
        return Created("GetCustomerById", result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, CustomerForUpdateDto customerForUpdate)
    {
        if (id != customerForUpdate.Id)
        {
            return BadRequest($"Route id: {id} does not match with Customer id: {customerForUpdate.Id}.");
        }

        await _customerService.UpdateCustomerAsync(customerForUpdate);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _customerService.DeleteCustomerAsync(id);
        return NoContent();
    }
}
