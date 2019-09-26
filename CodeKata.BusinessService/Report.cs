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

            var qry = from driver in drivers
                      let name = driver.Name
                      let distance = Convert.ToInt32(driver.Trips.Sum(x => x.Distance))
                      let mph = Convert.ToInt32(driver.Trips.Sum(x => (x.Distance) / (x.Duration / 60)))
                      orderby distance descending
                      where (mph > 5) && (mph < 100)
                      select new Output(name, distance, mph);

            //Write new TextFile for OutPut
            fs = @"C:\GitHub\CodeKata\CodeKataApp\SampleOutput.txt";
            file = TextFile.WriteReport(fs);
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(file))
                {
                    foreach (Output line in qry)
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
