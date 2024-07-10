using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Api.Data;

public class CryptoTrackerContext : DbContext
{
    public CryptoTrackerContext(DbContextOptions<CryptoTrackerContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase("CryptoTrackerDb");

        base.OnConfiguring(options);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Email = "bas@admin.nl",
                Password = "Test1234!",
                Name = "Bas van Cleef",
                Language = "nl",
                Token = "1234ABCD!?",
            }
        );

        modelBuilder.Entity<Note>().HasData([
            new Note
            {
                Id = 1,
                Title = "Test",
                Description = "This is a note",
                Date = DateTime.Now.ToShortDateString(),
                Image = "https://via.placeholder.com/150",
                UserId = 1,
            },
            new Note
            {
                Id = 2,
                Title = "Test 2",
                Description = "This my second test note",
                Date = DateTime.Now.ToShortDateString(),
                Image = "https://via.placeholder.com/150",
                UserId = 1,
            },
            new Note
            {
                Id = 3,
                Title = "Test 3",
                Description = "This is the 3rd note",
                Date = DateTime.Now.ToShortDateString(),
                Image = "https://via.placeholder.com/150",
                UserId = 1,
            },
            new Note
            {
                Id = 4,
                Title = "Test 2 4",
                Description = "This my 4th test note",
                Date = DateTime.Now.ToShortDateString(),
                Image = "https://via.placeholder.com/150",
                UserId = 1,
            }
        ]);
    }

    public void EnsureSeedData()
    {
        if (!Users.Any())
        {
            Users.AddRange(
                new User
                {
                    Id = 1,
                    Email = "bas@admin.nl",
                    Password = "Test1234!",
                    Name = "Bas van Cleef",
                    Language = "nl",
                    Token = "1234ABCD!?",
                }
            );

            SaveChanges();
        }

        if (!Notes.Any())
        {
            Notes.AddRange([
                new Note
                {
                    Id = 1,
                    Title = "Test",
                    Description = "This is a note",
                    Date = DateTime.Now.ToShortDateString(),
                    Image = "https://via.placeholder.com/150",
                    UserId = 1,
                },
                new Note
                {
                    Id = 2,
                    Title = "Test 2",
                    Description = "This my second test note",
                    Date = DateTime.Now.ToShortDateString(),
                    Image = "https://via.placeholder.com/150",
                    UserId = 1,
                },
                new Note
                {
                    Id = 3,
                    Title = "Test 3",
                    Description = "This is the 3rd note",
                    Date = DateTime.Now.ToShortDateString(),
                    Image = "https://via.placeholder.com/150",
                    UserId = 1,
                }
            ]);

            SaveChanges();
        }
    }
}