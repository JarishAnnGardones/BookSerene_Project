// See https://aka.ms/new-console-template for more information
using System;

namespace BookSerene
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWELCOME TO SERENE SPA & SALON");

            string reservation = "No reservation made.";

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nACTIONS:");
                Console.WriteLine("[1] View Available Services");
                Console.WriteLine("[2] Book a Service");
                Console.WriteLine("[3] Cancel Reservation");
                Console.WriteLine("[4] Exit");

                Console.Write("\nEnter Action: ");
                int userAction;

                while (!int.TryParse(Console.ReadLine(), out userAction))
                {
                    Console.Write("Invalid input. Please enter a valid number: ");
                }

                switch (userAction)
                {
                    case 1:
                        Console.WriteLine("\n AVAILABLE SERVICES ");
                        string[] services = { "Massages", "Facials", "Body Treatments", "Hair Services",
                            "Nail Services", "Makeup services" };
                        foreach (var service in services)
                        {
                            Console.WriteLine($"- {service}");
                        }
                        break;

                    case 2:
                        Console.WriteLine("\n BOOK A SERVICE ");
                        Console.Write("Enter Your Name: ");
                        string fullName = Console.ReadLine();

                        Console.Write("Enter Contact Number: ");
                        string contact = Console.ReadLine();

                        Console.Write("Enter Date & Time (YYYY-MM-DD HH:MM AM|PM): ");
                        string dateTime = Console.ReadLine();

                        Console.WriteLine("\nChoose a Service:");
                        string[] serviceOptions = { "Massages", "Facials", "Body Treatments", "Hair Services", 
                            "Nail Services", "Makeup services" };
                        for (int i = 0; i < serviceOptions.Length; i++)
                        {
                            Console.WriteLine($"[{i + 1}] {serviceOptions[i]}");
                        }

                        Console.Write("Enter Service Number: ");
                        int serviceChoice;
                        while (!int.TryParse(Console.ReadLine(), out serviceChoice) || serviceChoice < 1 || serviceChoice > serviceOptions.Length)
                        {
                            Console.Write("Invalid selection. Please enter a number between 1 and " + serviceOptions.Length + ": ");
                        }

                        reservation = $"Reservation for {fullName} on {dateTime} for {serviceOptions[serviceChoice - 1]}";
                        Console.WriteLine("\nReservation Successful!");
                        break;

                    case 3:
                        Console.WriteLine("\n CANCEL RESERVATION ");
                        if (reservation == "No reservation made.")
                        {
                            Console.WriteLine("No reservations to cancel.");
                        }
                        else
                        {
                            reservation = "No reservation made.";
                            Console.WriteLine("Your reservation has been canceled.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Thank you for making a reservation at Serene Spa & Salon.");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try Again.");
                        break;
                }
            }
        }
    }
}
