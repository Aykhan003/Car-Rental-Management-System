using Car_Rental_Management_System.Data;
using Car_Rental_Management_System.Enums;
using Car_Rental_Management_System.Models;
using Microsoft.EntityFrameworkCore;
namespace Car_Rental_Management_System.Services;

public class IRentalService
{
    private readonly CarRentalSystemDbContext _context;

    public IRentalService(CarRentalSystemDbContext context)
    {
        _context = context;
    }
    public async Task<List<Rental>> GetAllRentalsAsync()
    {
        return await _context.Rentals.ToListAsync();
    }
    public async Task<Rental?> GetRentalByIdAsync(int id)
    {
        return await _context.Rentals.FindAsync(id);
    }
    public async Task<Rental> CreateRentalAsync(int carId, int customerId, DateTime rentalDate, DateTime returnDate)
    {
        if (rentalDate >= returnDate)
        {
            throw new ArgumentException("Return date must be after rental date.");
        }
        if (rentalDate < DateTime.Today)
        {
            throw new ArgumentException("Rental date cannot be in the past.");
        }
        var car = await _context.Cars.Include(c => c.PenaltyMaintenanceRecords).FirstOrDefaultAsync(c => c.Id == carId);
        if (car == null)
        {
            throw new ArgumentException("Car not found.");
        }
        if (!car.IsAvailable)
        {
            throw new InvalidOperationException("Car is not available for rental.");
        }
        var customer = await _context.Customers.FindAsync(customerId);
        if (customer == null)
        {
            throw new ArgumentException("Customer not found.");
        }
        var hasOverLap = await _context.Rentals.AnyAsync(r => r.CarId == carId && r.Status == Status.Available && r.StartDate < returnDate && r.ExpectedReturnDate > rentalDate);
        if (hasOverLap)
        {
            throw new InvalidOperationException("Car is already rented for the selected period.");
        }
        var maintenanceDue = car.PenaltyMaintenanceRecords.Any(m => m.MaintenanceDate <= rentalDate);
        if (maintenanceDue)
        {
            throw new InvalidOperationException("Car is under maintenance or has a penalty for the selected period.");
        }
        var rental = new Rental
        {
            CarId = carId,
            CustomerId = customerId,
            StartDate = rentalDate,
            ExpectedReturnDate = returnDate,
            DailyPrice = car.DailyPrice,
            TotalPrice = car.DailyPrice * (decimal)(returnDate - rentalDate).TotalDays,
            Status = Status.Available
        };
        _context.Rentals.Add(rental);
        await _context.SaveChangesAsync();
        return rental;
    }
}
