using System.Text.Encodings.Web;
using CinemaBooking.Core.Commands.UsersAggr.GetUserByFilter;
using CinemaBooking.WebAPI.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CinemaBooking.WebAPI.Tests.Auth;

internal class TestAuthHandler : AuthenticationHandler<TestAuthOptions>
{
    public const string SCHEME_NAME = "TestAuth";

    private readonly IMediator _mediator;

    public TestAuthHandler(IOptionsMonitor<TestAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock,
                           IMediator mediator)
        : base(options, logger, encoder, clock)
    {
        _mediator = mediator;
    }

    private async Task<AuthenticationTicket> CreateTicketAsync(string nickname)
    {
        var user = await _mediator.Send(
            new GetUserByFilterCommand(Nickname: nickname));

        return new AuthenticationTicket(
            ApiAuthenticator.CreateClaimsPrincipal(user),
            SCHEME_NAME);
    }

    protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var authHeader = Context.Request.Headers.Authorization[0]?.Split(' ');
        if (authHeader == null || authHeader.Length <= 1)
            return AuthenticateResult.Fail("Authorization header doesn't contain username");

        return AuthenticateResult.Success(
            await CreateTicketAsync(authHeader[1])
            );
    }
}

internal static class TestAuthHandlerExtensions
{
    public static void AddTestAuthentication(this AuthenticationBuilder builder)
    {
        builder.AddScheme<TestAuthOptions, TestAuthHandler>(TestAuthHandler.SCHEME_NAME, null);
    }
}
