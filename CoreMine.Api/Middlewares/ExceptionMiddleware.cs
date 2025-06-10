using CoreMine.ApplicationBusiness.Exceptions;
using System.Net;
using System.Text.Json;

namespace CoreMine.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ArgumentException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                var response = JsonSerializer.Serialize(new { error = ex.Message });
                await context.Response.WriteAsync(response);
            }
            catch (BusinessException ex)
            {
                context.Response.StatusCode = ex switch
                {
                    EntityNotFoundException => (int)HttpStatusCode.NotFound,
                    _ => (int)HttpStatusCode.BadRequest
                };
                context.Response.ContentType = "application/json";
                var response = JsonSerializer.Serialize(new { error = ex.Message });
                await context.Response.WriteAsync(response);
            }
            catch (Exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var response = JsonSerializer.Serialize(new { error = "Error interno del servidor" });
                await context.Response.WriteAsync(response);
            }
        }
    }
}
