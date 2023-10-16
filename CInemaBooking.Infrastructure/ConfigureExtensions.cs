using CinemaBooking.Infrastructure.DbContexts;
using CinemaBooking.Infrastructure.Repositories.Abstract;
using CinemaBooking.Infrastructure.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Infrastructure;

public static class ConfigureExtensions
{
    public static IServiceCollection AddDb(this IServiceCollection services, string connectionString)
    {
        return services
            .AddDbContext<AppDbContext, PgDbContext>(options => options.UseNpgsql(connectionString))
            .AddScoped<IUsersRepository, UsersRepository>()
            .AddScoped<IMoviesRepository, MoviesRepository>()
            .AddScoped<IMovieSessionsRepository, MovieSessionsRepository>()
            ;
    }
}
