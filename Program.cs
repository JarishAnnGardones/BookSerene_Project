// See https://aka.ms/new-console-template for more information

using System;
using Bsss_BusinessDataLogic;


namespace BookSerene
{
    internal class Program
    {
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
                        Console.WriteLine("\nThank you for choosing Serene Spa & Salon. Have a great day!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
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
            foreach (string service in BsssProcess.Services) 
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
            for (int i = 0; i < BsssProcess.Services.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {BsssProcess.Services[i]}");
            }

            int serviceChoice;
            while (!int.TryParse(Console.ReadLine(), out serviceChoice) || serviceChoice < 1 || serviceChoice > BsssProcess.Services.Length)
            {
                Console.Write($"Invalid choice. Please enter a number between 1 and {BsssProcess.Services.Length}: ");
            }

            string newReservation = $"Reservation for {name} on {dateTime} for {BsssProcess.Services[serviceChoice - 1]}";
            bool success = BsssProcess.UpdateReservation(2, newReservation);

            if (success)
            {
                Console.WriteLine("\nReservation successful!");
            }
            else
            {
                Console.WriteLine("\nReservation failed. Please try again.");
            }
        }

        static void CancelReservation()
        {
            bool success = BsssProcess.UpdateReservation(3, "");
            if (success)
            {
                Console.WriteLine("\nReservation canceled successfully.");
            }
            else
            {
                Console.WriteLine("\nYou have no reservations to cancel.");
            }
        }

        static void ShowCurrentReservation()
        {
            Console.WriteLine($"\nCurrent Reservation: {BsssProcess.GetReservation()}");
        }
    }
}