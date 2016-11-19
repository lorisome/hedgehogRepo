using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using System.Data.SqlClient;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        private readonly string connectionString= @"Data Source=.\SQLExpress;Initial Catalog=NationalParkService;User ID=te_student;Password=techelevator";

        public bool SaveNewSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Insert into survey_result values (@parkCode, @emailAddress, @State, @ActivityLevel);", conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@State", survey.State);
                    cmd.Parameters.AddWithValue("@ActivityLevel", survey.ActivityLevel);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }
            catch(SqlException e)
            {
                e.Message.ToString();
            }
            return false;
        }

        public List<SurveyResult> SurveyResults()
        {
            List<SurveyResult> output = new List<SurveyResult>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select COUNT(*) as count, parkCode from survey_result Group BY parkCode ORDER BY count desc;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        
                        {

                            SurveyResult s = new SurveyResult();
                            s.Count = Convert.ToInt32(reader["count"]);
                            s.ParkCode = Convert.ToString(reader["parkCode"]);

                            output.Add(s);              
                        };
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