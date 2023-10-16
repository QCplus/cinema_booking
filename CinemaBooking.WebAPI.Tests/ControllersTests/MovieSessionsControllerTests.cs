using System.Net.Http.Json;
using CinemaBooking.WebAPI.Models.MovieSessionsAggr;
using CinemaBooking.WebAPI.Tests.Extensions;

namespace CinemaBooking.WebAPI.Tests.ControllersTests;

[TestClass]
public class MovieSessionsControllerTests : ControllerTestsBase
{
    private static readonly DayOfWeek[] _fullWeek = new[]
    {
        DayOfWeek.Sunday,
        DayOfWeek.Monday,
        DayOfWeek.Tuesday,
        DayOfWeek.Wednesday,
        DayOfWeek.Thursday,
        DayOfWeek.Friday,
        DayOfWeek.Saturday,
    };

    private MovieSessionsPostModel CreatePostModel(DateOnly sessionStart, DateOnly? sessionEnd = null)
    {
        return new MovieSessionsPostModel()
        {
            StartsFrom = sessionStart,
            EndsAt = sessionEnd ?? sessionStart,
            Days = _fullWeek,
            MovieId = Globals.testMovie.Id,
            MovieStarts = new[]
            {
                new TimeOnly(10, 00)
            },
            RoomId = Globals.testRoom.Id,
            Price = 120,
        };
    }

    [TestMethod]
    public async Task Search_CanFilterByDay()
    {
        var model = CreatePostModel(DateOnly.FromDateTime(DateTime.Today.AddDays(1)));

        AppClient.PostAsJsonAsync("movieSessions", model).Result
            .EnsureSuccess();

        var actualSessions = await AppClient.GetFromJsonAsync<IEnumerable<MovieSessionModel>>(
            $"movieSessions?{nameof(MovieSessionsFilter.Day)}={model.StartsFrom:yyyy-MM-dd}");

        Assert.IsNotNull(actualSessions);
        Assert.AreEqual(1, actualSessions.Count());

        var session = actualSessions.First();
        Assert.AreEqual(model.StartsFrom.ToDateTime(model.MovieStarts.First()), session.StartsAt);
        Assert.AreEqual(model.Price, session.Price);
    }

    [TestMethod]
    public async Task Create_NewSessionsaAreViewableFromUpcomingMethod()
    {
        var sessionsDayDuration = 3;
        var model = new MovieSessionsPostModel()
        {
            StartsFrom = DateOnly.FromDateTime(DateTime.Today.AddDays(3)),
            Days = _fullWeek,
            MovieId = Globals.testMovie.Id,
            MovieStarts = new[]
            {
                new TimeOnly(10, 00)
            },
            RoomId = Globals.testRoom.Id,
            Price = 120,
        };
        model.EndsAt = model.StartsFrom.AddDays(sessionsDayDuration - 1);

        AppClient.PostAsJsonAsync("movieSessions", model).Result
            .EnsureSuccess();

        var actualSessions = await AppClient.GetFromJsonAsync<IEnumerable<UpcomingSessionModel>>("movieSessions/upcoming/10");

        Assert.IsNotNull(actualSessions);
        Assert.AreEqual(sessionsDayDuration, actualSessions.Count());
        foreach (var s in actualSessions)
        {
            Assert.AreEqual(model.MovieStarts.Count(), s.Sessions.Count());
            Assert.AreEqual(model.Price, s.Sessions.First().Price);
            Assert.AreEqual(model.MovieStarts.First(), s.Sessions.First().StartsAt);

            new ModelComparers.MoviesAggr.EntityModelComparer().AreEqual(Globals.testMovie, s.Movie);
        }
    }
}
