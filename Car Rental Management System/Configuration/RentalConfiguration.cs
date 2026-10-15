using Car_Rental_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.Configuration;

public class RentalConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Rental> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.StartDate).IsRequired();
        builder.Property(r => r.ExpectedReturnDate).IsRequired();
        builder.Property(r => r.DailyPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(r => r.TotalPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(r => r.Status).IsRequired();

        builder.HasOne(r => r.Customer)
            .WithMany(c => c.Rentals)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Car)
            .WithMany(c => c.Rentals)
            .HasForeignKey(r => r.CarId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(r => r.Payments)
            .WithOne(p => p.Rental)
            .HasForeignKey(p => p.RentalId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(r => r.Penalties)
            .WithOne(p => p.Rental)
            .HasForeignKey(p => p.RentalId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
