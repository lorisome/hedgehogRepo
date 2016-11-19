using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{

    public class Weather
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }  
        public int FiveDayForcastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public string TempType { get; set; }

        public double ConvertTemp(int temp)
        {
            if (TempType == "C")
            {
                temp = (int)(Math.Round(((temp - 32)*(5.0 / 9.0)), 0));
            }
            return temp;
        }
    }
}