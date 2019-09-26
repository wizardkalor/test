using System;
using System.IO;
using System.Collections.Generic;
using CodeKata.Providers;
using CodeKata.BusinessEnt;
using CodeKata.BusinessImp;

namespace CodeKataApp
{
    class Program
    {
        static void Main()
        {
            //variable Declarations
            string fs;
            FileStream file;
            DriversList driversList = new DriversList();
            Report report = new Report();

            //open file
            //the actual file name should be dependency injection
            fs = @"C:\GitHub\CodeKata\CodeKataApp\SampleInput.txt";
            file = TextFile.OpenFile(fs);
            try
            {
                //Process the file into List of Drivers
                List<Driver> drivers = driversList.CreateList(file);

                //Create Report File from List of Drivers
                report.CreateReport(drivers);
            }
            finally
            {
                //close file
                file.Close();
            }
        }
    }
}
