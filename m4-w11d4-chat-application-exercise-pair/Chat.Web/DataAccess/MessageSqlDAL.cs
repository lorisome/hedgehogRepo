using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.Web.Models;
using System.Data.SqlClient;

namespace Chat.Web.DataAccess
{
    public class MessageSqlDAL : IMessageDAL
    {
        private readonly string connectionString;

        public MessageSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public MessageModel AddMessage(MessageModel newMessage)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO messages VALUES (@roomId, @username, @message, GETDATE()); SELECT CAST(SCOPE_IDENTITY() as int);", conn);
                    cmd.Parameters.AddWithValue("@roomId", newMessage.RoomId);
                    cmd.Parameters.AddWithValue("@username", newMessage.Username);
                    cmd.Parameters.AddWithValue("@message", newMessage.Message);

                    newMessage.Id = (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return newMessage;
        }

        public bool DeleteMessage(int messageId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM messages WHERE message_id = @messageId", conn);
                    cmd.Parameters.AddWithValue("@messageId", messageId);

                    return (cmd.ExecuteNonQuery() > 0);
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public List<MessageModel> GetMessages(int roomId, DateTime sinceDate)
        {
            List<MessageModel> messages = new List<MessageModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM messages WHERE room_id = @roomId AND sent_date > @sinceDate ORDER BY sent_date ASC;", conn);
                    cmd.Parameters.AddWithValue("@roomId", roomId);
                    cmd.Parameters.AddWithValue("@sinceDate", sinceDate);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        messages.Add(CreateMessage(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return messages;
        }

        public List<MessageModel> GetMessages(int roomId)
        {
            List<MessageModel> messages = new List<MessageModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM messages WHERE room_id = @roomId ORDER BY sent_date ASC;", conn);
                    cmd.Parameters.AddWithValue("@roomId", roomId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        messages.Add(CreateMessage(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return messages;
        }

        private MessageModel CreateMessage(SqlDataReader reader)
        {
            return new MessageModel
            {
                Id = Convert.ToInt32(reader["message_id"]),
                RoomId = Convert.ToInt32(reader["room_id"]),
                Username = Convert.ToString(reader["username"]),
                Message = Convert.ToString(reader["message"]),
                SentDate = Convert.ToDateTime(reader["sent_date"])
            };
        }
    }
}