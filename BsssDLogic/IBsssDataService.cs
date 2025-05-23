using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BsssCommon;

namespace BsssDLogic
{
    public interface IBsssDataService 
    {
        List<Booking> GetAllBookings();
        public void CreateBooking(Booking booking);
        public void UpdateBooking(Booking booking);
        public bool DeleteBooking(Booking booking);
 

    }
}
