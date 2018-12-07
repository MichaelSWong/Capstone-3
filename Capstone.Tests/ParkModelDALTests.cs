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
    public class ParkModelDALTests
    {

        private TransactionScope myTransaction;
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=NPGeek;Integrated Security=True";

        ParkModelDAL testObj = null;

        [TestInitialize]
        public void Initialize()
        {
            testObj = new ParkModelDAL();
            myTransaction = new TransactionScope();

            using (SqlConnection connnection = new SqlConnection(connectionString))
            {
                SqlCommand command;

                connnection.Open();

                command = new SqlCommand("INSERT INTO PARK VALUES ('VRNP','Vinnie Russos National Park','Pennsylvania',100000,5000,100,0,'Forest',2018,10,'Party Parrot','Vinnie Russo','Greatest place on earth',10,100);", connnection);
                command.ExecuteNonQuery();
            }
        }       


        [TestCleanup]
        public void Cleanup()
        {
            myTransaction.Dispose();
        }



        [TestMethod]
        public void GetParkModelsTest()
        {
            //Arrange
            ParkModelDAL parkDal = new ParkModelDAL();
            IList<ParkModel> objs = testObj.GetParkModels();

            //Act
            Assert.IsNotNull(objs);
            List<string> code = new List<string>();
            foreach(ParkModel obj in objs)
            {
                code.Add(obj.ParkCode);
            }

            //Assert
            CollectionAssert.Contains(code, "VRNP");

        }
    }
}
