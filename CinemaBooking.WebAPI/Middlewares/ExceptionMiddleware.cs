using System.Net;
using CinemaBooking.WebAPI.Models;

namespace CinemaBooking.WebAPI.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Serilog.ILogger _logger;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
        _logger = Serilog.Log.ForContext<ExceptionMiddleware>();
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
#if DEBUG
        var errorMessage = exception.Message;
#else
        var errorMessage = "Internal Server Error";
#endif
        await context.Response.WriteAsJsonAsync(new ErrorDetailsModel(errorMessage));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "");

            await HandleExceptionAsync(context, ex);
        }
    }
}
