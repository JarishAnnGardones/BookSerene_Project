using BsssCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;


namespace BsssDLogic
{
    public class JsonFileDataService : IBsssDataService
    {
        private string jsonFilePath = "bsss.json";
        private List<Booking> bookings = new List<Booking>();

        public JsonFileDataService()
        {
            LoadFromJson();
        }

        private void LoadFromJson()
        {
            if (!File.Exists(jsonFilePath)) return;

            var json = File.ReadAllText(jsonFilePath);
            bookings = JsonSerializer.Deserialize<List<Booking>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Booking>();
        }

        private void SaveToJson()
        {
            var json = JsonSerializer.Serialize(bookings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, json);
            Console.WriteLine($"Saved JSON to: {Path.GetFullPath("bsss.json")}");
        }

        public void CreateBooking(Booking booking)
        {
            bookings.Add(booking);
            SaveToJson();
        }

        public List<Booking> GetAllBookings()
        {
            return bookings;
        }

        public void UpdateBooking(Booking updatedBooking)
        {
            var existing = bookings.FirstOrDefault(b => b.Contact == updatedBooking.Contact);
            if (existing != null)
            {
                existing.Name = updatedBooking.Name;
                existing.Service = updatedBooking.Service;
                existing.DateTime = updatedBooking.DateTime;
                SaveToJson();
            }
        }

        public bool DeleteBooking(Booking booking)
        {
            var toRemove = bookings.FirstOrDefault(b => b.Contact == booking.Contact);
            if (toRemove != null)
            {
                bookings.Remove(toRemove);
                SaveToJson();
                return true;
            }
            return false;
        }
    }
}

