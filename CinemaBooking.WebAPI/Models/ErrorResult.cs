using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.WebAPI.Models;

public class ErrorResult : IActionResult
{
    public async Task ExecuteResultAsync(ActionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
}
