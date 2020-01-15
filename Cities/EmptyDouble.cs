using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;


namespace Cities
{
    public class EmptyDouble : DoubleConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (text == "")
            {
                double value = 0;
                return value;
            }
            else
            {
                double value = System.Convert.ToDouble(text);
                return value;
            }
        }
    }
}
