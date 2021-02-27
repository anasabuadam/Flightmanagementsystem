using Npgsql;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Flightmanagementsystem
{
    internal class CountryDAOPGSQL : ICountryDAO
    {
        string conn_string = "";
        public void Add()
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

                }
            }
        }

        public void Get()
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

        public void GetAll()
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

        public void Remove()
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

        public void Update()
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
    }
}