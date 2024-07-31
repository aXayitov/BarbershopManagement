using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services;
using BarbershopManagement_Services.DTOs.BarberDtos;
using BarbershopManagement_Services.DTOs.StyleDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop_Management.Controllers;
[Route("api/barbers")]
[ApiController]
public class BarberController(IBarberService barberService) : ControllerBase
{
    private readonly IBarberService _barberService = barberService ?? throw new ArgumentNullException(nameof(barberService));

    [HttpGet]
    [HttpHead]
    public async Task<ActionResult<List<BarberDto>>> Get([FromQuery] BarberQueryParameters barberQueryParameters)
    {
        var result = await _barberService.GetAllBarbersAsync(barberQueryParameters);
        return Ok(result);
    }

    [HttpGet("{id:int}", Name = "GetBarberById")]
    public async Task<ActionResult<BarberDto>> GetById(int id)
    {
        var result = await _barberService.GetBarberByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<BarberDto>> Create(BarberForCreateDto barberQueryParameters)
    {
        var result = await _barberService.CreateBarberAsync(barberQueryParameters);
        return Created("GetBarberById", result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, BarberForUpdateDto barberForUpdate)
    {
        if (id != barberForUpdate.Id)
        {
            return BadRequest($"Route id: {id} does not match with Barber id: {barberForUpdate.Id}.");
        }

        await _barberService.UpdateBarberAsync(barberForUpdate);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _barberService.DeleteBarberAsync(id);
        return NoContent();
    }
}
