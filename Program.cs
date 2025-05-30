// See https://aka.ms/new-console-template for more information




using BsssBLogic;
using System;
using System.Collections.Generic;
using System.Globalization;



namespace BookSerene
{
    public class Program
    {
        static BsssBService bookingService = new BsssBService();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Serene Spa & Salon!");

            bool running = true;
            while (running)
            {
                ShowMenu();
                int userChoice = GetUserChoice();

                switch (userChoice)
                {
                    case 1: ViewServices(); break;
                    case 2: BookAService(); break;
                    case 3: ViewBookings(); break;
                    case 4: SearchBookings(); break;
                    case 5: CancelBooking(); break;
                    case 6: UpdateBooking(); break;
                    case 7:
                        Console.WriteLine("Thank you for choosing Serene Spa & Salon!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n------ Menu ------");
            Console.WriteLine("[1] View Services");
            Console.WriteLine("[2] Book a Service");
            Console.WriteLine("[3] View All Bookings");
            Console.WriteLine("[4] Search Booking by Name");
            Console.WriteLine("[5] Cancel Booking");
            Console.WriteLine("[6] Update Booking");
            Console.WriteLine("[7] Exit");
        }

        static int GetUserChoice()
        {
            Console.Write("\nEnter your choice: ");
            return int.TryParse(Console.ReadLine(), out int choice) ? choice : -1;
        }

        static void ViewServices()
        {
            Console.WriteLine("\nAvailable Services:");
            for (int i = 0; i < bookingService.Services.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {bookingService.Services[i]}");
            }
        }

        static void BookAService()
        {
            Console.Write("\nEnter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your contact info: ");
            string contact = Console.ReadLine();

            Console.Write("Enter booking date and time (yyyy-MM-dd hh:mm tt): ");
            DateTime dateTime;
            while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                Console.WriteLine("Invalid format. Try again (yyyy-MM-dd hh:mm tt): ");
            }

            ViewServices();
            Console.Write("Choose a service (1-6): ");
            int serviceChoice = int.Parse(Console.ReadLine());

            string service = bookingService.Services[serviceChoice - 1];
            bookingService.Book(name, contact, dateTime, service);
            Console.WriteLine("Your booking has been made!");
        }

        static void ViewBookings()
        {
            Console.WriteLine("\n------ All Bookings ------");
            var bookings = bookingService.GetAllBookings();
            if (bookings.Count == 0)
            {
                Console.WriteLine("No bookings found.");
            }
            else
            {
                foreach (var booking in bookings)
                {
                    Console.WriteLine(booking);
                }
            }
        }

        static void SearchBookings()
        {
            Console.Write("\nEnter name to search: ");
            string name = Console.ReadLine();
            var found = bookingService.SearchBookingsByName(name);

            if (found.Count == 0)
            {
                Console.WriteLine("No bookings found.");
            }
            else
            {
                Console.WriteLine("\nSearch Results:");
                foreach (var booking in found)
                {
                    Console.WriteLine(booking);
                }
            }
        }

        static void CancelBooking()
        {
            Console.Write("\nEnter name of booking to cancel: ");
            string name = Console.ReadLine();
            var bookings = bookingService.GetAllBookings();
            var toCancel = bookings.Find(b => b.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            if (toCancel != null)
            {
                bookingService.Cancel(toCancel);
                Console.WriteLine("Booking canceled.");
            }
            else
            {

                Console.WriteLine("Booking not found.");
            }
        }

        static void UpdateBooking()
        {
            Console.Write("\nEnter name of booking to update: ");
            string name = Console.ReadLine();
            var bookings = bookingService.GetAllBookings();
            var toUpdate = bookings.Find(b => b.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            if (toUpdate != null)
            {
                Console.WriteLine("What do you want to update?");
                Console.WriteLine("[1] Date/Time");
                Console.WriteLine("[2] Service");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Enter new date and time (yyyy-MM-dd hh:mm tt): ");
                    DateTime newDate;
                    while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out newDate))
                    {
                        Console.Write("Invalid format. Try again: ");
                    }
                    bookingService.UpdateBooking(toUpdate, toUpdate.Service, newDate);
                    Console.WriteLine("Booking date/time updated.");
                }
                else if (choice == 2)
                {
                    ViewServices();
                    Console.Write("Choose a new service (1-6): ");
                    int serviceChoice = int.Parse(Console.ReadLine());
                    string newService = bookingService.Services[serviceChoice - 1];

                    bookingService.UpdateBooking(toUpdate, newService, toUpdate.DateTime);
                    Console.WriteLine("Booking service updated.");
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }
        }
    }
}


