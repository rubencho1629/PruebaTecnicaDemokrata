using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Demokrata.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            // Log de la excepción
            _logger.LogError(context.Exception, "Se produjo un error no controlado.");

            // Construcción de la respuesta
            var response = new
            {
                message = "Se produjo un error inesperado.",
                details = context.Exception.Message
            };

            // Configuración de la respuesta HTTP
            context.Result = new ObjectResult(response)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}
