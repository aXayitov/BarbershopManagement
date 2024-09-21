using BarbershopManagement_Domain.Entity;
using BarbershopManagement_Domain.QueryParameters;
using BarbershopManagement_Services.DTOs.PaymentDto;
using BarbershopManagement_Services.DTOs.ServicesDtos;
using BarbershopManagement_Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barbershop_Management.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController(IPaymentService service) : ControllerBase
    {
        private readonly IPaymentService _service = service
            ?? throw new ArgumentNullException(nameof(service));

        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<List<PaymentDto>>> Get([FromQuery] PaymentQueryParameters queryParameters)
        {
            var result = await _service.GetAllPaymentsAsync(queryParameters);
            return Ok(result);
        }

        [HttpGet("{id:int}", Name = "GetPaymentById")]
        public async Task<ActionResult<PaymentDto>> GetById(int id)
        {
            var result = await _service.GetPaymentByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceDto>> Create(PaymentForCreateDto paymentForCreate)
        {
            var result = await _service.CreatePaymentAsync(paymentForCreate);
            return Created("GetPaymentById", result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, PaymentForUpdateDto paymentForUpdate)
        {
            if (id != paymentForUpdate.Id)
            {
                return BadRequest($"Route id: {id} does not match with Payment id: {paymentForUpdate.Id}.");
            }

            await _service.UpdatePaymentAsync(paymentForUpdate);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeletePaymentAsync(id);
            return NoContent();
        }
    }
}
