using System.Net.Http.Json;
using CinemaBooking.WebAPI.Models.MoviesAggr;
using CinemaBooking.WebAPI.Tests.Extensions;
using CinemaBooking.WebAPI.Tests.Extensions.MoviesAggr;

namespace CinemaBooking.WebAPI.Tests.ControllersTests;

[TestClass]
public class MoviesControllerTests : ControllerTestsBase
{
    [TestMethod]
    public async Task Create_SuccessfullyCreatesMovie()
    {
        var expectedMovie = new MoviePostModel()
        {
            DefaultPrice = 100,
            DurationMins = 360,
            Name = "MOVIE1",
        };

        int movieId = AppClient.PostAsJsonGetId("movies", expectedMovie);

        var actualMovie = await AppClient.GetFromJsonAsync<MovieModel>($"movies/{movieId}");

        Assert.That.AreEqual(expectedMovie, actualMovie);
    }

    [TestMethod]
    public async Task Get_ReturnsPreInsertedMovie()
    {
        var actualMovie = await AppClient.GetFromJsonAsync<MovieModel>($"movies/{Globals.testMovie.Id}");

        Assert.IsNotNull(actualMovie);
        Assert.AreEqual(Globals.testMovie.Name, actualMovie.Name);
        Assert.AreEqual(Globals.testMovie.DurationMins, actualMovie.DurationMins);
        Assert.AreEqual(Globals.testMovie.DefaultPrice, actualMovie.DefaultPrice);
    }
}
