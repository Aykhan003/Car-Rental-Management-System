using Car_Rental_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.Rentals)
               .WithOne(r => r.Car)
               .HasForeignKey(r => r.CarId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.PenaltyMaintenanceRecords)
               .WithOne(p => p.Car)
               .HasForeignKey(p => p.CarId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(c => c.Brand).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Model).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Year).IsRequired();
        builder.Property(c => c.PlateNumber).IsRequired().HasMaxLength(20);
        builder.Property(c => c.DailyPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(c => c.Mileage).IsRequired();
    }
}
