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
    public class SurveyDALTests
    {
        private TransactionScope myTransaction;
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=NPGeek;Integrated Security=True";

        SurveyDAL testObj = null;

        [TestInitialize]
        public void Intialize()
        {
            testObj = new SurveyDAL();
            myTransaction = new TransactionScope();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command;

                connection.Open();

                command = new SqlCommand("INSERT INTO SURVEY_RESULT VALUES ('GNP','jonn_good@yahoo.com','NY','active');", connection);
                command.ExecuteNonQuery();
            }
        }


        [TestCleanup]
        public void Cleanup()
        {
            myTransaction.Dispose();
        }




        [TestMethod]
        public void SurveyListTest()
        {
            // ARRANGE
            SurveyDAL surveyDal = new SurveyDAL();
            IList<ParksBySurvey> objs = testObj.SurveyList();

            // ACT
            Assert.IsNotNull(objs);
            List<string> code = new List<string>();
            foreach(ParksBySurvey obj in objs)
            {
                code.Add(obj.ParkCode);
            }

            //ASSERT
            CollectionAssert.Contains(code, "GNP");


        }
    }
}
