namespace CinemaBooking.Infrastructure.SearchFilters.AppUsersAggr;

public record AppUsersFilter(
    string? FirstName = null,
    string? LastName = null,
    string? Phone = null,
    string? Email = null,
    int? RoleId = null
    );
