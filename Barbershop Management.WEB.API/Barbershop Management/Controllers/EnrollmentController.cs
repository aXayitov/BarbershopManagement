using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.BarberDtos;
using BarbershopManagement_Services;
using BarbershopManagement_Services.DTOs.EnrollmentDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop_Management.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentController(IEnrollmentService enrollmentService) : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService = enrollmentService ?? throw new ArgumentNullException(nameof(enrollmentService));

        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<List<EnrollmentDto>>> Get([FromQuery] EnrollmentQueryParameters enrollmentQueryParameters)
        {
            var result = await _enrollmentService.GetAllEnrollmentsAsync(enrollmentQueryParameters);
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetEnrollmentById")]
        public async Task<ActionResult<EnrollmentDto>> GetById(int id)
        {
            var result = await _enrollmentService.GetEnrollmentByIdAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<EnrollmentDto>> Create([FromBody]EnrollmentForCreateDto enrollmentQueryParameters)
        {
            var result = await _enrollmentService.CreateEnrollmentAsync(enrollmentQueryParameters);
            return Created("GetEnrollmentById", result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, EnrollmentForUpdateDto enrollmentForUpdate)
        {
            if (id != enrollmentForUpdate.Id)
            {
                return BadRequest($"Route id: {id} does not match with Enrollment id: {enrollmentForUpdate.Id}.");
            }

            await _enrollmentService.UpdateEnrollmentAsync(enrollmentForUpdate);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _enrollmentService.DeleteEnrollmentAsync(id);
            return NoContent();
        }
    }
}
