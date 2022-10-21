using Flightmanagementsystem.BasicFolderClass;
using Flightmanagementsystem.Exceptions;
using log4net.Core;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver.Core.WireProtocol.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Reflection.Emit;

namespace Flightmanagementsystem.DAOClass
{
    public class UserDAOPGSQL : User ,IUser
    {
        public User userr = new User();
        static SqlConnection conSQL = new SqlConnection(SQLConnection.conStr);
        public User Add(User t)
        {
            string result = "";
            long id = t._Id;
            string username = t._Username;
            string password = t._Password;
            string email = t._Email;
            long userRole = t._User_Role;
            User userr =  Get(t._Id);
            if (userr is null)
            {
                SQLConnection.SQLOpen(conSQL);
                string cmdStr = $"INSERT INTO Users VALUES('{id}','{username}','{password}','{email}',{userRole});";
                using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
                {
                    result = Convert.ToString(cmd.ExecuteScalar());
                }
                SQLConnection.SQLClose(conSQL);
            }
            else
            {
                throw new AdminAlreadyExistsException($"The adminstrator {username} {email} already exists with ID {userr._Id}");
            }
            return t;

        }

        public User Get(long id)
        {
            SQLConnection.SQLOpen(conSQL);
            User user = null;
            string cmdStr = $"SELECT * FROM Users WHERE Id = {id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        user = new User
                        {
                            _Id = (long)reader["Id"],
                            _Username = (string)reader["Username"],
                            _Password = (string)reader["Password"],
                            _Email = (string)reader["Email"],
                            _User_Role = (int)reader["User_Role"]

                        };

                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return user;
        }

        public IList<User> GetAllUsers()
        {
            IList<User> users = new List<User>();
            try
            {
               

                SQLConnection.SQLOpen(conSQL);

                string cmdStr = $"SELECT * FROM Users";
                using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            User user1 = new User
                            {
                                _Id = (long)reader["Id"],
                                _Username = (string)reader["UserName"],
                                _Password = (string)reader["Password"],
                                _Email = (string)reader["Email"],
                                _User_Role = (int)reader["User_Role"]
                            };
                            users.Add(user1);
                        }
                    }
                }
                SQLConnection.SQLClose(conSQL);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to run sp from db {ex}");
            }
            return users;
        
        }
        public User Remove(User t)
        {
            try
            {


                using (SqlConnection sqlConnection1 = new SqlConnection(conSQL.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "RemoveUser";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();

                        cmd.ExecuteNonQuery();
                        SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to run sp from db {ex}");
            }
            return t;
        }



        public User Update(User t)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conSQL.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateUser",connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", t._Id);
                cmd.Parameters.AddWithValue("@username", t._Username);
                cmd.Parameters.AddWithValue("@password", t._Password);
                cmd.Parameters.AddWithValue("@email", t._Email);
                cmd.Parameters.AddWithValue("@userrole", t._User_Role);
                connection.Open();
                id = cmd.ExecuteNonQuery();
                connection.Close();
            }
            if (id > 0)
            {
                return t;
            }
            else
            {
                return null;
            }
        }
    }
}
