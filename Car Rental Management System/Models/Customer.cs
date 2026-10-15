namespace Car_Rental_Management_System.Models;

public class Customer
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string DriverLicenseNumber { get; set; } = null!;
    public DateTime LicenceExpirationDate { get; set; }
    public List<Rental> Rentals { get; set; } = new List<Rental>();
    public override string ToString()
    {
        return $"{FullName} ({Email}) {DriverLicenseNumber} - Expiration: {LicenceExpirationDate}";
    }
}
