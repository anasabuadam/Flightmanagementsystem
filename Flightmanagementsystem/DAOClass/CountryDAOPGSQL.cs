using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Flightmanagementsystem
{
    public class CountryDAOPGSQL : ICountryDAO
    {
        string conn_string = "";
        public void Add(Country t)
        {
            try
            {

                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "AddCountre";
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

        public Country Get(int id)
        {
            try
            {
                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "GetAllCountries";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();

                        cmd.ExecuteNonQuery();

                        // read country from database row

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to run sp from db {ex}");
            }

            return Get(id);
        }


        public IList<Country> GetAll()
        {
            try
            {
                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "GetAllCountries";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();

                        cmd.ExecuteNonQuery();



                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to run sp from db {ex}");
            }

            return GetAll();
        }

        public void Remove(Country t)
        {
            try
            {
                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "RemoveCuntre";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();

                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to run sp from db {ex}");
            }
        }

        public void Update(Country t)
        {
            try
            {
                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "UpdateCuntre";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();

                        cmd.ExecuteNonQuery();

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