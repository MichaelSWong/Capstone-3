using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class SurveyDAL
    {

        const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=NPGeek;Integrated Security=True";
        const string SaveSurveyString = " INSERT INTO survey_result(parkCode, emailAddress, state, activityLevel)values(@parkCode, @emailAddress, @state, @activityLevel)";

        const string numberOfSurveyString = "SELECT COUNT(*) AS numberOfSurveys, survey_result.parkCode, parkName FROM survey_result join park ON park.parkCode=survey_result.parkCode GROUP BY survey_result.parkCode, parkName ORDER BY numberOfSurveys DESC;";
        public int SaveSurvey (SurveyModel newSurvey)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int affectedRows = connection.Execute(SaveSurveyString, newSurvey);
                return affectedRows;
            }

                   
        }
        public IList<ParksBySurvey> SurveyList()
        {
            using (SqlConnection connection = new  SqlConnection(connectionString))
            {
                connection.Open();
                IList<ParksBySurvey> result = connection.Query<ParksBySurvey>(numberOfSurveyString).ToList();
                return result; // think we have to return result but not sure with dapper
            }
        }





    }
}
