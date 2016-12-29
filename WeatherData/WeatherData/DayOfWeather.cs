using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherData
{
    class DayOfWeather
    {
        public int DayNumber { get; set; }
        public int MinTemp { get; set; }
        public int MaxTemp { get; set; }

        public int GetTempSpread()
        {
            return Math.Abs(MaxTemp - MinTemp);
        }
    }
}
