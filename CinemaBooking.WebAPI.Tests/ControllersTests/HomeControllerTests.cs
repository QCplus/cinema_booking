using System.Net.Http.Json;
using CinemaBooking.WebAPI.Models;
using CinemaBooking.WebAPI.Models.UsersAggr;
using CinemaBooking.WebAPI.Tests.Extensions;

namespace CinemaBooking.WebAPI.Tests.ControllersTests;

[TestClass]
public class HomeControllerTests : ControllerTestsBase
{
    [TestMethod]
    public void SignIn_IfPhoneAndEmailAreEmptyReturnsErrorMessage()
    {
        var creds = new UserCredentials()
        {
            Password = "1235"
        };

        var result = AppClient.PostAsJsonAsync("home/signin", creds).Result
            .GetContent<ErrorDetailsModel>();

        Assert.IsNotNull(result);
        Assert.IsNotNull(result.InvalidFields);
        Assert.AreEqual(1, result.InvalidFields.Length, "There must be one invalid field");
        Assert.AreEqual(nameof(creds.PhoneOrEmail), result.InvalidFields.First().Key);
    }

    [TestMethod]
    public void SignIn_CanVisitRestrictedUrlsAfterAuthentication()
    {
        var client = AppFactory.CreateClient();
        
        var creds = new UserCredentials()
        {
            PhoneOrEmail = "12345678901",
            Password = "23ef"
        };

        client.PostAsJsonAsync("home/signin", creds).Result.EnsureSuccess();

        Assert.IsNotNull(
            client.GetFromJsonAsync<UserModel>("users/1").Result);
    }
}
