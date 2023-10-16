using System.Net.Http.Json;
using CinemaBooking.WebAPI.Models.RoomsAggr;
using CinemaBooking.WebAPI.Tests.Extensions;
using CinemaBooking.WebAPI.Tests.ModelComparers.RoomsAggr;
using FluentAssertions;

namespace CinemaBooking.WebAPI.Tests.ControllersTests;

[TestClass]
public class RoomsControllerTests : ControllerTestsBase
{
    [TestMethod]
    public async Task Create_SuccessfullyCreatesRoom()
    {
        RoomModel newRoom = new()
        {
            Name = "TEST ROOM",
            Description = "TEST DESCRIPTION"
        };

        newRoom.Id = AppClient.PostAsJsonAsync("rooms", newRoom).Result
            .EnsureSuccess()
            .GetContent<int>();

        RoomModel? actualRoom = await AppClient.GetFromJsonAsync<RoomModel>($"rooms/{newRoom.Id}");

        actualRoom.Should().BeEquivalentTo(newRoom);
    }

    [TestMethod]
    public async Task Get_ReturnsPreInsertedRoom()
    {
        var actualRoom = await AppClient.GetFromJsonAsync<RoomModel>($"rooms/{Globals.testRoom.Id}");

        Assert.IsNotNull(actualRoom);
        new EntityModelComparer().AreEqual(Globals.testRoom, actualRoom);
    }
}
