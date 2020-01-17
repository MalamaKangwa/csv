using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Model;

namespace Csv
{
        public class Writecsv
        {
            public static string WriteCsvFile(IOrderedEnumerable<CityModel> QueryX)
            {
                var queryName = nameof(QueryX);
                var fileAddress = "c://csvWriteFiles//" + queryName + ".csv";

                using (var writer = new StreamWriter(fileAddress))
                using (var csv = new CsvWriter(writer))
                {
                    csv.WriteRecords(QueryX);
                }

                return fileAddress;
            }
        }
    
}

