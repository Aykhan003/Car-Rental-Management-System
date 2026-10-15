using Car_Rental_Management_System.Enums;

namespace Car_Rental_Management_System.Models;

public class Rental
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; } = null!;
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime ExpectedReturnDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public decimal DailyPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public Status Status { get; set; } = Status.Rented;
    public List<Payment> Payments { get; set; } = new List<Payment>();
    public List<Penalty> Penalties { get; set; } = new List<Penalty>();
    public override string ToString()
    {
        return $"Rental Id: {Id}, Car Id: {CarId}, Customer Id: {CustomerId}, Start Date: {StartDate}, Expected Return Date: {ExpectedReturnDate}, Actual Return Date: {ActualReturnDate}, Daily Price: {DailyPrice}, Total Price: {TotalPrice}, Status: {Status}";
    }
}
