using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.Web.Models;
using System.Data.SqlClient;

namespace Chat.Web.DataAccess
{
    public class UserSqlDAL : IUserDAL
    {
        private readonly string connectionString;

        public UserSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public UserModel CreateUser(UserModel user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO users VALUES (@username, @password);", conn);
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.ExecuteNonQuery();                    
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return user;
        }

        public UserModel GetUser(string username, string password)
        {
            UserModel output = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username = @username AND password = @password", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        output = new UserModel()
                        {
                            Username = Convert.ToString(reader["username"]),
                            Password = Convert.ToString(reader["password"])
                        };
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }
    }
}