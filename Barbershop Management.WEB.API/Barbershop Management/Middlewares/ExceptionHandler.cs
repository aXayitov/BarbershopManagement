using BarbershopManagement_Domain.Exceptions;
using System.Net;

namespace Barbershop_Management.Middlewares
{
    public class ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
    {
        private readonly RequestDelegate _next = next ?? throw new ArgumentNullException(nameof(next));
        private readonly ILogger<ExceptionHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleAsync(ex, context);
            }
        }
        private async Task HandleAsync(Exception ex, HttpContext context)
        {
            _logger.LogError(ex, ex.Message);

            var statusCode = (int)HttpStatusCode.InternalServerError;
            var message = "Internal Server Error.";

            if (ex is EntityNotFoundException)
            {
                statusCode = (int)HttpStatusCode.NotFound;
                message = ex.Message;
            }

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(message);
        }
    }
}
