using Car_Rental_Management_System.Data;
using Car_Rental_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.Services;

public class IMaintenanceService
{
    private readonly CarRentalSystemDbContext _context;
    public IMaintenanceService(CarRentalSystemDbContext context)
    {
        _context = context;
    }
    public async Task<List<PenaltyMaintenanceRecord>> GetAllMaintenanceRecordsAsync()
    {
        return await _context.PenaltyMaintenanceRecords.ToListAsync();
    }
    public async Task<PenaltyMaintenanceRecord?> GetMaintenanceRecordByIdAsync(int id)
    {
        return await _context.PenaltyMaintenanceRecords.FindAsync(id);
    }
    public async Task<PenaltyMaintenanceRecord> CreateMaintenanceRecordAsync(int carId, DateTime maintenanceDate, string description)
    {
        var car = await _context.Cars.FindAsync(carId);
        if (car == null)
        {
            throw new ArgumentException("Car not found.");
        }
        var maintenanceRecord = new PenaltyMaintenanceRecord
        {
            CarId = carId,
            MaintenanceDate = maintenanceDate,
            Description = description
        };
        _context.PenaltyMaintenanceRecords.Add(maintenanceRecord);
        await _context.SaveChangesAsync();
        return maintenanceRecord;
    }
    public async Task<List<PenaltyMaintenanceRecord>> GetMaintenanceRecordsByCarIdAsync(int carId)
    {
        return await _context.PenaltyMaintenanceRecords
            .Where(m => m.CarId == carId)
            .ToListAsync();
    }
    public async Task<List<PenaltyMaintenanceRecord>> GetMaintenanceRecordsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.PenaltyMaintenanceRecords
            .Where(m => m.MaintenanceDate >= startDate && m.MaintenanceDate <= endDate)
            .ToListAsync();
    }
    public async Task<List<PenaltyMaintenanceRecord>> GetMaintenanceRecordsByDescriptionAsync(string description)
    {
        return await _context.PenaltyMaintenanceRecords
            .Where(m => m.Description.Contains(description))
            .ToListAsync();
    }
    public async Task<List<PenaltyMaintenanceRecord>> GetMaintenanceRecordsByCarIdAndDateRangeAsync(int carId, DateTime startDate, DateTime endDate)
    {
        return await _context.PenaltyMaintenanceRecords
            .Where(m => m.CarId == carId && m.MaintenanceDate >= startDate && m.MaintenanceDate <= endDate)
            .ToListAsync();
    }
    public async Task<List<PenaltyMaintenanceRecord>> GetMaintenanceRecordsByCarIdAndDescriptionAsync(int carId, string description)
    {
        return await _context.PenaltyMaintenanceRecords
            .Where(m => m.CarId == carId && m.Description.Contains(description))
            .ToListAsync();
    }
    public async Task<List<PenaltyMaintenanceRecord>> GetMaintenanceRecordsByDateRangeAndDescriptionAsync(DateTime startDate, DateTime endDate, string description)
    {
        return await _context.PenaltyMaintenanceRecords
            .Where(m => m.MaintenanceDate >= startDate && m.MaintenanceDate <= endDate && m.Description.Contains(description))
            .ToListAsync();
    }
    public async Task<List<PenaltyMaintenanceRecord>> GetMaintenanceRecordsByCarIdAndDateRangeAndDescriptionAsync(int carId, DateTime startDate, DateTime endDate, string description)
    {
        return await _context.PenaltyMaintenanceRecords
            .Where(m => m.CarId == carId && m.MaintenanceDate >= startDate && m.MaintenanceDate <= endDate && m.Description.Contains(description))
            .ToListAsync();
    }
    public async Task<PenaltyMaintenanceRecord> UpdateMaintenanceRecordAsync(int id, DateTime maintenanceDate, string description)
    {
        var maintenanceRecord = await _context.PenaltyMaintenanceRecords.FindAsync(id);
        if (maintenanceRecord == null)
        {
            throw new ArgumentException("Maintenance record not found.");
        }
        maintenanceRecord.MaintenanceDate = maintenanceDate;
        maintenanceRecord.Description = description;
        await _context.SaveChangesAsync();
        return maintenanceRecord;
    }
    public async Task DeleteMaintenanceRecordAsync(int id)
    {
        var maintenanceRecord = await _context.PenaltyMaintenanceRecords.FindAsync(id);
        if (maintenanceRecord == null)
        {
            throw new ArgumentException("Maintenance record not found.");
        }
        _context.PenaltyMaintenanceRecords.Remove(maintenanceRecord);
        await _context.SaveChangesAsync();
    }
    public async Task WithAnApproachingNextMaintenanceDateAsync()
    {
        var today = DateTime.Today;
        var upcomingMaintenanceRecords = await _context.PenaltyMaintenanceRecords
            .Where(m => m.NextMaintenanceDate.HasValue && m.NextMaintenanceDate.Value <= today.AddDays(7))
            .ToListAsync();
        foreach (var record in upcomingMaintenanceRecords)
        {
            // Notify the relevant parties about the upcoming maintenance
            // This could be sending an email, logging, etc.
            Console.WriteLine($"Upcoming maintenance for Car Id: {record.CarId} on {record.NextMaintenanceDate}");
        }
    }
    public async Task CalculateRepairCostsAsync()
    {
        var maintenanceRecords = await _context.PenaltyMaintenanceRecords.ToListAsync();
        foreach (var record in maintenanceRecords)
        {
            // Assuming the cost is calculated based on some business logic
            // For example, we can set a fixed cost or calculate based on the description
            if (record.Description.Contains("engine"))
            {
                record.Cost = 500; // Example cost for engine-related maintenance
            }
            else if (record.Description.Contains("tire"))
            {
                record.Cost = 100; // Example cost for tire-related maintenance
            }
            else
            {
                record.Cost = 200; // Default cost for other maintenance
            }
        }
        await _context.SaveChangesAsync();
    }
}
