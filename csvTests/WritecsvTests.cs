using Microsoft.VisualStudio.TestTools.UnitTesting;
using Csv;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Cities;
using Model;
using CsvHelper;

namespace Csv.Tests
{
    [TestClass()]
    public class WritecsvTests
    {
        [TestMethod()]
        public void WriteToTest1()
        {

            var path = "c://csvfiles//worldcities.csv";
            var doubleTypeConversion = new DoubleConversion();
            IList<CityModelImport> myList = ReadCsv.ReadCsvFile<CityModelImport, CityMap>(path, doubleTypeConversion);

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