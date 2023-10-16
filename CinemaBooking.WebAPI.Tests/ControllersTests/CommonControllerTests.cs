using System.Net;

namespace CinemaBooking.WebAPI.Tests.ControllersTests;

[TestClass]
public class CommonControllerTests : ControllerTestsBase
{
    [TestMethod]
    public async Task ReturnsUnauthorizedIfUserNotAuthenticated()
    {
        var client = AppFactory.CreateClient();

        var result = await client.GetAsync("users/1");

        Assert.AreEqual(HttpStatusCode.Unauthorized, result.StatusCode);
    }
}
