using CinemaBooking.Core.Dtos.UsersAggr;
using CinemaBooking.WebAPI.Models.UsersAggr;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace CinemaBooking.WebAPI.Services;

public class ApiAuthenticator
{
    private readonly IMediator _mediator;

    public ApiAuthenticator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public static ClaimsPrincipal CreateClaimsPrincipal(UserModel user)
    {
        return new ClaimsPrincipal(
            new ClaimsIdentity(
                new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Role, user.RoleId.ToString())
                }, CookieAuthenticationDefaults.AuthenticationScheme)
            );
    }

    public static ClaimsPrincipal CreateClaimsPrincipal(UserDto user) => CreateClaimsPrincipal(UserModel.FromDto(user));

    public ClaimsPrincipal? Authenticate(UserCredentials creds)
    {
        UserDto? user = _mediator.Send(creds.ToAuthenticateCmd()).Result;
        if (user == null)
            return null;

        return CreateClaimsPrincipal(user);
    }
}
