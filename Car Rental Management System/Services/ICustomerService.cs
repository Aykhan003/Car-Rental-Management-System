using Car_Rental_Management_System.Data;
using Car_Rental_Management_System.Exceptions;
using Car_Rental_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.Services;

public class ICustomerService
{
    private readonly CarRentalSystemDbContext _context;
    public ICustomerService(CarRentalSystemDbContext context)
    {
        _context = context;
    }
    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _context.Customers.ToListAsync();
    }
    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Customer ID must be greater than zero.");
        }
        if (await _context.Customers.FindAsync(id) == null)
        {
            throw new CustomerNotFoundException("Customer with the specified ID does not exist.");
        }
        return await _context.Customers.FindAsync(id);
    }
    public async Task AddCustomerAsync(Customer customer)
    {
        bool exists = await _context.Customers.AnyAsync(c => c.Email == customer.Email || c.DriverLicenseNumber == customer.DriverLicenseNumber);
        if (exists)
        {
            throw new InvalidOperationException("A customer with the same email or driver's license number already exists.");
        }
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync(); 
    }
    public async Task UpdateCustomerAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteCustomerAsync(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<Rental>> GetRentalsByCustomerIdAsync(int customerId)
    {
        return await _context.Rentals
            .Include(r => r.Car)
            .Include(r => r.Payments)
            .Include(r => r.Penalties)
            .Where(r => r.CustomerId == customerId)
            .ToListAsync();
    }
}
