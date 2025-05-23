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
        private IBsssDataService bsssDService;

        public BsssDService()
        {
            // bsssDService = new InMemoryDataService();
            bsssDService = new TextFileDataService();
            //bsssDService = new JsonFileDataService();
        }

        public void Create(Booking booking)
        {
            bsssDService.CreateBooking(booking);
        }

        public List<Booking> GetAll()
        {
            return bsssDService.GetAllBookings();
        }

        public bool Delete(Booking booking)
        {
            return bsssDService.DeleteBooking(booking);
        }

        public void Update(Booking booking)
        {
            bsssDService.UpdateBooking(booking);
        }

        public List<Booking> SearchByName(string name)
        {
            return bsssDService.GetAllBookings()
                .Where(b => b.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}