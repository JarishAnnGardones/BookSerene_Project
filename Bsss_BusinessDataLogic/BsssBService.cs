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
        }

        public List<Booking> GetAllBookings() => dataService.GetAll();

        public bool Cancel(Booking booking) => dataService.Delete(booking);

        public List<Booking> SearchBookingsByName(string name) => dataService.SearchByName(name);

        public bool UpdateBooking(Booking oldBooking, string newService, DateTime newDateTime)
        {
            oldBooking.Service = newService;
            oldBooking.DateTime = newDateTime;
            dataService.Update(oldBooking);
            return true;
        }
    }
}