namespace CinemaBooking.Infrastructure.SearchFilters.AppUsersAggr;

public record SingleAppUserFilter(
    string? Email,
    string? Phone,
    string? Nickname);