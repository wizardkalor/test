using System;
using System.Collections.Generic;
using CodeKata.BusinessEnt;
using CodeKata.Providers;
using System.Text;
using System.IO;
using System.Linq;

namespace CodeKata.BusinessImp
{
    public class Report
    {
        public void CreateReport(List<Driver> drivers)
        {
            //variables
            string fs;
            FileStream file;
            List<Output> report = new List<Output>();

            //where distance = drivers.Any(x => x.Trips.Any(y => y.Name == x.Name).Sum(y => y.Distance))
            var qryRep = from driver in drivers
                         let name = driver.Name
                         let distance = driver.Trips.Any(x => x.Name == driver.Name).Sum(x => Convert.ToInt32(x.Distance))
                         let mph = driver.Trips.Any(x => x.Name).Sum(x => Convert.ToInt32(Convert.ToInt32(x.Distance) / (Convert.ToInt32(x.Duration) / 60)))
                         orderby distance
                         where (mph > 5) (mph < 100)
                         select driver;

//            var rpt = drivers.Any(x => x.Trips.Any(y => y.Name == x.Name).Sum(y => y.Distance))
//                            select driver;

//            foreach (Driver driver in driver)
            {
                //Driver variables
//                Output output = new Output();
//                double distance = 0;
//                double duration = 0;

//                output.Name = driver.Name;

                //Sum the Distance and Duration of all trips under a driver
//                foreach (Trip trip in driver.Trips)
//                {
//                    distance += trip.Distance;
//                    duration += trip.Duration;
                }
//                output.Distance = Convert.ToInt32(distance);

                //Calulate mph (Distance/Duration) remember to account for Distance = zero. Round(Convert) mph to nearest integer
//                if (distance != 0)
//                {
//                    output.MPH = Convert.ToInt32(distance / (duration / 60));
//                }

                //Remove any mph greater than 100 or less than 5. Round Distance to nearest integer

//                if (output.MPH > 5 && output.MPH < 100)
//                {
//                    report.Add(output);
//                }

//            }

            //Sort by Distance most to least
//            report.Reverse();

            //Write new TextFile for OutPut
            fs = @":\GitHub\CodeKata\CodeKataApp\SampleOutput.txt";
            file = TextFile.WriteReport(fs);
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(file))
                {
                    foreach (Output line in report)
                    {
                        writer.WriteLine($"{ line.Name }:  { line.Distance } miles @ { line.MPH } mph");
                    }
                }
            }
            finally
            {
                file.Close();
            }
        }
    }
}
