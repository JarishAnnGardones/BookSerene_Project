using BsssCommon;
using Microsoft.AspNetCore.Mvc;
using BsssBLogic;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<string>> GetAllBookings()
        {
            return Ok(_bookingService.GetAllBookings());
        }

        [HttpPost]
        public ActionResult<bool> BookService([FromBody] Booking booking)
        {
            if (booking == null || string.IsNullOrWhiteSpace(booking.Name))
                return BadRequest(false);

            _bookingService.Book(booking.Name, booking.Contact, booking.DateTime, booking.Service);
            return Ok(true);
        }

        [HttpPatch]
        public ActionResult<bool> UpdateBooking([FromBody] Booking booking)
        {
            if (booking == null) return BadRequest(false);

            bool updated = _bookingService.UpdateBookingByName(booking.Name, booking.Service, booking.DateTime);
            if (!updated) return NotFound(false);

            return Ok(true);
        }

        [HttpDelete]
        public ActionResult<bool> CancelBooking([FromBody] string name)
        {
            bool result = _bookingService.CancelByName(name);
            if (!result) return NotFound(false);

            return Ok(true);
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<string>> SearchBookingsByName(string name)
        {
            return Ok(_bookingService.SearchBookingsByName(name));
        }
    }
}