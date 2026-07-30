using Dsw2026Ej15.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Dsw2026Ej15.Api.Middleware;

public class ExceptionsMiddleware
{

    private readonly RequestDelegate _next;

    public ExceptionsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = 400;

            await context.Response.WriteAsync(ex.Message);
        }
        catch (Exception)
        {
            context.Response.StatusCode = 500;

            await context.Response.WriteAsync(
                "Internal Server Error");
        }
    }

}
