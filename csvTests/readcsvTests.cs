using Microsoft.VisualStudio.TestTools.UnitTesting;
using csv; 
using System;
using System.Collections.Generic;
using System.Text;
using Cities;
using System.IO;

namespace csv.Tests
{
    [TestClass()]
    public class ReadcsvTests
    {
        [TestMethod()]
        public void ReadAllRecordsInCSVTest()
        {
            var absolutePath = "c://csvfiles//worldcities.csv";
            List<City> result = Readcsv.ReadAllCSV(absolutePath);
            Assert.AreEqual(15493, result.Count);
        }

       [TestMethod()]
       public void ReadOneRecordInCSVTest()
       {
           var absolutePath = "c://csvfiles//worldcities.csv";
           List<City> result = Readcsv.ReadOneCSVRecord(absolutePath);
           Assert.AreEqual(1, result.Count);
       }
    }
}