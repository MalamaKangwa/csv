using Microsoft.VisualStudio.TestTools.UnitTesting;
using Csv;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Cities;
using System.Diagnostics;

namespace Csv.Tests
{
    [TestClass()]
    public class WritecsvTests
    {
        [TestMethod()]
        public void WriteInCSVTest()
        {
            var readPath = "c://csvfiles//worldcities.csv";

            var doubleTypeConversion = new DoubleConversion();
            IList<CityModel> myList = ReadCsv.ReadCsvFile<CityModel, CityMap>(readPath, doubleTypeConversion);

            var countryCapitalQuery = from s in myList
                                      where s.Capital.Equals("primary")
                                      orderby s.Country ascending
                                      select s;

            var writeFile = Writecsv.WriteCsvFile(countryCapitalQuery);

            Assert.IsTrue(File.Exists(writeFile));
            Assert.AreEqual(writeFile, "c://csvWriteFiles//countryCapitalQuery.csv");

            Debug.Write("Write Path: " + writeFile);
        }
    }
}
