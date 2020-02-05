﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Csv;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Context;
using System.Linq;
using EntityOrm;
using System.Diagnostics;

namespace Csv.Tests
{
    [TestClass()]
    public class ReadCsvTests
    {
        [TestMethod()]
        public void ReadInCSVTest()
        {
            var path = "c://csvfiles//worldcities.csv";
            var doubleTypeConversion = new DoubleConversion();
            IList<CityModelImport> myList = ReadCsv.ReadCsvFile<CityModelImport, CityMap>(path, doubleTypeConversion);

            var countryCapitalQuery = (from s in myList
                                       where s.Capital.Equals("primary")
                                       orderby s.Country ascending
                                       select s);

            foreach (CityModelImport city in countryCapitalQuery)
            {
                Debug.Write(city.Country + ": " + city.City_name + Environment.NewLine);
            }

            var QSCount = (from city in countryCapitalQuery
                           select city).Count();

            //Debug.Write(QSCount);

            Assert.AreEqual(15493, myList.Count());

            using (var dbContext = new CityDBContext())
            {
                dbContext.Database.Connection.Close();
            }


            var countryGroups = from city in countryCapitalQuery
                                group city by new
                                {
                                    city.Country,
                                    city.ISO2,
                                    city.ISO3
                                }
                                into countryGroup
                                orderby countryGroup.Key.Country
                                select countryGroup;

            using (var db = new CityDBContext())
            {
                foreach (var country in countryGroups)
                {
                    var countryName = country.Key.Country;
                    var ISO2 = country.Key.ISO2;
                    var ISO3 = country.Key.ISO3;
                    var CountryEntity = new CountryEntity
                    {
                        Name = countryName,
                        ISO2 = ISO2,
                        ISO3 = ISO3
                    };
                    db.Countries.Add(CountryEntity);
                    db.SaveChanges();
                    int id = CountryEntity.CountryID;
                    Debug.Write(country);
                    foreach (var city in country)
                    {
                        var CityEntity = new CityEntity
                        {
                            City_name = city.City_name,
                            Admin_name = city.Admin_name,
                            City_ascii = city.City_ascii,
                            Lat = city.Lat,
                            Lng = city.Lng,
                            Capital = city.Capital,
                            CountryId = id,
                            Population = city.Population
                        };
                        db.Cities.Add(CityEntity);
                        db.SaveChanges();
                    }
                }
            }
            // countryQuery = records.Where(city => city.Country.Equals("United States"));
            /*
            foreach (CityModel city in countryQuery)
            {
                var name = city.City_name.ToString();
            }
            */
        }
    }
}
