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
    public async Task<Rental> ReturnCarAsync(int rentalId, DateTime actualReturnDate)
    {
        var rental = await _context.Rentals.Include(r => r.Car).FirstOrDefaultAsync(r => r.Id == rentalId);
        if (rental == null)
        {
            throw new ArgumentException("Rental not found.");
        }
        if (actualReturnDate < rental.StartDate)
        {
            throw new ArgumentException("Actual return date cannot be before the rental start date.");
        }
        if (rental.Status == Status.Rented)
        {
            throw new InvalidOperationException("Car has already been returned.");
        }
        
        rental.ActualReturnDate = actualReturnDate;
        rental.Status = Status.Rented;
        var overdueDays = (actualReturnDate - rental.ExpectedReturnDate).Days;
        if (overdueDays > 0)
        {
            var penaltyRate = 1.5m; // Example penalty rate
            var penaltyAmount = overdueDays * rental.DailyPrice * penaltyRate;
            rental.TotalPrice += penaltyAmount;
            // Optionally, you can add a record to PenaltyMaintenanceRecords here
        }
        await _context.SaveChangesAsync();
        return rental;
    }
    public async Task<Rental> CancelRentalAsync(int rentalId)
    {
        var rental = await _context.Rentals.FindAsync(rentalId);
        if (rental == null)
        {
            throw new ArgumentException("Rental not found.");
        }
        if (rental.Status != Status.Available)
        {
            throw new InvalidOperationException("Only available rentals can be canceled.");
        }
        if (rental.StartDate <= DateTime.Today)
        {
            throw new InvalidOperationException("Cannot cancel a rental that has already started.");
        }
        if (rental.Status == Status.Rented)
        {
            throw new InvalidOperationException("Cannot cancel a rental that is currently rented.");
        }
        if (rental.Status == Status.Maintenance)
        {
            throw new InvalidOperationException("Cannot cancel a rental that is under maintenance.");
        }
        
        rental.Status = Status.Maintenance; // Assuming canceled rentals are marked as maintenance
        await _context.SaveChangesAsync();
        return rental;
    })
}
