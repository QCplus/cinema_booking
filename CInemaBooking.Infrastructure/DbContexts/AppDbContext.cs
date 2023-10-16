using CinemaBooking.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Infrastructure.DbContexts;

public abstract class AppDbContext : DbContext
{
    public DbSet<AppUserRole> UserRoles => Set<AppUserRole>();

    public DbSet<AppUser> Users => Set<AppUser>();

    public DbSet<Room> Rooms => Set<Room>();

    public DbSet<Movie> Movies => Set<Movie>();

    public DbSet<MovieSession> MovieSessions => Set<MovieSession>();

    public AppDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}
