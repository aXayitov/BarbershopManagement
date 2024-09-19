using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.CustomerDtos;
using BarbershopManagement_Services;
using BarbershopManagement_Services.DTOs.PositionDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop_Management.Controllers
{
    [Route("api/positions")]
    [ApiController]
    public class PositionController(IPositionService positionService) : ControllerBase
    {
        private readonly IPositionService _positionService = positionService
            ?? throw new ArgumentNullException(nameof(positionService));

        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<List<PositionDto>>> Get([FromQuery] PositionQueryParameters queryParameters)
        {
            var result = await _positionService.GetAllPositionsAsync(queryParameters);
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetPositionById")]
        public async Task<ActionResult<PositionDto>> GetById(int id)
        {
            var result = await _positionService.GetPositionByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PositionDto>> Create(PositionForCreateDto positionForCreateDto)
        {
            var result = await _positionService.CreatePositionAsync(positionForCreateDto);
            return Created("GetPositionById", result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, PositionForUpdateDto positionForUpdate)
        {
            if (id != positionForUpdate.Id)
            {
                return BadRequest($"Route id: {id} does not match with Position id: {positionForUpdate.Id}.");
            }

            await _positionService.UpdatePositionAsync(positionForUpdate);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _positionService.DeletePositionAsync(id);
            return NoContent();
        }
    }
}
