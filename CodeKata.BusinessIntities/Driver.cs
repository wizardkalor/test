using System;
using System.Collections.Generic;

namespace CodeKata.BusinessEnt
{
    public class Driver : IEquatable<Driver>
    {
        public String Name { get; set; }

        public List<Trip> Trips { get; set; }

        public Driver()
        {
            Trips = new List<Trip>();
        }

        public bool Equals(Driver driver)
        {
            if (driver == null) return false;
            return (this.Name.Equals(driver.Name));
        }
    }
}
