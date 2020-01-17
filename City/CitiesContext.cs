using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Cities
{
    public class CitiesContext : DbContext
    {
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
    }
}
