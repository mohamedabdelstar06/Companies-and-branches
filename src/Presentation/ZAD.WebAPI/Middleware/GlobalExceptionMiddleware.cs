using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using ZAD.Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ZAD.WebAPI.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var statusCode = (int)HttpStatusCode.BadRequest; // Changed from 500 to 400 as requested
            var message = "An error occurred while processing your request.";

            switch (exception)
            {
                case NotFoundException e:
                    statusCode = (int)HttpStatusCode.NotFound;
                    message = e.Message;
                    break;
                case EntityDuplicatedException e:
                    statusCode = (int)HttpStatusCode.Conflict;
                    message = e.Message;
                    break;
                case ValidationException e:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = e.Message;
                    break;
                case ArgumentException e:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    message = e.Message;
                    break;
                default:
                    message = exception.Message;
                    break;
            }

            response.StatusCode = statusCode;

            var result = JsonSerializer.Serialize(new
            {
                statusCode = statusCode,
                message = message,
                traceId = context.TraceIdentifier,
                timestamp = DateTime.UtcNow.ToString("o")
            });

            await response.WriteAsync(result);
        }
    }
}
