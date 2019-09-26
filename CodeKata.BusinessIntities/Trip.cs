using System;
using System.Collections.Generic;
using System.Text;

namespace CodeKata.BusinessEnt
{
    public class Trip
    {
        public String Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Double Distance { get; set; }

        public Double Duration { get; set; }
    }
}
