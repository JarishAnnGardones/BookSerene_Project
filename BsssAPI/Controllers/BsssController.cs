using BsssBLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BsssCommon;


namespace BsssAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BsssController : ControllerBase
    {
        private readonly BsssBService bookingService = new BsssBService();

        [HttpGet]
        public IEnumerable <Booking> GetAllBookings ()
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
            var existing = bookingService
       .SearchBookingsByName(booking.Name)
       .FirstOrDefault(b => b.Contact == booking.Contact);

            if (existing == null)
                return false;

            return bookingService.UpdateBooking(existing, booking.Service, booking.DateTime);
        }

        [HttpDelete]
        public bool CancelBooking([FromBody] Booking booking)
        {
            return bookingService.Cancel(booking);
        }

        [HttpGet("search")]
        public IEnumerable<Booking> SearchBookingsByName(string name)
        {
            return bookingService.SearchBookingsByName(name);
        }
    }
}

