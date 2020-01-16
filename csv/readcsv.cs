using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Collections.Generic;
using System.IO;
using Cities;
using System.Linq;
using System;

namespace csv
{
    public class Readcsv
    {
        /*
        public static void Main()
        {
            var path = "c://csvfiles//worldcities.csv";
            var recordList = ReadInCSV(path);
        }
        */

        public static List<City> ReadAllCSV(string absolutePath)
        {
            List<City> result = new List<City>();
            using (var reader = new StreamReader(absolutePath))
            {
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.HasHeaderRecord = true;
                    csv.Configuration.TypeConverterCache.AddConverter(typeof(double), new EmptyDouble());
                    csv.Configuration.RegisterClassMap<CityMap>();
                    
                    while (csv.Read())
                    {
                        result.Add(csv.GetRecord<City>());
                    }
                }
                return result;
            }
        }


        public static List<City> ReadOneCSVRecord(string absolutePath)
        {
            List<City> result = new List<City>();
            using (var reader = new StreamReader(absolutePath))
            {
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.HasHeaderRecord = true;
                    csv.Configuration.TypeConverterCache.AddConverter(typeof(double), new EmptyDouble());
                    csv.Configuration.RegisterClassMap<CityMap>();

                    csv.Read();
                    result.Add(csv.GetRecord<City>());
                }
                return result;
            }
        }
    }
}