namespace CinemaBooking.WebAPI.Tests;

internal static class Globals
{
    public static readonly Infrastructure.Entities.Movie testMovie = new()
    {
        Id = 1,
        Name = "TEST MOVIE",
        DurationMins = 120,
    };

    public static readonly Infrastructure.Entities.Room testRoom = new()
    {
        Id = 1,
        Rows = 8,
        Columns = 6,
        Name = "TEST ROOM",
    };
}
