using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Flightmanagementsystem.BasicFolderClass;
using Flightmanagementsystem.Exceptions;

namespace Flightmanagementsystem.DAOClass
{
    public class AdminDAOPGSQL :Administrator,  IAdminDAO
    {
        static SqlConnection conSQL = new SqlConnection(SQLConnection.conStr);
        public void Add(Administrator t)
        {
            int result = 0;
            long id = t.Id;
            string firstName = t.First_Name;
            string lastName = t.Last_Name;
            int level = t.Level;
            long userid = t.User_Id;
            Administrator admin = Get(t.Id);
            if (admin is null)
            {
                SQLConnection.SQLOpen(conSQL);
                string cmdStr = $"INSERT INTO Adminstrators VALUES('{id}','{firstName}','{lastName}','{level}',{userid});SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                SQLConnection.SQLClose(conSQL);
            }
            else
            {
                throw new AdminAlreadyExistsException($"The adminstrator {firstName} {lastName} already exists with ID {admin.Id}");
            }
        }

        public Administrator Get(long id)
        {
            SQLConnection.SQLOpen(conSQL);
            Administrator administrator = null;
            string cmdStr = $"SELECT * FROM Adminstrators WHERE ID = {id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        administrator = new Administrator
                        {
                            Id = (long)reader["Id"],
                            First_Name = (string)reader["First_Name"],
                            Last_Name = (string)reader["Last_Name"],
                            Level = (int)reader["Level"],
                            User_Id = (long)reader["User_Id"]

                        };

                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return administrator;
        }

        public IList<Administrator> GetAll()
        {
            SQLConnection.SQLOpen(conSQL);
            List<Administrator> administratorr = new List<Administrator>();
            string cmdStr = $"SELECT * FROM Adminstrators";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Administrator administrator1 = null;

                    while (reader.Read())
                    {

                        administrator1 = new Administrator
                        {
                            Id = (long)reader["Id"],
                            First_Name = (string)reader["First_Name"],
                            Last_Name = (string)reader["Last_Name"],
                            Level = (int)reader["Level"],
                            User_Id = (long)reader["User_Id"]
                        };
                        administratorr.Add(administrator1);
                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return administratorr;
        }

        public void Remove(Administrator t)
        {
            Administrator administrator = Get(t.Id);
            if (administrator != null)
            {
                throw new Exception("No such administrator");
            }
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"DELETE FROM Adminstrators WHERE ID = {t.Id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }

        }

        public void Update(Administrator t)
        {
            Administrator administrator = Get(t.Id);
            if (administrator == null)
            {
                throw new Exception("No such administrator");
            }
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"UPDATE Adminstrators SET First_Name = '{t.First_Name}', Last_Name = '{t.Last_Name}', Level = '{t.Level}', User_Id = '{t.User_Id}' WHERE ID = {t.Id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }

        }
    }
}
