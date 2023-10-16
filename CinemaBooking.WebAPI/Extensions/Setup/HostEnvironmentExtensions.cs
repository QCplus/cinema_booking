namespace CinemaBooking.WebAPI.Extensions.Setup;

public static class HostEnvironmentExtensions
{
    public static bool IsTesting(this IWebHostEnvironment env) => env.EnvironmentName == "Testing";
}
