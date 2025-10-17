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
        private BsssDService dataService = new BsssDService();

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

            dataService.Create(booking);

            EmailService emailService = new EmailService();
            string subject = "Booking Confirmed!";
            string body = $"[{DateTime.Now:yyyy-MM-dd hh:mm tt}] Hello {booking.Name},\n\n" +
                          $"Your booking for '{booking.Service}' on {booking.DateTime:MMMM dd, yyyy hh:mm tt} " +
                          $"has been successfully confirmed.\n\nThank you for choosing BookSerene!";

            emailService.SendEmail(subject, body);
        }

        public List<string> GetAllBookings()
        {
            var bookings = dataService.GetAll();

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
                EmailService emailService = new EmailService();
                string subject = "Booking Cancelled";
                string body = $"[{DateTime.Now:yyyy-MM-dd hh:mm tt}] Dear {booking.Name},\n\n" +
                              $"Your booking for '{booking.Service}' scheduled on {booking.DateTime:MMMM dd, yyyy hh:mm tt} " +
                              $"has been cancelled as per your request.\n\nWe hope to serve you again soon.";

                emailService.SendEmail(subject, body);
            }

            return result;
        }


        public List<string> SearchBookingsByName(string name)
        {
            var bookings = dataService.SearchByName(name);

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

            EmailService emailService = new EmailService();
            string subject = "Booking Updated!";
            string body = $"[{DateTime.Now:yyyy-MM-dd hh:mm tt}] Hello {booking.Name},\n\n" +
                          $"Your booking has been updated successfully.\n\n" +
                          $"New Service: {booking.Service}\n" +
                          $"New Schedule: {booking.DateTime:MMMM dd, yyyy hh:mm tt}\n\n" +
                          $"Thank you for staying with BookSerene!";

            emailService.SendEmail(subject, body);
            return true;
        }
    }
}
