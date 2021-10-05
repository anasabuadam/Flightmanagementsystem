using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Flightmanagementsystem
{
  public  class CustomerDAOPGSQL : ICustomerDAO
    {
        string conn_string = "";

        public void Add(Customer t)
        {
            try
            {


                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "AddCoustomer";
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

        public Customer Get(int id)
        {
            try
            {


                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "GetCustomer";
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
            return Get(id);
        }

       IList<Customer> IBasicDb<Customer>.GetAll()
        {
            try
            {


                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "GetCustomer";
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
            return null;
        }

        public CustomerDAOPGSQL GetCustomerByUsername()
        {
            try
            {


                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "GetCustomerByUsername";
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
            return GetCustomerByUsername();
        }

        public void Remove(Customer t)
        {
            try
            {


                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "RemoveCustomer";
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

        public void Update(Customer t)
        {
            try
            {


                using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "UpdateCustomer";
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
