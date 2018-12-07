using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Models
{
    public class WeatherModel
    {
        public string ParkCode { get; set; }

        public int FiveDayForecastValue { get; set; }

        public int Low { get; set; }

        public int High { get; set; }

        public string Forecast { get; set; }
        //join for this
        public string ParkName { get; set; }

        public bool isCelsius { get; set; }

        public string tempUnit = "°F";

        public static WeatherModel ChangeTemp(WeatherModel result)
        {
            if (result.isCelsius)
            {
                //WeatherModel result = new WeatherModel();
                //result.ParkCode = weatherFromDAL.ParkCode;
                //result.FiveDayForecastValue = weatherFromDAL.FiveDayForecastValue;
                double doubleLow = Convert.ToDouble(result.Low);
                double doubleHigh = Convert.ToDouble(result.High);

                result.Low = Convert.ToInt16((doubleLow- 32) * 0.5556);
                result.High = Convert.ToInt16((doubleHigh- 32) * 0.5556);
                result.tempUnit = "°C";
                //result.Forecast = weatherFromDAL.Forecast;
                //result.ParkName = weatherFromDAL.ParkName;
                return result;
            }
            else
            {
                return result;
            }
        }
        
        public string forecastImage(WeatherModel forecast)
        {
            string imageName = "~/img/weather/" + forecast.Forecast.Replace(" ", "") + ".png";
            return imageName;
        }
        public List<string> WeatherIconHelper (WeatherModel weather)
        {
            List<string> iconList = new List<string>();

            if(weather.Forecast == "rain")
            {
                iconList.Add("Bring a Raincoat and water proof shoes");
                
            }
            if (weather.Forecast == "snow")
            {
                iconList.Add("Bring snowshoes");
            }
            if (weather.Forecast == "thunderstorms")
            {
                iconList.Add("Seek Shelter and avoid hiking");
            }
            if (weather.Forecast == "sunny")
            {
                iconList.Add("Bring sunscreen");
            }
            if (!isCelsius && weather.High >= 75|| isCelsius && weather.High >= 24 )
            {
                iconList.Add("Bring a Gallon of water");
            }
            if (!isCelsius && Math.Abs(weather.Low - weather.High) >= 20 || isCelsius && ((Math.Abs((double)weather.High * 1.8 + 32) - (Math.Abs((double)weather.Low * 1.8 + 32)) >= 20)))
            {
                iconList.Add("Wear Breathable Layers");
            }
            if (!isCelsius && weather.Low <= 20 || isCelsius && (double)weather.Low <= -6.6667)
            {
                iconList.Add("Exposure to frigid temperatures is DANGEROUS");
            }



                return iconList;
        }

        public List<string> SafetyIconHelper(WeatherModel weather)
        {
            List<string> iconList = new List<string>();

            if (weather.Forecast == "rain")
            {
                iconList.Add("umbrella.jpg");
                iconList.Add("waterProofShoes.jpg");

            }
            if (weather.Forecast == "snow")
            {
                iconList.Add("SnowShoes.png");
            }
            if (weather.Forecast == "thunderstorms")
            {
                iconList.Add("seekShelter.jpg");
                iconList.Add("avoidCliffs.png");
            }
            if (weather.Forecast == "sunny")
            {
                iconList.Add("packSunBlock.png");
            }
            if (!isCelsius && weather.High >= 75 || isCelsius && (double)weather.High >= 23.9)
            {
                iconList.Add("bringWater.png");
            }
            if (!isCelsius && Math.Abs(weather.Low - weather.High) >= 20 || isCelsius && ((Math.Abs((double)weather.High * 1.8 + 32) - (Math.Abs((double)weather.Low * 1.8 + 32)) >= 20)))
            {
                iconList.Add("multipleLayers.jpg");
            }
            if (!isCelsius && weather.Low <= 20 || isCelsius && weather.Low <= -6)
            {
                iconList.Add("lowTempDanger.jpg");
            }



            return iconList;

        }

        public static List<SelectListItem> TempSelect = new List<SelectListItem>()
        {
            new SelectListItem() {Text ="°F", Value = "false" },            
            new SelectListItem() {Text ="°C", Value = "true" }
        };
    }
    



}
