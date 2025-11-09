using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsssCommon
{
    public class EmailSettings
    {
        public string FromName { get; set; }
        public string FromAddress { get; set; } 
        public string ToName { get; set; }
        public string ToAddress { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnableTls { get; set; }

        public bool FromEmail { get; set; }
     }
}
