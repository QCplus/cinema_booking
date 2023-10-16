using CinemaBooking.WebAPI.Tests.ModelComparers;

namespace CinemaBooking.WebAPI.Tests.Extensions;

internal static class AssertExtensions
{
    public static void AreEqual<T>(this Assert assert, T expected, T actual, IComparer<T> comparer)
    {
        if (comparer.Compare(expected, actual) != 0)
            Assert.Fail("Actual value not equals to expected");
    }
}
