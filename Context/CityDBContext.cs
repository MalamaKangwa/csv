using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using EntityOrm;

namespace Context
{
    public class CityDBContext : DbContext
    {
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
    }
}
