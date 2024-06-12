using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Api.Data;

public class CryptoTrackerContext : DbContext
{
    public CryptoTrackerContext(DbContextOptions<CryptoTrackerContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    
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
                Password = "admin",
                Name = "Bas van Cleef",
                FirstName = "Bas",
                LastName = "van Cleef",
                Phone = "0612345678",
                Address = "Teststraat 1",
                City = "Test",
                ZipCode = "1234 AB",
                Country = "Netherlands",
                DateOfBirth = "01-01-2000",
                Language = "nl",
                Token = "1234ABCD!?",
            }
        );
    }
    
    public void EnsureSeedData()
    {
        if (!Users.Any()) { }
    }
}