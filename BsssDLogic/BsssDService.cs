using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BsssCommon;



namespace BsssDLogic
{
        public class BsssDService
        {
            private List<Booking> bookings = new List<Booking>();

            public void Create(Booking booking) => bookings.Add(booking);
            public List<Booking> GetAll() => bookings;
            public bool Delete(Booking booking) => bookings.Remove(booking);
            public List<Booking> SearchByName(string name) =>
                bookings.FindAll(b => b.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
