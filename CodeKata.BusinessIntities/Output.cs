using System;
using System.Collections.Generic;
using System.Text;

namespace CodeKata.BusinessEnt
{
    public class Output : IComparable<Output>
    {
        public String Name { get; set; }

        public Int32 Distance { get; set; }

        public Int32 MPH { get; set; }

        //Default comparer
        public Int32 CompareTo(Output compareOut)
        {
            //            if (compareOut == null)
            //                return 1;
            //            else
            return this.Distance.CompareTo(compareOut.Distance);
        }

        public Output(string name, int distance, int mph)
        {
            Name = name;
            Distance = distance;
            MPH = mph;
        }
    }
}
