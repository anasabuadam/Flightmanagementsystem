using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Flightmanagementsystem
{
    class TicketDAOPGSQL : ITicketDAO
    {
        string conn_string = "";
        public void Add()
        {
            try
            {


                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "AddTicket";
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
        }

        public void Get()
        {
            try
            {


                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "GetTicke";
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
        }

        public void GetAll()
        {
            try
            {


                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "GetTicke";
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
        }

        public void Remove()
        {
            try
            {


                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "RemoveTicket";
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
        }

        public void Update()
        {
            try
            {


                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "UpdateTicket";
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
        }
    }
}
