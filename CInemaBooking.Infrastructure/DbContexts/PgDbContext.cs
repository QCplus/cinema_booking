using CinemaBooking.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBooking.Infrastructure.DbContexts;

internal class PgDbContext : AppDbContext
{
    public PgDbContext(DbContextOptions options) : base(options)
    {
        
    }

    private void Configure(EntityTypeBuilder<AppUserRole> builder)
    {
        builder
            .ToTable("app_user_role")
            .HasData(
                new AppUserRole()
                {
                    Id = 1,
                    Name = "Admin"
                }
            );

        builder.HasKey(t => t.Id);
    }

    private void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder
            .ToTable("app_user")
            .HasData(
            new AppUser()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Phone = "12345678901",
                RoleId = 1,
                PasswordHash = "23ef",
                Nickname = "admin"
            });

        builder.HasKey(t => t.Id);
    }

    private void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("room");
        builder
            .HasMany(r => r.BookedSeats)
            .WithOne(s => s.Room)
            .HasForeignKey(s => s.RoomId).OnDelete(DeleteBehavior.Cascade);
        builder
            .HasMany(r => r.MovieSessions)
            .WithOne(s => s.Room)
            .HasForeignKey(s => s.RoomId).OnDelete(DeleteBehavior.Cascade);
        builder.HasKey(t => t.Id);
    }

    private void Configure(EntityTypeBuilder<BookedSeat> builder)
    {
        builder
            .ToTable("booked_seat")
            ;
        builder.HasKey(s => s.Id);
        builder.HasIndex(nameof(BookedSeat.RoomId), nameof(BookedSeat.Index)).IsUnique();
    }

    private void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder
            .ToTable("movie")
            .HasMany(m => m.MovieSessions)
            .WithOne(s => s.Movie)
            .HasForeignKey(s => s.MovieId).OnDelete(DeleteBehavior.Cascade);
        builder.HasKey(t => t.Id);
    }

    private void Configure(EntityTypeBuilder<MovieSession> builder)
    {
        builder.ToTable("movie_session");
        builder.HasKey(s => s.Id);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Configure(modelBuilder.Entity<AppUserRole>());
        Configure(modelBuilder.Entity<AppUser>());
        Configure(modelBuilder.Entity<Room>());
        Configure(modelBuilder.Entity<BookedSeat>());
        Configure(modelBuilder.Entity<Movie>());
        Configure(modelBuilder.Entity<MovieSession>());
    }
}
