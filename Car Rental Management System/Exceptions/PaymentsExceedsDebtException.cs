namespace Car_Rental_Management_System.Exceptions;

public class PaymentsExceedsDebtException : Exception
{
    public PaymentsExceedsDebtException(int customerId, decimal totalPayments, decimal totalDebt)
        : base($"Total payments ({totalPayments:C}) exceed total debt ({totalDebt:C}) for customer with ID {customerId}.")
    {
    }
    public PaymentsExceedsDebtException(string message) : base(message)
    {
    }
}
