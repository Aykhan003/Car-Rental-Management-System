namespace Car_Rental_Management_System.Exceptions;

public class CarNotFoundException : Exception
{
    public CarNotFoundException(int carId)
        : base($"Car with ID {carId} not found.")
    {
    }
}
