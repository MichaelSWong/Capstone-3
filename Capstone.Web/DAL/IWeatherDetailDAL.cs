using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface IWeatherDetailDAL
    {
       IList<WeatherModel> GetWeather(string code);


    }
}
