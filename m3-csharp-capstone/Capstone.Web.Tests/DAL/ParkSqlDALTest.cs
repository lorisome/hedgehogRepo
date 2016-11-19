using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Web.DAL;
using System.Transactions;
using System.Collections.Generic;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.Tests.DAL
{
    [TestClass]
    public class ParkSqlDALTest
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=NationalParkService;User ID=te_student;Password=techelevator";

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cm = new SqlCommand("Delete from weather", conn);
                cm.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("Delete from park", conn);
                cmd.ExecuteNonQuery();
                SqlCommand cmd2 = new SqlCommand("Insert into park(parkCode, parkName, numberOfAnimalSpecies, state, acreage, elevationInFeet, milesOFTrail, numberOfCampsites, climate, yearFounded, annualVisitorCount, inspirationalQuote, inspirationalQuoteSource, parkDescription, entryFee) values('NP', 'National Park', 1, 'OH', 1, 1, 1, 1, 'hot', 1999, 1, 'aye', 'yaiy', 'none', 1);", conn);
                cmd2.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void TestGetAllParksMethod()
        {
            ParksSqlDAL parkSqlDal = new ParksSqlDAL();
            List<Park> allParks = parkSqlDal.GetAllParks();

            Assert.IsNotNull(allParks);
            Assert.AreEqual(1, allParks.Count);
        }
    }
}
