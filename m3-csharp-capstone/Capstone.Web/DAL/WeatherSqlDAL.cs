using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAL : IWeatherDAL
    {
        private readonly string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=NationalParkService;User ID=te_student;Password=techelevator";
        public List<Weather> Get5DaysOfWeather(string id)
        {
            List<Weather> output = new List<Weather>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * , parkName from weather inner join park on park.parkCode = weather.parkCode where weather.parkCode=@id;", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Weather w = new Weather();

                        w.ParkCode = Convert.ToString(reader["parkCode"]);
                        w.FiveDayForcastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        w.ParkName = Convert.ToString(reader["parkName"]);
                        w.Low = Convert.ToInt32(reader["low"]);
                        w.High = Convert.ToInt32(reader["high"]);
                        w.Forecast = Convert.ToString(reader["forecast"]);

                        output.Add(w);
                    }
                }

            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
            }
            return output;
        }





    }
}
