using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using System.Transactions;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace Capstone.Tests
{
    [TestClass]
    public class WeatherDetaiDALTests
    {
        private TransactionScope myTransaction;
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=NPGeek;Integrated Security=True";

        WeatherDetailDAL testObj = null;

        [TestInitialize]
        public void Initialize()
        {
            testObj = new WeatherDetailDAL();
            myTransaction = new TransactionScope();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command;

                connection.Open();

                command = new SqlCommand("INSERT INTO WEATHER(parkCode,fiveDayForecastValue,low,high,forecast) VALUES ('GNP', 6, 40,50,'rain');", connection);
                command.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            myTransaction.Dispose();
        }


        [TestMethod]
        public void GetWeatherTest()
        {
            WeatherDetailDAL weatherDal = new WeatherDetailDAL();
            IList<WeatherModel> objs = testObj.GetWeather("GNP");
            //Assert.IsNotNull(weatherDal.GetWeather("GNP"));

            Assert.IsNotNull(objs);
            List<string> forecast = new List<string>();
            foreach(WeatherModel obj in objs)
            {
                forecast.Add(obj.FiveDayForecastValue.ToString());
            }

            CollectionAssert.Contains(forecast, "6");
        }
    }
}
