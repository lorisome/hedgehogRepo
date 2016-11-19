using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class ParksSqlDAL : IParkDAL
    {
        private readonly string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=NationalParkService;User ID=te_student;Password=techelevator";


        public List<Park> GetAllParks()
        {
            List<Park> output = new List<Park>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * from park;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output.Add(new Park()
                        {
                            parkName = Convert.ToString(reader["parkName"]),
                            location = Convert.ToString(reader["state"]),
                            summary = Convert.ToString(reader["parkDescription"]),
                            imgName = Convert.ToString(reader["parkCode"])
                            

                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
            }
            return output;
        }

        public Park GetOnePark(string id)
        {

            Park output = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * from park where parkCode=@id;", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        output = new Park();

                        output.parkName = Convert.ToString(reader["parkName"]);
                        output.location = Convert.ToString(reader["state"]);
                        output.summary = Convert.ToString(reader["parkDescription"]);
                        output.imgName = Convert.ToString(reader["parkCode"]);
                        output.elevation = Convert.ToInt32(reader["elevationInFeet"]);
                        output.acreage = Convert.ToInt32(reader["acreage"]);
                        output.milesOfTrail = Convert.ToInt32(reader["milesOfTrail"]);
                        output.numberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        output.climate = Convert.ToString(reader["climate"]);
                        output.yearFounded = Convert.ToInt32(reader["yearFounded"]);
                        output.annualVisitorCount = Convert.ToString(reader["annualVisitorCount"]);
                        output.entryFee = Convert.ToDouble(reader["entryFee"]);
                        output.inspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        output.inspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        output.numberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);





                    }
                }
            }
            catch (SqlException ex)
            {
                ex.Message.ToString();
            }
            return output;


        }
    }

}