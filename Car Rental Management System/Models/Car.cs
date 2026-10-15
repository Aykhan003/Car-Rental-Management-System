namespace Car_Rental_Management_System.Models;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string PlateNumber { get; set; } = null!;
    public decimal DailyPrice { get; set; }
    public int Year { get; set; }
    public int Mileage { get; set; }
    public bool IsAvailable { get; set; } = true;
    public List<Rental> Rentals { get; set; } = new List<Rental>();
    public List<PenaltyMaintenanceRecord> PenaltyMaintenanceRecords { get; set; } = new List<PenaltyMaintenanceRecord>();

    public override string ToString()
    {
        return $"{Brand} {Model} ({Year}) - Plate: {PlateNumber}, Daily Price: {DailyPrice:C}, Mileage: {Mileage} km, Available: {IsAvailable}";
    }
}
