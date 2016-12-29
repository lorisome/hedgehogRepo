using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web.WebPages;

namespace WeatherData
{
    class WeatherDataDAL
    {

        public List<DayOfWeather> GetWeatherData()
        {
            string myPath = Environment.CurrentDirectory;
            string myFileName = "weather.dat";
            string fullPath = Path.Combine(myPath, myFileName);
            List<DayOfWeather> weather = new List<DayOfWeather>();
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    int lineCount = 0;
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] lineOfWeatherData = line.Split(new string[] { "\t", " ", "*" }, StringSplitOptions.RemoveEmptyEntries);
                        DayOfWeather newDay = new DayOfWeather();

                        if (lineCount > 0 && (lineOfWeatherData.Length > 0))
                        {
                            if (lineOfWeatherData[0].IsInt() && lineOfWeatherData[1].IsInt() && lineOfWeatherData[2].IsInt()) //this line contains the correct type of data
                            {
                                newDay.DayNumber = Convert.ToInt32(lineOfWeatherData[0]);
                                newDay.MaxTemp = Convert.ToInt32(lineOfWeatherData[1]);
                                newDay.MinTemp = Convert.ToInt32(lineOfWeatherData[2]);
                                weather.Add(newDay);

                            }
                            
                        }
                        lineCount++;

                    }
                    return weather;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("An exception of type " + e.GetType().FullName + " has been thrown.");
                throw;
            }
        }
    }

}
