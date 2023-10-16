using CinemaBooking.WebAPI.Models.MoviesAggr;

namespace CinemaBooking.WebAPI.Tests.Extensions.MoviesAggr;

public static class AssertExtensions
{
    public static void AreEqual(this Assert assert, MoviePostModel expected, MovieModel actual)
    {
        Assert.AreEqual(expected.Name, actual.Name, nameof(actual.Name));
        Assert.AreEqual(expected.DefaultPrice, actual.DefaultPrice, nameof(actual.DefaultPrice));
        Assert.AreEqual(expected.DurationMins, actual.DurationMins, nameof(actual.DurationMins));
    }
}
