using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsssCommon 
{
     public class Booking
    {
         public string Name { get; set; }
         public string Contact { get; set; }
         public DateTime DateTime { get; set; }
         public string Service { get; set; }

         public override string ToString ()
        {
            return $"{Name} | {Contact} | {DateTime:yyyy-MM-dd h:mm tt} | {Service}";
        }
    }
}
