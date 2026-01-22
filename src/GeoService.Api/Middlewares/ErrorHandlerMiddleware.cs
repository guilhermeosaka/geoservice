using System.Net;
using GeoService.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MapService.Api.Middlewares;

public class ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var problemDetails = GetProblemDetails(ex);

            if (ex is HandledException)
                logger.LogWarning(ex, "Handled exception occurred");
            else
                logger.LogError(ex, "Unhandled exception occurred");
            
            context.Response.StatusCode = problemDetails.Status ?? (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

    private static ProblemDetails GetProblemDetails(Exception exception) =>
        exception switch
        {
            CountryAlreadyExistsException ex => new ProblemDetails
            {
                Title = ex.Title,
                Detail = ex.Message,
                Status = StatusCodes.Status409Conflict
            },

            CountryNotFoundException ex => new ProblemDetails
            {
                Title = ex.Title,
                Detail = ex.Message,
                Status = StatusCodes.Status404NotFound
            },

            _ => new ProblemDetails
            {
                Title = "Unexpected error",
                Detail = "An unexpected error occurred.",
                Status = StatusCodes.Status500InternalServerError
            }
        };
}