using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.StyleDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop_Management.Controllers;

[Route("api/styles")]
[ApiController]
public class StyleController(IStyleService styleService) : ControllerBase
{
    private readonly IStyleService _styleService = styleService ?? throw new ArgumentNullException(nameof(styleService));
    
    [HttpGet]
    [HttpHead]
    public async Task<ActionResult<List<StyleDto>>> Get([FromQuery] StyleQueryParameters styleQueryParameters)
    {
        var styles = await _styleService.GetAllStylesAsync(styleQueryParameters);
        return Ok(styles);
    }

    [HttpGet("{id:int}", Name = "GetStyleById")]
    public async Task<ActionResult<StyleDto>> GetById(int id)
    {
        var result = await _styleService.GetStyleByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<StyleDto>> Create(StyleForCreateDto styleQueryParameters)
    {
        var result = await _styleService.CreateStyleAsync(styleQueryParameters);
        return Created("GetStyleById", result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, StyleForUpdateDto styleForUpdate)
    {
        if (id != styleForUpdate.Id)
        {
            return BadRequest($"Route id: {id} does not match with Style id: {styleForUpdate.Id}.");
        }

        await _styleService.UpdateStyleAsync(styleForUpdate);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _styleService.DeleteStyleAsync(id);
        return NoContent();
    }
}
