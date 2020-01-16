using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using CsvHelper;
using System.Linq;
using Cities;

namespace Csv
{
    public class Writecsv
    {
        public static string WriteCsvFile(IOrderedEnumerable<CityModel> countryCapitalQuery)
        {
            var queryName = nameof(countryCapitalQuery);
            var fileAddress = "c://csvWriteFiles//" + queryName + ".csv";

            

            using (var writer = new StreamWriter(fileAddress))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(countryCapitalQuery);
            }

            return fileAddress;
        }
    }
}
