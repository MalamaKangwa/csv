using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Model;

namespace EntityOrm
{
    public class CountryEntity : CountryModel
    {
        [Key]
        public int CountryID { get; set; }

        public virtual List<CityEntity> Cities { get; set; }
    }
}


