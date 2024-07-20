using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace WebApp
{
    public sealed class ExceptionHandler(ILogger<ExceptionHandler> logger) : IExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> _logger = logger;
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var result = new ProblemDetails();
            switch (exception)
            {
                case ArgumentException argumentException:
                    result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.BadRequest,
                        Type = argumentException.GetType().Name,
                        Title = "An unexpected error occurred",
                        Detail = argumentException.Message,
                        Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                    };
                    _logger.LogError(argumentException, $"Exception occured : {argumentException.Message}");
                    break;

                case KeyNotFoundException keyNotFoundException:
                    result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.NotFound,
                        Type = keyNotFoundException.GetType().Name,
                        Title = "An unexpected error occurred",
                        Detail = keyNotFoundException.Message,
                        Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                    };
                    _logger.LogError(keyNotFoundException, $"Exception occured : {keyNotFoundException.Message}");
                    break;

                default:
                    result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.InternalServerError,
                        Type = exception.GetType().Name,
                        Title = "An unexpected error occurred",
                        Detail = exception.Message,
                        Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
                    };
                    _logger.LogError(exception, $"Exception occured : {exception.Message}");
                    break;
            }
            await httpContext.Response.WriteAsJsonAsync(result, cancellationToken: cancellationToken);
            return true;
        }
    }
}
