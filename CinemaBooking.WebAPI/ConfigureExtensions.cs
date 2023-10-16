using System.Net;
using CinemaBooking.Core;
using CinemaBooking.Infrastructure;
using CinemaBooking.WebAPI.Middlewares;
using CinemaBooking.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CinemaBooking.WebAPI;

internal static class ConfigureExtensions
{
    private static void ConfigureDB(this WebApplicationBuilder builder)
    {
        string connectionString = builder.Configuration.GetConnectionString("Debug") ?? "";

        builder.Services.AddDb(connectionString);
    }

    private static void ConfigureAuthentication(this WebApplicationBuilder builder)
    {
        var authBuilder = builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.SlidingExpiration = true;
                options.Events.OnRedirectToAccessDenied = async (context) =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                };
                options.Events.OnRedirectToLogin = async (context) =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                };
                options.ForwardDefaultSelector = context =>
                {
                    var authHeader = context.Request.Headers.Authorization;
                    if (authHeader.Any())
                        return authHeader[0]?.Split(' ')[0];
                    return CookieAuthenticationDefaults.AuthenticationScheme;
                };
            });

        builder.Services.AddAuthorization();
        builder.Services.AddSingleton<ApiAuthenticator>();
    }

    public static void ConfigureApp(this WebApplicationBuilder builder)
    {
        builder.ConfigureDB();
        builder.Services.ConfigureServices();
        builder.ConfigureAuthentication();
    }

    public static void ConfigureMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
