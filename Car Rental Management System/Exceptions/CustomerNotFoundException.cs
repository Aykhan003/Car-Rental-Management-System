namespace Car_Rental_Management_System.Exceptions;

public class CustomerNotFoundException : Exception
{
    public CustomerNotFoundException(int customerId)
        : base($"Customer with ID {customerId} not found.")
    {
    }
}
