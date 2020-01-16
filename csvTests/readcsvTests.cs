using Cities;
using Csv;
using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace csv.Tests
{
    [TestClass()]
    public class ReadcsvTests
    {
        [TestMethod()]
        public void ReadInCSVTest()
        {
            var path = "c://csvfiles//worldcities.csv";
            var doubleTypeConversion = new DoubleConversion();
            IList<CityModel> myList = ReadCsv.ReadCsvFile<CityModel, CityMap>(path, doubleTypeConversion);
            var countryCapitalQuery = (from s in myList
                           where s.Capital.Equals("primary")
                           orderby s.Country ascending
                           select s).Take(10);

            var QSCount = (from city in countryCapitalQuery
                           select city).Count();

            foreach (CityModel city in countryCapitalQuery)
            {
                Debug.Write(city.Country + ": " + city.City_name + Environment.NewLine);
            }

            Assert.AreEqual(10, QSCount);
        }
    }
}