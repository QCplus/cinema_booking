using System.Security.Claims;
using CinemaBooking.WebAPI.Models;
using CinemaBooking.WebAPI.Models.UsersAggr;
using CinemaBooking.WebAPI.Services;
using CinemaBooking.WebAPI.Validators.UsersAggr;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : AbstractController
{
    private readonly ApiAuthenticator _authenticator;

    public HomeController(IMediator mediator, ApiAuthenticator authenticator) : base(mediator)
    {
        _authenticator = authenticator;
    }

    [HttpPost("signin")]
    public async Task<ActionResult> SignIn(UserCredentials creds)
    {
        var validationResult = new CredentialsValidator().Validate(creds);
        if (!validationResult.IsValid)
            return BadRequest(new ErrorDetailsModel(validationResult));

        var principal = _authenticator.Authenticate(creds);
        if (principal == null)
            return Unauthorized(new ErrorDetailsModel("Invalid credentials"));

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal);

        return Ok();
    }

    [HttpPost("signout")]
    public async Task<ActionResult> SignOutUser()
    {
        await HttpContext.SignOutAsync();

        return Ok();
    }
}
