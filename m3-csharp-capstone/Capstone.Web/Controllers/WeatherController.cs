using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class WeatherController : Controller
    {
        private IWeatherDAL WeatherDAL;

        public WeatherController(IWeatherDAL WeatherDAL)
        {
            this.WeatherDAL = WeatherDAL;
        }


        public ActionResult Weather(string id)
        {
            Session["parkID"] = id;
            List<Weather> forecast = WeatherDAL.Get5DaysOfWeather(id);
            if(Session["keepTempType"] == null)
            {
                Session["keepTempType"] = "F";
            }
            foreach (var dayOfWeather in forecast)
            {
                dayOfWeather.TempType = Session["keepTempType"].ToString();
            }

            return View("Weather", forecast);
        }

        public ActionResult TemperatureType(string tempType)
        {
            string id = Session["parkID"].ToString();
            Session["keepTempType"] = tempType;
            List<Weather> forecast = WeatherDAL.Get5DaysOfWeather(id);
            foreach (var dayOfWeather in forecast)
            {
                dayOfWeather.TempType = Session["keepTempType"].ToString();
            }

            return View("Weather", forecast);
        }

    
    }
}