using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Car_Rental_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "DailyPrice", "IsAvailable", "Mileage", "Model", "PlateNumber", "Year" },
                values: new object[,]
                {
                    { 1, "Toyota", 50.00m, true, 15000, "Camry", "AA-001-AA", 2022 },
                    { 2, "Honda", 45.00m, true, 25000, "Civic", "AA-002-AA", 2021 },
                    { 3, "Ford", 40.00m, true, 35000, "Focus", "AA-003-AA", 2020 },
                    { 4, "BMW", 80.00m, true, 8000, "X5", "AA-004-AA", 2023 },
                    { 5, "Mercedes", 75.00m, true, 12000, "C-Class", "AA-005-AA", 2022 },
                    { 6, "Audi", 70.00m, true, 20000, "A4", "AA-006-AA", 2021 },
                    { 7, "Hyundai", 35.00m, true, 40000, "Elantra", "AA-007-AA", 2020 },
                    { 8, "Kia", 38.00m, true, 32000, "Optima", "AA-008-AA", 2021 },
                    { 9, "Volkswagen", 42.00m, true, 18000, "Golf", "AA-009-AA", 2022 },
                    { 10, "Mazda", 55.00m, true, 5000, "CX-5", "AA-010-AA", 2023 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DriverLicenseNumber", "Email", "FullName", "LicenceExpirationDate" },
                values: new object[,]
                {
                    { 1, "DL-001-USA", "john.smith@email.com", "John Smith", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "DL-002-USA", "jane.doe@email.com", "Jane Doe", new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "DL-003-USA", "michael.johnson@email.com", "Michael Johnson", new DateTime(2027, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "DL-004-USA", "sarah.williams@email.com", "Sarah Williams", new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "DL-005-USA", "robert.brown@email.com", "Robert Brown", new DateTime(2028, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "DL-006-USA", "emily.davis@email.com", "Emily Davis", new DateTime(2026, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "DL-007-USA", "david.miller@email.com", "David Miller", new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "DL-008-USA", "lisa.anderson@email.com", "Lisa Anderson", new DateTime(2027, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "DL-009-USA", "james.taylor@email.com", "James Taylor", new DateTime(2026, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "DL-010-USA", "jennifer.martin@email.com", "Jennifer Martin", new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PenaltyMaintenanceRecords",
                columns: new[] { "Id", "CarId", "Cost", "Description", "MaintenanceDate", "NextMaintenanceDate" },
                values: new object[,]
                {
                    { 1, 1, 45.00m, "Oil change", new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 60.00m, "Tire rotation", new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 80.00m, "Brake inspection", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, 120.00m, "Battery replacement", new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, 150.00m, "Transmission fluid change", new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, 35.00m, "Air filter replacement", new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, 100.00m, "Engine diagnostic", new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, 75.00m, "Coolant flush", new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9, 55.00m, "Spark plug replacement", new DateTime(2024, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 10, 90.00m, "Alignment check", new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "ActualReturnDate", "CarId", "CustomerId", "DailyPrice", "ExpectedReturnDate", "StartDate", "Status", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 50.00m, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 200.00m },
                    { 2, null, 2, 2, 45.00m, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 225.00m },
                    { 3, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 40.00m, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 200.00m },
                    { 4, null, 4, 4, 80.00m, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 560.00m },
                    { 5, new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, 75.00m, new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 375.00m },
                    { 6, null, 6, 6, 70.00m, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 280.00m },
                    { 7, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 7, 35.00m, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 140.00m },
                    { 8, null, 8, 8, 38.00m, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 266.00m },
                    { 9, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 9, 42.00m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 210.00m },
                    { 10, null, 10, 10, 55.00m, new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 385.00m }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "PaymentDate", "PaymentType", "RentalId" },
                values: new object[,]
                {
                    { 1, 200.00m, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 },
                    { 2, 225.00m, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, 200.00m, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3 },
                    { 4, 280.00m, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 5, 375.00m, new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5 },
                    { 6, 140.00m, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6 },
                    { 7, 140.00m, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7 },
                    { 8, 266.00m, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8 },
                    { 9, 210.00m, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 9 },
                    { 10, 385.00m, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Penalties",
                columns: new[] { "Id", "Amount", "IsPaid", "Reason", "RentalId" },
                values: new object[,]
                {
                    { 1, 25.00m, true, "Late return by 2 hours", 1 },
                    { 2, 30.00m, false, "Fuel not refilled", 2 },
                    { 3, 50.00m, true, "Minor scratch on bumper", 3 },
                    { 4, 80.00m, false, "Late return by 1 day", 4 },
                    { 5, 40.00m, true, "Interior cleaning required", 5 },
                    { 6, 60.00m, false, "Tire damage", 6 },
                    { 7, 15.00m, true, "Missing floor mat", 7 },
                    { 8, 35.00m, false, "Late return by 3 hours", 8 },
                    { 9, 75.00m, true, "Windshield chip", 9 },
                    { 10, 45.00m, false, "Excess mileage charge", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Penalties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Penalties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Penalties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Penalties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Penalties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Penalties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Penalties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Penalties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Penalties",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Penalties",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PenaltyMaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PenaltyMaintenanceRecords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PenaltyMaintenanceRecords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PenaltyMaintenanceRecords",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PenaltyMaintenanceRecords",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PenaltyMaintenanceRecords",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PenaltyMaintenanceRecords",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PenaltyMaintenanceRecords",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PenaltyMaintenanceRecords",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PenaltyMaintenanceRecords",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
