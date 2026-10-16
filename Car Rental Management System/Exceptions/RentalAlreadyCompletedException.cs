namespace Car_Rental_Management_System.Exceptions;

public class RentalAlreadyCompletedException : Exception
{
    public RentalAlreadyCompletedException(int rentalId)
        : base($"Rental with ID {rentalId} has already been completed.")
    {
    }
    public RentalAlreadyCompletedException(string message) : base(message)
    {
    }
}
