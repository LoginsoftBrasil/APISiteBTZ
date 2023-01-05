using APISiteBTZ.Core.Exceptions;
using System.Text.Json;
using TWJobs.Api.Common.Dtos;

namespace APISiteBTZ.Core.Middlewares
{
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ExceptionHandleMiddleware(RequestDelegate next)
        {
            _next = next;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BadCredentialsException e)
            {
                await handleBadCredentialsExceptionAsync(context, e);
            }
        }

        private Task handleBadCredentialsExceptionAsync(HttpContext context, BadCredentialsException e)
        {
            var body = new ErrorResponse
            {
                Status = 401,
                Cause = e.GetType().Name,
                Message = e.Message,
                Timestamp = DateTime.Now
            };

            context.Response.StatusCode = body.Status;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
        }
    }
}
