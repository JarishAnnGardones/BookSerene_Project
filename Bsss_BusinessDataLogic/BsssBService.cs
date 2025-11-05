using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BsssDLogic;
using BsssCommon;



namespace BsssBLogic
{
    public class BsssBService
    {
            BsssDService dataService = new BsssDService();
            private readonly EmailService _emailService;

            public BsssBService(EmailService emailService)
            {
                _emailService = emailService;
            }
        public string[] Services = {
            "Massages", "Facials", "Body Treatments", "Hair Services", "Nail Services", "Makeup Services"
        };
        public bool Book(string name, string contact, DateTime dateTime, string service)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(service))
                return false;

            var booking = new Booking
            {
                Name = name,
                Contact = contact,
                DateTime = dateTime,
                Service = service
            };

            dataService.Create(booking);

            string subject = "Booking Confirmed!";
            string body = $"[{DateTime.Now:yyyy-MM-dd hh:mm tt}] Hello {booking.Name},\n\n" +
                          $"Your booking for '{booking.Service}' on {booking.DateTime:MMMM dd, yyyy hh:mm tt} " +
                          $"has been successfully confirmed.\n\nThank you for choosing BookSerene!";

            _emailService.SendEmail(booking.Contact ?? "sample@example.com", subject, body);
            return true;
        }

        public List<string> GetAllBookings()
        {
            var bookings = dataService.GetAll() ?? new List<Booking>();
            return bookings.Select(b =>
                $"Name: {b.Name}, Contact: {b.Contact}, Service: {b.Service}, Date: {b.DateTime:MMMM dd, yyyy hh:mm tt}"
            ).ToList();
        }

        public bool CancelByName(string name)
        {
            var booking = dataService.GetAll()
                .FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (booking == null)
                return false;

            bool result = dataService.Delete(booking);

            if (result)
            {
                string subject = "Booking Cancelled";
                string body = $"[{DateTime.Now:yyyy-MM-dd hh:mm tt}] Dear {booking.Name},\n\n" +
                              $"Your booking for '{booking.Service}' scheduled on {booking.DateTime:MMMM dd, yyyy hh:mm tt} " +
                              $"has been cancelled as per your request.\n\nWe hope to serve you again soon.";

                _emailService.SendEmail(booking.Contact ?? "sample@example.com", subject, body);
            }

            return result;
        }

        public List<string> SearchBookingsByName(string name)
        {
            var bookings = dataService.SearchByName(name) ?? new List<Booking>();
            return bookings.Select(b =>
                $"Name: {b.Name}, Contact: {b.Contact}, Service: {b.Service}, Date: {b.DateTime:MMMM dd, yyyy hh:mm tt}"
            ).ToList();
        }

        public bool UpdateBookingByName(string name, string newService, DateTime newDateTime)
        {
            var booking = dataService.GetAll()
                .FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (booking == null)
                return false;

            booking.Service = newService;
            booking.DateTime = newDateTime;
            dataService.Update(booking);

            string subject = "Booking Updated!";
            string body = $"[{DateTime.Now:yyyy-MM-dd hh:mm tt}] Hello {booking.Name},\n\n" +
                          $"Your booking has been updated successfully.\n\n" +
                          $"New Service: {booking.Service}\n" +
                          $"New Schedule: {booking.DateTime:MMMM dd, yyyy hh:mm tt}\n\n" +
                          $"Thank you for staying with BookSerene!";

            _emailService.SendEmail(booking.Contact ?? "sample@example.com", subject, body);
            return true;
        }
    }
}
