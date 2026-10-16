namespace Car_Rental_Management_System.Exceptions;

public class CarAlreadyReservedException : Exception
{
    public CarAlreadyReservedException(int carId)
        : base($"Car with ID {carId} is already reserved.")
    {
    }
    public CarAlreadyReservedException(string message) : base(message)
    {
    }
}
