using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ParkModelDAL
    {
        const string connectionString = @"Data Source=.\SQLEXPRESS;Initial"
 + " Catalog=NPGeek;Integrated Security=True";
        const string getParksString = "SELECT * FROM park;";
        public string connection;

        
        public IList<ParkModel> GetParkModels()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                IList<ParkModel> result = connection.Query<ParkModel>(getParksString).ToList();
                return result;
            }
        }

        public ParkModel GetParkModel(string code)
        {
            return GetParkModels().FirstOrDefault(p => p.ParkCode == code.ToUpper());
        }
    }
}
    


