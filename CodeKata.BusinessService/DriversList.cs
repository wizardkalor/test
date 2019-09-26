using System;
using System.Collections.Generic;
using System.IO;
using CodeKata.BusinessEnt;

namespace CodeKata.BusinessImp
{
    public class DriversList
    {
        public List<Driver> CreateList(FileStream file)
        {
            string line = String.Empty;
            List<Driver> drivers = new List<Driver>();

            //readfile one line at a time
            using (System.IO.StreamReader reader = new System.IO.StreamReader(file))
            {
                try
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        //Do work for line
                        string[] trips = line.Split(' ');

                        //First Array Value is Whether the line is for a Driver or for a Trip
                        String lineType = trips[0];
                        if (string.Equals(lineType, @"Driver") && (!(drivers.Contains(new Driver { Name = trips[1] }))))
                        {
                            drivers.Add(GetDriver(line));
                        }
                        else if (string.Equals(lineType, @"Trip"))
                        {
                            if (drivers.Contains(new Driver { Name = trips[1] }))
                            {
                                drivers[drivers.FindIndex(x => x.Name == trips[1])].Trips.Add(AddTrip(line));
                            }
                            else
                            {
                                throw new System.ArgumentException("Trip for Driver not in List", "trips[1]");
                            }
                        }
                        else
                        {
                            throw new System.ArgumentException("Unknown Line Type Definition", "lineType");
                        }
                    }
                    return drivers;
                }
                catch
                {
                    throw new SystemException("Error processing file." + file);
                }
            }
        }

        private Driver GetDriver(string driver)
        {
            string[] splitDriver = driver.Split(' ');

            Driver driver1 = new Driver
            {
                Name = splitDriver[1]
            };
            return driver1;
        }

        private Trip AddTrip(string trip)
        {
            string[] splitTrip = trip.Split(' ');

            Trip trip1 = new Trip
            {
                Name = splitTrip[1],
                StartTime = DateTime.ParseExact(splitTrip[2], "H:mm", null, System.Globalization.DateTimeStyles.None),
                EndTime = DateTime.ParseExact(splitTrip[3], "H:mm", null, System.Globalization.DateTimeStyles.None),
                Distance = Convert.ToDouble(splitTrip[4])
            };
            TimeSpan duration = trip1.EndTime.Subtract(trip1.StartTime);
            trip1.Duration = duration.TotalMinutes;
            return trip1;
        }
    }
}
