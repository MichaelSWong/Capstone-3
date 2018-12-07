using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class WeatherDetailDAL : IWeatherDetailDAL
    {
        const string connectionString = @"Data Source=.\SQLEXPRESS;Initial"
 + " Catalog=NPGeek;Integrated Security=True";

        
        const string weatherDetailString = "Select fiveDayForecastValue, low, high, forecast, parkName, park.parkCode " +
            "FROM weather join park on park.parkCode = weather.parkCode " +
            "where weather.parkCode = @parkCode;";

        public IList<WeatherModel> GetWeather(string code)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                connection.Open();
                IList<WeatherModel> result = connection.Query<WeatherModel>(weatherDetailString, new { parkCode = code}).ToList();
                List<WeatherModel> treatedResult = new List<WeatherModel>();

    
                foreach (var item in result)
                {

                    treatedResult.Add(WeatherModel.ChangeTemp(item));
                }
                result.Clear();
                foreach (var item in treatedResult)
                {
                    result.Add(item);
                }
                return result;
            }
            
        }









    }
}
