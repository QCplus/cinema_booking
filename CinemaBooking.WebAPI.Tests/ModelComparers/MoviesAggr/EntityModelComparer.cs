using CinemaBooking.Infrastructure.Entities;
using CinemaBooking.WebAPI.Models.MoviesAggr;

namespace CinemaBooking.WebAPI.Tests.ModelComparers.MoviesAggr;

internal class EntityModelComparer : IModelComparer<Movie, MovieModel>
{
    private readonly bool _ignoreId;

    public EntityModelComparer(bool ignoreId = false)
    {
        _ignoreId = ignoreId;
    }

    public void AreEqual(Movie a, MovieModel b)
    {
        if (!_ignoreId)
            Assert.AreEqual(a.Id, b.Id);
        Assert.AreEqual(a.Name, b.Name);
        Assert.AreEqual(a.DefaultPrice, b.DefaultPrice);
        Assert.AreEqual(a.DurationMins, b.DurationMins);
    }
}
