using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Entities.Abstract
{
    public class CalendarJs
    {
        public string title { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public string url { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
    }
}
