using System.Linq.Expressions;

namespace CinemaBooking.Core.Extensions;

internal static class QueryableExtensions
{
    /// <summary>
    /// Adds expression to queryable if value isn't null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="V"></typeparam>
    /// <param name="queryable"></param>
    /// <param name="notNullableValue"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public static IQueryable<T> WhereIfNotNull<T, V>(this IQueryable<T> queryable, V? notNullableValue, Expression<Func<T, bool>> expression)
    {
        return notNullableValue == null
            ? queryable
            : queryable.Where(expression);
    }
}
