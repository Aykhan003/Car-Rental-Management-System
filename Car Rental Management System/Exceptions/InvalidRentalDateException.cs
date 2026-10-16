namespace Car_Rental_Management_System.Exceptions;

public class InvalidRentalDateException : Exception
{
    public InvalidRentalDateException(DateTime startDate, DateTime endDate)
        : base($"Invalid rental dates. Start date: {startDate}, End date: {endDate}.")
    {
    }
}
