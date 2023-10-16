namespace CinemaBooking.WebAPI.Tests.ModelComparers;

internal interface IModelComparer<TE, TA>
{
    public void AreEqual(TE a, TA b);
}
