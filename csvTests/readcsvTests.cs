using Microsoft.VisualStudio.TestTools.UnitTesting;
using csv; 
using System;
using System.Collections.Generic;
using System.Text;

namespace csv.Tests
{
    [TestClass()]
    public class readcsvTests
    {
        [TestMethod()]
        public void Read1Test()
        {
            Readcsv.Main();
            Assert.Fail();
        }
    }
}