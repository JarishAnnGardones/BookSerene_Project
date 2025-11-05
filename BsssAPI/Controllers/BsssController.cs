
using BsssCommon;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BsssBLogic;



namespace BsssAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BsssController : ControllerBase
    {
        private readonly BsssBService _bookingService;

        public BsssController(BsssBService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public ActionResult <IEnumerable<string>> GetAllBookings()
        {
            var result = _bookingService.GetAllBookings();
            return Ok(result);
        }


        [HttpPost]
        public bool BookService([FromBody] Booking booking)
        {
            if (booking == null || string.IsNullOrWhiteSpace(booking.Name))
                return false;

            _bookingService.Book(booking.Name, booking.Contact, booking.DateTime, booking.Service);
            return true;

        }

        [HttpPatch]
        public bool UpdateBooking([FromBody] Booking booking)
        {
      
            var existingBookings = _bookingService.SearchBookingsByName(booking.Name);

            if (existingBookings == null || existingBookings.Count == 0)
                return false;

            return _bookingService.UpdateBookingByName(booking.Name, booking.Service, booking.DateTime);
        }

        [HttpDelete]
        public bool CancelBooking([FromBody] string name)
        {
            return _bookingService.CancelByName(name);
        }

        [HttpGet("search")]
        public ActionResult <IEnumerable<string>> SearchBookingsByName(string name)
        {
            var result = _bookingService.SearchBookingsByName(name);
            return Ok(result);
        }
    }
}




