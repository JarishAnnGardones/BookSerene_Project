using BsssCommon;
using BsssDLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BsssBLogic
{
    public class BsssBService
    {

        private readonly BsssDService _dataService;
        private readonly EmailService _emailService;

        public BsssBService(EmailService emailService)
        {
            _dataService = new BsssDService();
            _emailService = emailService;
        }

        public BsssBService()
        {
        }

        public string[] Services = {
            "Massages", "Facials", "Body Treatments", "Hair Services", "Nail Services", "Makeup Services"
        };


        public void Book(string name, string contact, DateTime dateTime, string service)
        {
            var booking = new Booking
            {
                Name = name,
                Contact = contact,
                DateTime = dateTime,
                Service = service
            };

            _dataService.Create(booking);

            string subject = "Booking Confirmed!";
            string body = $"[{DateTime.Now:yyyy-MM-dd hh:mm tt}] Hello {booking.Name},\n\n" +
                          $"Your booking for '{booking.Service}' on {booking.DateTime:MMMM dd, yyyy hh:mm tt} " +
                          $"has been successfully confirmed.\n\nThank you for choosing BookSerene!";

            _emailService.SendEmail(booking.Contact ?? "user@example.com", subject, body);
        }


        public List<string> GetAllBookings()
        {
            var bookings = _dataService.GetAll();
            return bookings.Select(b =>
                $"Name: {b.Name}, Contact: {b.Contact}, Service: {b.Service}, Date: {b.DateTime:MMMM dd, yyyy hh:mm tt}"
            ).ToList();
        }


        public bool UpdateBookingByName(string name, string newService, DateTime newDateTime)
        {
            var booking = _dataService.GetAll()
                .FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (booking == null)
                return false;

            booking.Service = newService;
            booking.DateTime = newDateTime;
            _dataService.Update(booking);

            string subject = "Booking Updated!";
            string body = $"[{DateTime.Now:yyyy-MM-dd hh:mm tt}] Hello {booking.Name},\n\n" +
                          $"Your booking has been updated successfully.\n\n" +
                          $"New Service: {booking.Service}\n" +
                          $"New Schedule: {booking.DateTime:MMMM dd, yyyy hh:mm tt}\n\n" +
                          $"Thank you for staying with BookSerene!";

            _emailService.SendEmail(booking.Contact ?? "user@example.com", subject, body);
            return true;
        }

        public bool CancelByName(string name)
        {
            var booking = _dataService.GetAll()
                .FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (booking == null)
                return false;

            bool result = _dataService.Delete(booking);
            if (result)
            {
                string subject = "Booking Cancelled";
                string body = $"[{DateTime.Now:yyyy-MM-dd hh:mm tt}] Dear {booking.Name},\n\n" +
                              $"Your booking for '{booking.Service}' scheduled on {booking.DateTime:MMMM dd, yyyy hh:mm tt} " +
                              $"has been cancelled.\n\nWe hope to serve you again soon.";

                _emailService.SendEmail(booking.Contact ?? "user@example.com", subject, body);
            }

            return result;
        }


        public List<string> SearchBookingsByName(string name)
        {
            var bookings = _dataService.SearchByName(name);

            return bookings.Select(b =>
                $"Name: {b.Name}, Contact: {b.Contact}, Service: {b.Service}, Date: {b.DateTime:MMMM dd, yyyy hh:mm tt}"
            ).ToList();
        }
    }
}