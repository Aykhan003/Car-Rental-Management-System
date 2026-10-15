using Car_Rental_Management_System.Data;
using Car_Rental_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.Services;

public class ICarService
{
    private readonly CarRentalSystemDbContext _context;
    public ICarService(CarRentalSystemDbContext context)
    {
        _context = context;
    }
    public async Task<List<Car>> GetAllCarsAsync()
    {
        return await _context.Cars.ToListAsync();
    }
    public async Task<Car?> GetCarByIdAsync(int id)
    {
        return await _context.Cars.FindAsync(id);
    }
    public async Task AddCarAsync(Car car)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateCarAsync(Car car)
    {
        _context.Cars.Update(car);
        await _context.SaveChangesAsync();
    }
    public async Task DeactiveCarAsync(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car != null)
        {
            car.IsAvailable = false;
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<Car>> GetCarByBrandAndModelAsync(string brand, string model)
    {
        var cars = await _context.Cars
            .Where(c => c.Brand == brand && c.Model == model)
            .ToListAsync();
        return cars;
    }
    public async Task<List<Car>> GetCarByPriceRangeAsync(decimal minPrice, decimal maxPrice)
    {
        var cars = await _context.Cars
            .Where(c => c.DailyPrice >= minPrice && c.DailyPrice <= maxPrice)
            .ToListAsync();
        return cars;
    }
    public async Task<List<Car>> GetAvailableCarsAsync()
    {
        var cars = await _context.Cars
            .Where(c => c.IsAvailable)
            .ToListAsync();
        return cars;
    }
    public async Task<List<Car>> GetCarsDueForMaintenanceAsync()
    {
        var cars = await _context.Cars
            .Where(c => c.Mileage >= 10000) // Assuming maintenance is due every 10,000 km
            .ToListAsync();
        return cars;
    }
    public async Task<List<Car>> GetMostRentedCarsAsync()
    {
        var cars = await _context.Cars
            .Include(c => c.Rentals)
            .OrderByDescending(c => c.Rentals.Count)
            .ToListAsync();
        return cars;
    }

}
