using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.Web.Models;
using System.Data.SqlClient;

namespace Chat.Web.DataAccess
{
    public class RoomSqlDAL : IRoomDAL
    {
        private readonly string connectionString;

        public RoomSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        

        public bool IsUserInRoom(int id, string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM room_members WHERE room_id = @roomId AND username = @username;", conn);
                    cmd.Parameters.AddWithValue("@roomId", id);
                    cmd.Parameters.AddWithValue("@username", username);

                    return (int)cmd.ExecuteScalar() > 0;                    
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public RoomModel CreateChatRoom(RoomModel room)
        {
            int newId = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO rooms VALUES (@room_name, @room_description, @created_by, GETDATE()); SELECT CAST(SCOPE_IDENTITY() as int);", conn);
                    cmd.Parameters.AddWithValue("@room_name", room.Name);
                    cmd.Parameters.AddWithValue("@room_description", room.Description);
                    cmd.Parameters.AddWithValue("@created_by", room.CreatedBy);
                    newId = (int)cmd.ExecuteScalar();                    
                }

                room = GetChatRoom(newId);
                return room;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public RoomModel GetChatRoom(string name)
        {
            RoomModel room = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM rooms where room_name = @room_name", conn);
                    cmd.Parameters.AddWithValue("@room_name", name);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        room = CreateChatRoom(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return room;
        }

        public RoomModel GetChatRoom(int id)
        {
            RoomModel room = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM rooms where room_id = @roomId", conn);
                    cmd.Parameters.AddWithValue("@roomId", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        room = CreateChatRoom(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return room;
        }

        public List<RoomModel> GetOpenRooms()
        {
            List<RoomModel> rooms = new List<RoomModel>();

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM rooms;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        rooms.Add(CreateChatRoom(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return rooms;
        }

        private RoomModel CreateChatRoom(SqlDataReader reader)
        {
            return new RoomModel
            {
                CreatedBy = Convert.ToString(reader["created_by"]),
                CreatedDate = Convert.ToDateTime(reader["created_date"]),
                Description = Convert.ToString(reader["room_description"]),
                Id = Convert.ToInt32(reader["room_id"]),
                Name = Convert.ToString(reader["room_name"])
            };
        }

        public List<string> GetRoomMembers(int id)
        {
            List<string> members = new List<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM room_members WHERE room_id = @room_id", conn);
                    cmd.Parameters.AddWithValue("@room_id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        members.Add(Convert.ToString(reader["username"]));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return members;
        }

        public void JoinChatRoom(int id, string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO room_members VALUES (@room_id, @username);", conn);
                    cmd.Parameters.AddWithValue("@room_id", id);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public void LeaveChatRooms(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM room_members WHERE username = @username;", conn);                    
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}