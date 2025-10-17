using BsssBLogic;
using BsssCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace BsssAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BsssController : ControllerBase
    {
        private readonly BsssBService bookingService = new BsssBService();

        [HttpGet]
        public IEnumerable<string> GetAllBookings()
        {
            return bookingService.GetAllBookings();
        }


        [HttpPost]
        public bool BookService([FromBody] Booking booking)
        {
            if (booking == null || string.IsNullOrWhiteSpace(booking.Name))
                return false;

            bookingService.Book(booking.Name, booking.Contact, booking.DateTime, booking.Service);
            return true;

        }

        [HttpPatch]
        public bool UpdateBooking([FromBody] Booking booking)
        {
            
            var existingBookings = bookingService.SearchBookingsByName(booking.Name);

            if (existingBookings == null || existingBookings.Count == 0)
                return false;

            return bookingService.UpdateBookingByName(booking.Name, booking.Service, booking.DateTime);
        }

        [HttpDelete]
        public bool CancelBooking([FromBody] string name)
        {
            return bookingService.CancelByName(name);
        }

        [HttpGet("search")]
        public IEnumerable<string> SearchBookingsByName(string name)
        {
            return bookingService.SearchBookingsByName(name);
        }
    }
}

