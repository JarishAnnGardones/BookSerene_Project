using BsssCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;





namespace BsssDLogic
{
    public class InMemoryDataService : IBsssDataService
    {
        private List<Booking> bookings = new List<Booking>();

        public void CreateBooking(Booking booking)
        {
            bookings.Add(booking);
        }

        public List<Booking> GetAllBookings()
        {
            return bookings;
        }

        public void UpdateBooking(Booking booking)
        {
            var existing = bookings.FirstOrDefault(b => b.Contact == booking.Contact && b.DateTime == booking.DateTime);
            if (existing != null)
            {
                existing.Name = booking.Name;
                existing.Service = booking.Service;
            }
        }

        public bool DeleteBooking(Booking booking)
        {
            var toRemove = bookings.FirstOrDefault(b => b.Contact == booking.Contact && b.DateTime == booking.DateTime);
            if (toRemove != null)
            {
                bookings.Remove(toRemove);
                return true;
            }
            return false;
        }
    }
}
