namespace Car_Rental_Management_System.Exceptions;

public class LicenseExpiredException : Exception
{
    public LicenseExpiredException(int customerId)
        : base($"Customer with ID {customerId} has an expired license.")
    {
    }
    public LicenseExpiredException(string message) : base(message)
    {
    }
}
