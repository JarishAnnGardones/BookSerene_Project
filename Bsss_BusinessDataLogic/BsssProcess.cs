using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsss_BusinessDataLogic
{
    public class BsssProcess
    {
        public static string reservation = "No Reservation made.";

        public static string[] Services { get; } =
        {
            "Massages",
            "Facials",
            "Body Treatments",
            "Hair Services",
            "Nail Services",
            "Makeup Services"
        };

        public static bool UpdateReservation(int action, string newReservation)
        {
            if (action == 2)
            {
                reservation = newReservation;
                return true;
            }
            else if (action == 3 && reservation != "No Reservation made.")
            {
                reservation = "No Reservation made.";
                return true;
            }
            return false;
        }

        public static string GetReservation()
        {
            return reservation;
        }
    }
}
