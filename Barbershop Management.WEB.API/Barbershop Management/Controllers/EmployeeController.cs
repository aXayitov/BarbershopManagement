using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.BarberDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop_Management.Controllers;
[Route("api/employee")]
[ApiController]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    private readonly IEmployeeService _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));

    [HttpGet]
    [HttpHead]
    public async Task<ActionResult<List<EmployeeDto>>> Get([FromQuery] EmployeeQueryParameters barberQueryParameters)
    {
        var result = await _employeeService.GetAllBarbersAsync(barberQueryParameters);
        return Ok(result);
    }

    [HttpGet("{id:int}", Name = "GetBarberById")]
    public async Task<ActionResult<EmployeeDto>> GetById(int id)
    {
        var result = await _employeeService.GetBarberByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> Create(EmployeeForCreateDto barberQueryParameters)
    {
        var result = await _employeeService.CreateBarberAsync(barberQueryParameters);
        return Created("GetBarberById", result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, EmployeeForUpdateDto barberForUpdate)
    {
        if (id != barberForUpdate.Id)
        {
            return BadRequest($"Route id: {id} does not match with Barber id: {barberForUpdate.Id}.");
        }

        await _employeeService.UpdateBarberAsync(barberForUpdate);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _employeeService.DeleteBarberAsync(id);
        return NoContent();
    }
}
