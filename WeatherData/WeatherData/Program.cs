using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherData
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherDataDAL dal = new WeatherDataDAL();
            List<DayOfWeather> allDays = dal.GetWeatherData();
            int tempSpread = Int32.MaxValue;
            int DayNumber = 0;
            foreach  (DayOfWeather day in allDays)
            {
                int currentTempSpread = day.GetTempSpread();
                if(currentTempSpread < tempSpread)
                {
                    tempSpread = currentTempSpread;
                    DayNumber = day.DayNumber;
                }
            }
            Console.WriteLine("The day with the smallest temperature spread is : " + DayNumber);
            Console.ReadLine();
        }
    }
}
