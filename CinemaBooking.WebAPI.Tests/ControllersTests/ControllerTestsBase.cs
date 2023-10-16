using CinemaBooking.Infrastructure.DbContexts;
using CinemaBooking.WebAPI.Tests.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace CinemaBooking.WebAPI.Tests.ControllersTests;

public abstract class ControllerTestsBase
{
    protected WebApplicationFactory<Program> AppFactory { get; }

    protected HttpClient AppClient { get; private set; }

    public ControllerTestsBase()
    {
        AppFactory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(configuration =>
            {
                configuration.UseEnvironment("Testing");

                configuration.ConfigureTestServices(sc =>
                {
                    new AuthenticationBuilder(sc).AddTestAuthentication();
                    
                });
            });

        AppClient = AppFactory.CreateClient();
        AppClient.DefaultRequestHeaders.Add("Authorization", $"{TestAuthHandler.SCHEME_NAME} admin");
    }

    private AppDbContext GetDbContext()
    {
        return (AppDbContext?)AppFactory.Services.GetService(typeof(AppDbContext))
            ?? throw new Exception($"Can't find {nameof(AppDbContext)}");
    }

    [TestCleanup]
    public virtual void TestCleanup()
    {
        GetDbContext().Database.EnsureDeleted();
    }

    [TestInitialize]
    public virtual void TestInit()
    {
        var db = GetDbContext();

        db.Rooms.Add(Globals.testRoom);
        db.Movies.Add(Globals.testMovie);

        db.SaveChanges();
    }
}
