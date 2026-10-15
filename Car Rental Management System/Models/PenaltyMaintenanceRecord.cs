namespace Car_Rental_Management_System.Models;

public class PenaltyMaintenanceRecord
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime MaintenanceDate { get; set; }
    public decimal Cost { get; set; }
    public DateTime? NextMaintenanceDate { get; set; }
    public override string ToString()
    {
        return $"Penalty Maintenance Record Id: {Id}, Car Id: {CarId}, Description: {Description}, Maintenance Date: {MaintenanceDate}, Cost: {Cost}, Next Maintenance Date: {NextMaintenanceDate}";
    }
}
