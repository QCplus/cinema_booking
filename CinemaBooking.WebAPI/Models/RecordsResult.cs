using CinemaBooking.WebAPI.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.WebAPI.Models;

public class RecordsResult : ObjectResult
{
    public RecordsResult(IEnumerable<object> value, BaseFilter filter)
        : base(new Records(page: filter.Page, perPageCount: filter.PerPageCount, total: 0, data: value))
    {
        StatusCode = 200;
    }
}
