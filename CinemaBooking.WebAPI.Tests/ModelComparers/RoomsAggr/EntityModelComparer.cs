using CinemaBooking.Infrastructure.Entities;
using CinemaBooking.WebAPI.Models.RoomsAggr;

namespace CinemaBooking.WebAPI.Tests.ModelComparers.RoomsAggr;

internal class EntityModelComparer : IModelComparer<Room, RoomModel>
{
    private readonly bool _ignoreId;

    public EntityModelComparer(bool ignoreId = false)
    {
        _ignoreId = ignoreId;
    }

    public void AreEqual(Room a, RoomModel b)
    {
        if (!_ignoreId)
            Assert.AreEqual(a.Id, b.Id);
        Assert.AreEqual(a.Name, b.Name);
        Assert.AreEqual(a.Description, b.Description);
    }
}
