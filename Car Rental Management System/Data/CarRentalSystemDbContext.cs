using Car_Rental_Management_System.Models;
using Microsoft.EntityFrameworkCore;

using global::Car_Rental_Management_System.Enums;


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

        // Seed Cars
        modelBuilder.Entity<Car>().HasData(
            new Car { Id = 1, Brand = "Toyota", Model = "Camry", PlateNumber = "AA-001-AA", DailyPrice = 50.00m, Year = 2022, Mileage = 15000, IsAvailable = true },
            new Car { Id = 2, Brand = "Honda", Model = "Civic", PlateNumber = "AA-002-AA", DailyPrice = 45.00m, Year = 2021, Mileage = 25000, IsAvailable = true },
            new Car { Id = 3, Brand = "Ford", Model = "Focus", PlateNumber = "AA-003-AA", DailyPrice = 40.00m, Year = 2020, Mileage = 35000, IsAvailable = true },
            new Car { Id = 4, Brand = "BMW", Model = "X5", PlateNumber = "AA-004-AA", DailyPrice = 80.00m, Year = 2023, Mileage = 8000, IsAvailable = true },
            new Car { Id = 5, Brand = "Mercedes", Model = "C-Class", PlateNumber = "AA-005-AA", DailyPrice = 75.00m, Year = 2022, Mileage = 12000, IsAvailable = true },
            new Car { Id = 6, Brand = "Audi", Model = "A4", PlateNumber = "AA-006-AA", DailyPrice = 70.00m, Year = 2021, Mileage = 20000, IsAvailable = true },
            new Car { Id = 7, Brand = "Hyundai", Model = "Elantra", PlateNumber = "AA-007-AA", DailyPrice = 35.00m, Year = 2020, Mileage = 40000, IsAvailable = true },
            new Car { Id = 8, Brand = "Kia", Model = "Optima", PlateNumber = "AA-008-AA", DailyPrice = 38.00m, Year = 2021, Mileage = 32000, IsAvailable = true },
            new Car { Id = 9, Brand = "Volkswagen", Model = "Golf", PlateNumber = "AA-009-AA", DailyPrice = 42.00m, Year = 2022, Mileage = 18000, IsAvailable = true },
            new Car { Id = 10, Brand = "Mazda", Model = "CX-5", PlateNumber = "AA-010-AA", DailyPrice = 55.00m, Year = 2023, Mileage = 5000, IsAvailable = true }
        );

        // Seed Customers
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, FullName = "John Smith", Email = "john.smith@email.com", DriverLicenseNumber = "DL-001-USA", LicenceExpirationDate = new DateTime(2025, 12, 31) },
            new Customer { Id = 2, FullName = "Jane Doe", Email = "jane.doe@email.com", DriverLicenseNumber = "DL-002-USA", LicenceExpirationDate = new DateTime(2026, 6, 30) },
            new Customer { Id = 3, FullName = "Michael Johnson", Email = "michael.johnson@email.com", DriverLicenseNumber = "DL-003-USA", LicenceExpirationDate = new DateTime(2027, 3, 15) },
            new Customer { Id = 4, FullName = "Sarah Williams", Email = "sarah.williams@email.com", DriverLicenseNumber = "DL-004-USA", LicenceExpirationDate = new DateTime(2025, 9, 20) },
            new Customer { Id = 5, FullName = "Robert Brown", Email = "robert.brown@email.com", DriverLicenseNumber = "DL-005-USA", LicenceExpirationDate = new DateTime(2028, 1, 10) },
            new Customer { Id = 6, FullName = "Emily Davis", Email = "emily.davis@email.com", DriverLicenseNumber = "DL-006-USA", LicenceExpirationDate = new DateTime(2026, 11, 25) },
            new Customer { Id = 7, FullName = "David Miller", Email = "david.miller@email.com", DriverLicenseNumber = "DL-007-USA", LicenceExpirationDate = new DateTime(2024, 8, 30) },
            new Customer { Id = 8, FullName = "Lisa Anderson", Email = "lisa.anderson@email.com", DriverLicenseNumber = "DL-008-USA", LicenceExpirationDate = new DateTime(2027, 5, 12) },
            new Customer { Id = 9, FullName = "James Taylor", Email = "james.taylor@email.com", DriverLicenseNumber = "DL-009-USA", LicenceExpirationDate = new DateTime(2026, 2, 28) },
            new Customer { Id = 10, FullName = "Jennifer Martin", Email = "jennifer.martin@email.com", DriverLicenseNumber = "DL-010-USA", LicenceExpirationDate = new DateTime(2025, 10, 5) }
        );

        // Seed Rentals
        modelBuilder.Entity<Rental>().HasData(
            new Rental { Id = 1, CarId = 1, CustomerId = 1, StartDate = new DateTime(2024, 10, 1), ExpectedReturnDate = new DateTime(2024, 10, 5), ActualReturnDate = new DateTime(2024, 10, 5), DailyPrice = 50.00m, TotalPrice = 200.00m, Status = Status.Available },
            new Rental { Id = 2, CarId = 2, CustomerId = 2, StartDate = new DateTime(2024, 10, 2), ExpectedReturnDate = new DateTime(2024, 10, 7), ActualReturnDate = null, DailyPrice = 45.00m, TotalPrice = 225.00m, Status = Status.Rented },
            new Rental { Id = 3, CarId = 3, CustomerId = 3, StartDate = new DateTime(2024, 9, 25), ExpectedReturnDate = new DateTime(2024, 9, 30), ActualReturnDate = new DateTime(2024, 9, 30), DailyPrice = 40.00m, TotalPrice = 200.00m, Status = Status.Available },
            new Rental { Id = 4, CarId = 4, CustomerId = 4, StartDate = new DateTime(2024, 10, 3), ExpectedReturnDate = new DateTime(2024, 10, 10), ActualReturnDate = null, DailyPrice = 80.00m, TotalPrice = 560.00m, Status = Status.Rented },
            new Rental { Id = 5, CarId = 5, CustomerId = 5, StartDate = new DateTime(2024, 9, 20), ExpectedReturnDate = new DateTime(2024, 9, 25), ActualReturnDate = new DateTime(2024, 9, 25), DailyPrice = 75.00m, TotalPrice = 375.00m, Status = Status.Available },
            new Rental { Id = 6, CarId = 6, CustomerId = 6, StartDate = new DateTime(2024, 10, 4), ExpectedReturnDate = new DateTime(2024, 10, 8), ActualReturnDate = null, DailyPrice = 70.00m, TotalPrice = 280.00m, Status = Status.Rented },
            new Rental { Id = 7, CarId = 7, CustomerId = 7, StartDate = new DateTime(2024, 9, 28), ExpectedReturnDate = new DateTime(2024, 10, 2), ActualReturnDate = new DateTime(2024, 10, 2), DailyPrice = 35.00m, TotalPrice = 140.00m, Status = Status.Available },
            new Rental { Id = 8, CarId = 8, CustomerId = 8, StartDate = new DateTime(2024, 10, 5), ExpectedReturnDate = new DateTime(2024, 10, 12), ActualReturnDate = null, DailyPrice = 38.00m, TotalPrice = 266.00m, Status = Status.Rented },
            new Rental { Id = 9, CarId = 9, CustomerId = 9, StartDate = new DateTime(2024, 9, 15), ExpectedReturnDate = new DateTime(2024, 9, 20), ActualReturnDate = new DateTime(2024, 9, 20), DailyPrice = 42.00m, TotalPrice = 210.00m, Status = Status.Available },
            new Rental { Id = 10, CarId = 10, CustomerId = 10, StartDate = new DateTime(2024, 10, 6), ExpectedReturnDate = new DateTime(2024, 10, 13), ActualReturnDate = null, DailyPrice = 55.00m, TotalPrice = 385.00m, Status = Status.Rented }
        );

        // Seed Payments
        modelBuilder.Entity<Payment>().HasData(
            new Payment { Id = 1, RentalId = 1, Amount = 200.00m, PaymentDate = new DateTime(2024, 10, 5), PaymentType = PaymentType.Advance },
            new Payment { Id = 2, RentalId = 2, Amount = 225.00m, PaymentDate = new DateTime(2024, 10, 7), PaymentType = PaymentType.FinalPayment },
            new Payment { Id = 3, RentalId = 3, Amount = 200.00m, PaymentDate = new DateTime(2024, 9, 30), PaymentType = PaymentType.Advance },
            new Payment { Id = 4, RentalId = 4, Amount = 280.00m, PaymentDate = new DateTime(2024, 10, 8), PaymentType = PaymentType.FinalPayment },
            new Payment { Id = 5, RentalId = 5, Amount = 375.00m, PaymentDate = new DateTime(2024, 9, 25), PaymentType = PaymentType.Advance },
            new Payment { Id = 6, RentalId = 6, Amount = 140.00m, PaymentDate = new DateTime(2024, 10, 8), PaymentType = PaymentType.FinalPayment },
            new Payment { Id = 7, RentalId = 7, Amount = 140.00m, PaymentDate = new DateTime(2024, 10, 2), PaymentType = PaymentType.Advance },
            new Payment { Id = 8, RentalId = 8, Amount = 266.00m, PaymentDate = new DateTime(2024, 10, 10), PaymentType = PaymentType.FinalPayment },
            new Payment { Id = 9, RentalId = 9, Amount = 210.00m, PaymentDate = new DateTime(2024, 9, 20), PaymentType = PaymentType.Penalty },
            new Payment { Id = 10, RentalId = 10, Amount = 385.00m, PaymentDate = new DateTime(2024, 10, 12), PaymentType = PaymentType.FinalPayment }
        );

        // Seed Penalties
        modelBuilder.Entity<Penalty>().HasData(
            new Penalty { Id = 1, RentalId = 1, Reason = "Late return by 2 hours", Amount = 25.00m, IsPaid = true },
            new Penalty { Id = 2, RentalId = 2, Reason = "Fuel not refilled", Amount = 30.00m, IsPaid = false },
            new Penalty { Id = 3, RentalId = 3, Reason = "Minor scratch on bumper", Amount = 50.00m, IsPaid = true },
            new Penalty { Id = 4, RentalId = 4, Reason = "Late return by 1 day", Amount = 80.00m, IsPaid = false },
            new Penalty { Id = 5, RentalId = 5, Reason = "Interior cleaning required", Amount = 40.00m, IsPaid = true },
            new Penalty { Id = 6, RentalId = 6, Reason = "Tire damage", Amount = 60.00m, IsPaid = false },
            new Penalty { Id = 7, RentalId = 7, Reason = "Missing floor mat", Amount = 15.00m, IsPaid = true },
            new Penalty { Id = 8, RentalId = 8, Reason = "Late return by 3 hours", Amount = 35.00m, IsPaid = false },
            new Penalty { Id = 9, RentalId = 9, Reason = "Windshield chip", Amount = 75.00m, IsPaid = true },
            new Penalty { Id = 10, RentalId = 10, Reason = "Excess mileage charge", Amount = 45.00m, IsPaid = false }
        );

        // Seed PenaltyMaintenanceRecords
        modelBuilder.Entity<PenaltyMaintenanceRecord>().HasData(
            new PenaltyMaintenanceRecord { Id = 1, CarId = 1, Description = "Oil change", MaintenanceDate = new DateTime(2024, 9, 15), Cost = 45.00m, NextMaintenanceDate = new DateTime(2025, 3, 15) },
            new PenaltyMaintenanceRecord { Id = 2, CarId = 2, Description = "Tire rotation", MaintenanceDate = new DateTime(2024, 9, 20), Cost = 60.00m, NextMaintenanceDate = new DateTime(2025, 3, 20) },
            new PenaltyMaintenanceRecord { Id = 3, CarId = 3, Description = "Brake inspection", MaintenanceDate = new DateTime(2024, 9, 10), Cost = 80.00m, NextMaintenanceDate = new DateTime(2025, 3, 10) },
            new PenaltyMaintenanceRecord { Id = 4, CarId = 4, Description = "Battery replacement", MaintenanceDate = new DateTime(2024, 8, 30), Cost = 120.00m, NextMaintenanceDate = new DateTime(2025, 8, 30) },
            new PenaltyMaintenanceRecord { Id = 5, CarId = 5, Description = "Transmission fluid change", MaintenanceDate = new DateTime(2024, 9, 25), Cost = 150.00m, NextMaintenanceDate = new DateTime(2025, 3, 25) },
            new PenaltyMaintenanceRecord { Id = 6, CarId = 6, Description = "Air filter replacement", MaintenanceDate = new DateTime(2024, 9, 5), Cost = 35.00m, NextMaintenanceDate = new DateTime(2025, 3, 5) },
            new PenaltyMaintenanceRecord { Id = 7, CarId = 7, Description = "Engine diagnostic", MaintenanceDate = new DateTime(2024, 9, 12), Cost = 100.00m, NextMaintenanceDate = new DateTime(2025, 3, 12) },
            new PenaltyMaintenanceRecord { Id = 8, CarId = 8, Description = "Coolant flush", MaintenanceDate = new DateTime(2024, 9, 18), Cost = 75.00m, NextMaintenanceDate = new DateTime(2025, 3, 18) },
            new PenaltyMaintenanceRecord { Id = 9, CarId = 9, Description = "Spark plug replacement", MaintenanceDate = new DateTime(2024, 9, 22), Cost = 55.00m, NextMaintenanceDate = new DateTime(2025, 3, 22) },
            new PenaltyMaintenanceRecord { Id = 10, CarId = 10, Description = "Alignment check", MaintenanceDate = new DateTime(2024, 9, 28), Cost = 90.00m, NextMaintenanceDate = new DateTime(2025, 3, 28) }
        );
    }

    public DbSet<Car> Cars { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Rental> Rentals { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<PenaltyMaintenanceRecord> PenaltyMaintenanceRecords { get; set; } = null!;
    public DbSet<Penalty> Penalties { get; set; } = null!;
}
