using Car_Rental_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.Configuration;

public class PenaltyMaintenanceRecordConfiguration : IEntityTypeConfiguration<PenaltyMaintenanceRecord>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PenaltyMaintenanceRecord> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(p => p.MaintenanceDate)
            .IsRequired();
        builder.Property(p => p.Cost)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.Property(p => p.NextMaintenanceDate)
            .IsRequired(false);

        builder.HasOne(p => p.Car)
            .WithMany(c => c.PenaltyMaintenanceRecords)
            .HasForeignKey(p => p.CarId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
