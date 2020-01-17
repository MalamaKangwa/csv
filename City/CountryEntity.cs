﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cities
{
    public class CountryEntity : CountryModel
    {
        [Key]
        public int CountryID { get; set; }

        public virtual List<CityEntity> Cities { get; set; }
    }
}
