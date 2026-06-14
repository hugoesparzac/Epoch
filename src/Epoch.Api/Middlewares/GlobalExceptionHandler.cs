using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Epoch.Api.Middlewares;

public class GlobalExceptionHandler(IWebHostEnvironment env) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        int statusCode = exception switch
        {
            InvalidOperationException => StatusCodes.Status400BadRequest,
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };
        
        string safeDetail = (statusCode == StatusCodes.Status500InternalServerError && !env.IsDevelopment())
            ? "Ha ocurrido un error interno en el servidor."
            : exception.Message;
        
        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = "Error en la petición",
            Detail = safeDetail
        };
        
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        
        return true;
    }
}