// See https://aka.ms/new-console-template for more information
using System;

namespace BookSerene
{
    internal class Program
    {
        static string reservation = "No reservation made.";
        static string[] services = { "Massages", "Facials", "Body Treatments", "Hair Services", "Nail Services", "Makeup services" };

        static void Main(string[] args)
        {
            Console.WriteLine("\nWelcome to Serene Spa & Salon!");

            bool running = true;
            while (running)
            {
                ShowMenu();
                int choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        ShowAvailableServices();
                        break;
                    case 2:
                        BookService();
                        break;
                    case 3:
                        CancelReservation();
                        break;
                    case 4:
                        running = false;
                        Console.WriteLine("Thank you for choosing Serene Spa & Salon. Have a great day!!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }


        static void ShowMenu()
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("[1] View Available Services");
            Console.WriteLine("[2] Book a Service");
            Console.WriteLine("[3] Cancel Reservation");
            Console.WriteLine("[4] Exit");
        }


        static int GetUserChoice()
        {
            Console.Write("\nEnter your choice: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid input. Please enter a number: ");
            }
            return choice;
        }


        static void ShowAvailableServices()
        {
            Console.WriteLine("\nAvailable Services:");
            foreach (var service in services)
            {
                Console.WriteLine($"- {service}");
            }
        }


        static void BookService()
        {
            Console.WriteLine("\nBooking a Service");

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your contact number: ");
            string contact = Console.ReadLine();

            Console.Write("Enter date & time (YYYY-MM-DD HH:MM AM/PM): ");
            string dateTime = Console.ReadLine();

            Console.WriteLine("\nChoose a service:");
            for (int i = 0; i < services.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {services[i]}");
            }

            int serviceChoice;
            while (!int.TryParse(Console.ReadLine(), out serviceChoice) || serviceChoice < 1 || serviceChoice > services.Length)
            {
                Console.Write($"Invalid choice. Please enter a number between 1 and {services.Length}: ");
            }

            reservation = $"Reservation for {name} on {dateTime} for {services[serviceChoice - 1]}";
            Console.WriteLine("\nReservation successful!");
        }


        static void CancelReservation()
        {
            Console.WriteLine("\nCanceling Reservation");
            if (reservation == "No reservation made.")
            {
                Console.WriteLine("You have no reservations to cancel.");
            }
            else
            {
                reservation = "No reservation made.";
                Console.WriteLine("Reservation canceled successfully.");
            }
        }


        static void UpdateReservation(int action, string newReservation)
        {
            if (action == 2)
            {
                reservation = newReservation;
            }
            else if (action == 3)
            {
                reservation = "No reservation made.";
            }
        }


        static void ShowCurrentReservation()
        {
            Console.WriteLine($"\nCurrent Reservation: {reservation}");
        }
    }
}
