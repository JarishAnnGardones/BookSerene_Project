using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BsssCommon;




namespace BsssDLogic
{
    public class TextFileDataService : IBsssDataService
    {
        private static string filePath = "bsss.txt";
        private List<Booking> bookings = new List<Booking>();
        private char delimiter = '|';

        public TextFileDataService()
        {
            LoadFromText();
        }

        private void LoadFromText()
        {
            bookings.Clear();

            if (!File.Exists(filePath)) return;

            var lines = File.ReadAllLines(filePath);
            bookings = lines.Select(line =>
            {
                var parts = line.Split(delimiter);
                if (parts.Length == 4)
                {
                    return new Booking
                    {
                        Name = parts[0].Trim(),
                        Contact = parts[1].Trim(),
                        DateTime = DateTime.Parse(parts[2].Trim()),
                        Service = parts[3].Trim()
                    };
                }
                return null;
            }).Where(b => b != null).ToList();
        }

        private void SaveToText()
        {
            var lines = bookings.Select(b =>
                $"{b.Name}{delimiter}{b.Contact}{delimiter}{b.DateTime:O}{delimiter}{b.Service}");

            File.WriteAllLines(filePath, lines);
            Console.WriteLine($"Saved TXT to: {Path.GetFullPath("bsss.txt")}");
        }

        public void CreateBooking(Booking booking)
        {
            bookings.Add(booking);
            SaveToText();
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
                SaveToText();
            }
        }


        public bool DeleteBooking(Booking booking)
        {
            var toRemove = bookings.FirstOrDefault(b => b.Contact == booking.Contact);
            if (toRemove != null)
            {
                bookings.Remove(toRemove);
                SaveToText();
                return true;
            }
            return false;
        }
    }
}
