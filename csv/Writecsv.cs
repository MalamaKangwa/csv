using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Model;
using System.Globalization;

namespace Csv
{
        public class Writecsv
        {
            public static string WriteCsvFile(IOrderedEnumerable<CityModelImport> QueryX)
            {
                var queryName = nameof(QueryX);
                var fileAddress = "c://csvWriteFiles//" + queryName + ".csv";

                using (var writer = new StreamWriter(fileAddress))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(fileAddress);
                }

                return fileAddress;
            }
        }   
}


