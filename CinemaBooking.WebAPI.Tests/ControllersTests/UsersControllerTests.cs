using System.Net.Http.Json;
using CinemaBooking.WebAPI.Models.UsersAggr;
using FluentAssertions;

namespace CinemaBooking.WebAPI.Tests.ControllersTests;

[TestClass]
public class UsersControllerTests : ControllerTestsBase
{
    private readonly UserModel _adminUser = new()
    {
        Id = 1,
        FirstName = "Admin",
        LastName = "Admin",
        Phone = "12345678901",
        RoleId = 1,
        Email = null,
    };

    [TestMethod]
    public async Task GetUserById_ReturnsPreInsertedUser()
    {
        UserModel? actualUser = await AppClient.GetFromJsonAsync<UserModel>($"users/{_adminUser.Id}");

        actualUser.Should().BeEquivalentTo(_adminUser);
    }

    [TestMethod]
    public async Task GetUsersByFilter_ReturnsUserByPhone()
    {
        var users = await AppClient.GetFromJsonAsync<UserModel[]>($"users?phone={_adminUser.Phone}");

        Assert.IsNotNull(users);
        users.Should().HaveCount( 1 );
        users[0].Should().BeEquivalentTo(_adminUser);
    }

    [TestMethod]
    public async Task GetUsersByFilter_ReturnsUserByIncompletePhone()
    {
        var users = await AppClient.GetFromJsonAsync<UserModel[]>($"users?phone={_adminUser.Phone[..7]}");

        Assert.IsNotNull(users);
        users.Should().HaveCount(1);
        users[0].Should().BeEquivalentTo(_adminUser);
    }
}
