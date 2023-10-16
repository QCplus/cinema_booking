using System.Reflection;
using CinemaBooking.Core.DataRules;
using CinemaBooking.Core.Services;
using CinemaBooking.Core.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Core;

public static class ConfigureExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        return services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        })
            .AddSingleton<EmailsRule>()
            .AddSingleton<PhonesRule>()

            .AddSingleton<IPasswordHasher, PasswordHasher>()
            ;
    }
}
