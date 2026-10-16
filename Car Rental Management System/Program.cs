using System;

class Program
{
    static void Main()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("========== CAR RENTAL MANAGEMENT SYSTEM ==========");
            Console.WriteLine("1. Manage Cars");
            Console.WriteLine("2. Manage Customers");
            Console.WriteLine("3. Rental Bookings");
            Console.WriteLine("4. View Rentals");
            Console.WriteLine("5. Return Car");
            Console.WriteLine("6. View Reports");
            Console.WriteLine("7. Exit");
            Console.WriteLine("===================================================");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ManageCars();
                    break;
                case "2":
                    ManageCustomers();
                    break;
                case "3":
                    RentalBookings();
                    break;
                case "4":
                    ViewRentals();
                    break;
                case "5":
                    ReturnCar();
                    break;
                case "6":
                    ViewReports();
                    break;
                case "7":
                    isRunning = false;
                    Console.WriteLine("Thank you for using Car Rental Management System!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ManageCars()
    {
        Console.Clear();
        Console.WriteLine("========== MANAGE CARS ==========");
        Console.WriteLine("1. Add Car");
        Console.WriteLine("2. Edit Car");
        Console.WriteLine("3. Delete Car");
        Console.WriteLine("4. View All Cars");
        Console.WriteLine("5. Back to Main Menu");
        Console.Write("Select an option: ");

        string choice = Console.ReadLine();
        // TODO: Implement car management logic
    }

    static void ManageCustomers()
    {
        Console.Clear();
        Console.WriteLine("========== MANAGE CUSTOMERS ==========");
        Console.WriteLine("1. Add Customer");
        Console.WriteLine("2. Edit Customer");
        Console.WriteLine("3. Delete Customer");
        Console.WriteLine("4. View All Customers");
        Console.WriteLine("5. Back to Main Menu");
        Console.Write("Select an option: ");

        string choice = Console.ReadLine();
        // TODO: Implement customer management logic
    }

    static void RentalBookings()
    {
        Console.Clear();
        Console.WriteLine("========== RENTAL BOOKINGS ==========");
        Console.WriteLine("1. Create New Booking");
        Console.WriteLine("2. Cancel Booking");
        Console.WriteLine("3. Back to Main Menu");
        Console.Write("Select an option: ");

        string choice = Console.ReadLine();
        // TODO: Implement booking logic
    }

    static void ViewRentals()
    {
        Console.Clear();
        Console.WriteLine("========== VIEW RENTALS ==========");
        // TODO: Display active rentals
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void ReturnCar()
    {
        Console.Clear();
        Console.WriteLine("========== RETURN CAR ==========");
        // TODO: Implement car return logic
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void ViewReports()
    {
        Console.Clear();
        Console.WriteLine("========== VIEW REPORTS ==========");
        Console.WriteLine("1. Revenue Report");
        Console.WriteLine("2. Car Utilization Report");
        Console.WriteLine("3. Customer Report");
        Console.WriteLine("4. Back to Main Menu");
        Console.Write("Select an option: ");

        string choice = Console.ReadLine();
        // TODO: Implement reports logic
    }
}