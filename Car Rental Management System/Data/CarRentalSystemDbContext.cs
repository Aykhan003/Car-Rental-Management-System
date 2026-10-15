using Car_Rental_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.Data;

public class CarRentalSystemDbContext : DbContext
{
    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=CarRentalSystemDb;Trusted_Connection=True;TrustServerCertificate=true;");
        base.OnConfiguring(optionsBuilder);
    }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Rental> Rentals { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<PenaltyMaintenanceRecord> PenaltyMaintenanceRecords { get; set; } = null!;
    public DbSet<Penalty> Penalties { get; set; } = null!;
}
