namespace Car_Rental_Management_System.Models;

public class Penalty
{
    public int Id { get; set; }
    public int RentalId { get; set; }
    public Rental Rental { get; set; } = null!;
    public string Reason { get; set; } = null!;
    public decimal Amount { get; set; }
    public bool IsPaid { get; set; } = false;

    public override string ToString()
    {
        return $"Penalty Id: {Id}, Rental Id: {RentalId}, Reason: {Reason}, Amount: {Amount}, Is Paid: {IsPaid}";
    }
}
