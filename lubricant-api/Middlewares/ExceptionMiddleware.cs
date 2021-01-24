using Heikal.Lubricant.Core.Interfaces;
using lubricant_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Threading.Tasks;

namespace lubricant_api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;
        private readonly IHostEnvironment _environment;
        private readonly string DefaultErrorMessage = "Something went wrong";

        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger, IHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex).ConfigureAwait(false);
            }
        }
        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            _logger.LogError($"Something went wrong: {exception}");

            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            ErrorDetails errorDetails = new ErrorDetails();
            if (_environment.IsDevelopment())
            {
                errorDetails.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorDetails.Message = exception.Message;
                errorDetails.Detail = exception.StackTrace;
                errorDetails.InnerException = exception.InnerException != null ? exception.InnerException.Message : string.Empty;
            }
            else
            {
                errorDetails.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorDetails.Message = DefaultErrorMessage;
                errorDetails.Detail = exception.Message;
            }
            await httpContext.Response.WriteAsync(errorDetails.ToString()).ConfigureAwait(false);
        }
    }
}
