using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaBooking.Class
{
    public class TextLog
    {
        public int RequestId { get; set; }
        public string Summary { get; set; }
        public string SessionId { get; set; }
        public DateTime DateCreated { get; set; }

        public static void Add(object obj)
        {
            Add(obj.JsonSerialize());
        }
        public static void Add(string summary)
        {
            StaticClass.WriteToLog(summary, "TextLog", false, false, false);
        }

    }
}
