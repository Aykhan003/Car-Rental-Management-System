using Car_Rental_Management_System.Data;
using Car_Rental_Management_System.Enums;
using Car_Rental_Management_System.Exceptions;
using Car_Rental_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_Management_System.Services;

public class IPaymentService
{
    private readonly CarRentalSystemDbContext _context;
    
    public IPaymentService(CarRentalSystemDbContext context)
    {
        _context = context;
    }
    public async Task<Payment?> GetPaymentByIdAsync(int id)
    {
        return await _context.Payments.FindAsync(id);
    }
    public async Task<Payment> CreatePaymentAsync(int rentalId, decimal amount, DateTime paymentDate)
    {
        var rental = await _context.Rentals.FindAsync(rentalId);
        if (rental == null)
        {
            throw new ArgumentException("Rental not found.");
        }
        if (amount <= 0)
        {
            throw new ArgumentException("Payment amount must be greater than zero.");
        }
        var payment = new Payment
        {
            RentalId = rentalId,
            Amount = amount,
            PaymentDate = paymentDate
        };
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
        return payment;
    }
    public async Task<List<Payment>> GetPaymentsByRentalIdAsync(int rentalId)
    {
        return await _context.Payments.Where(p => p.RentalId == rentalId).ToListAsync();
    }
    public async Task<List<Payment>> GetAllPaymentsAsync()
    {
        return await _context.Payments.ToListAsync();
    }
    public async Task<Payment> UpdatePaymentAsync(int id, decimal amount, DateTime paymentDate)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null)
        {
            throw new ArgumentException("Payment not found.");
        }
        if (amount <= 0)
        {
            throw new ArgumentException("Payment amount must be greater than zero.");
        }
        payment.Amount = amount;
        payment.PaymentDate = paymentDate;
        await _context.SaveChangesAsync();
        return payment;
    }
    public async Task DeletePaymentAsync(int id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null)
        {
            throw new ArgumentException("Payment not found.");
        }
        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
    }
    public async Task<decimal> GetTotalPaymentsByRentalIdAsync(int rentalId)
    {
        return await _context.Payments.Where(p => p.RentalId == rentalId).SumAsync(p => p.Amount);
    }
    public async Task<decimal> GetTotalPaymentsAsync()
    {
        return await _context.Payments.SumAsync(p => p.Amount);
    }
    public async Task<List<Payment>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Payments.Where(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate).ToListAsync();
    }
    public async Task<List<Payment>> GetPaymentsByCustomerIdAsync(int customerId)
    {
        return await _context.Payments
            .Include(p => p.Rental)
            .Where(p => p.Rental.CustomerId == customerId)
            .ToListAsync();
    }
    public async Task<List<Payment>> GetPaymentsByCarIdAsync(int carId)
    {
        return await _context.Payments
            .Include(p => p.Rental)
            .Where(p => p.Rental.CarId == carId)
            .ToListAsync();
    }
    public async Task<List<Payment>> GetPaymentsByStatusAsync(Status status)
    {
        return await _context.Payments
            .Include(p => p.Rental)
            .Where(p => p.Rental.Status == status)
            .ToListAsync();
    }
    public async Task<List<Payment>> GetPaymentsByAmountRangeAsync(decimal minAmount, decimal maxAmount)
    {
        return await _context.Payments
            .Where(p => p.Amount >= minAmount && p.Amount <= maxAmount)
            .ToListAsync();
    }
    public async Task<Payment> ExceedsPaymentsAsync(int customerId, decimal totalPayments, decimal totalDebt)
    {
        if (totalPayments > totalDebt)
        {
            throw new PaymentsExceedsDebtException($"Total payments ({totalPayments:C}) exceed total debt ({totalDebt:C}) for customer with ID {customerId}.");
        }
        return new Payment
        {
            RentalId = 0,
            Amount = totalPayments,
            PaymentDate = DateTime.Now
        };
    }
}
