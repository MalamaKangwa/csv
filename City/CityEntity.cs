using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.ComponentModel.DataAnnotations;

namespace Cities
{
    public class CityEntity : CityModel
    {
        [Key]
        public int CityID { get; set; }

        public virtual CountryEntity Country { get; set; }
    }
}
