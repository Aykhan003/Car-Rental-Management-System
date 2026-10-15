using Car_Rental_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.Configuration;

public class PenaltyConfiguration : IEntityTypeConfiguration<Penalty>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Penalty> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Amount).IsRequired();
        builder.Property(p => p.Reason).IsRequired().HasMaxLength(200);
        builder.Property(p => p.IsPaid).IsRequired();
        
        builder.HasOne(p => p.Rental)
               .WithMany(r => r.Penalties)
               .HasForeignKey(p => p.RentalId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
