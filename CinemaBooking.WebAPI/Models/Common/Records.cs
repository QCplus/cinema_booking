namespace CinemaBooking.WebAPI.Models.Common;

public class Records
{
    public int Page { get; set; }

    public int PerPageCount { get; set; }

    public int Total { get; set; }

    public IEnumerable<object> Data { get; set; }

    public Records(IEnumerable<object> data)
    {
        Data = data;
    }

    public Records(int page, int perPageCount, int total, IEnumerable<object> data)
    {
        Page = page;
        PerPageCount = perPageCount;
        Total = total;
        Data = data;
    }
}
