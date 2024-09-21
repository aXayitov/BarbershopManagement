using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services;
using BarbershopManagement_Services.DTOs.ServicesDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop_Management.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServicesController(IServiceService service) : ControllerBase
    {
        private readonly IServiceService _service = service
            ?? throw new ArgumentNullException(nameof(service));

        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<List<ServiceDto>>> Get([FromQuery] ServiceQueryParameters queryParameters)
        {
            var result = await _service.GetAllServicesAsync(queryParameters);
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetServiceById")]
        public async Task<ActionResult<ServiceDto>> GetById(int id)
        {
            var result = await _service.GetServiceByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceDto>> Create(ServiceForCreateDto serviceForCreate)
        {
            var result = await _service.CreateServiceAsync(serviceForCreate);
            return Created("GetServiceById", result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, ServiceForUpdateDto serviceForUpdate)
        {
            if (id != serviceForUpdate.Id)
            {
                return BadRequest($"Route id: {id} does not match with Service id: {serviceForUpdate.Id}.");
            }

            await _service.UpdateServiceAsync(serviceForUpdate);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteServiceAsync(id);
            return NoContent();
        }
        
    }
}
