using Fly.Server;
using Flightmanagementsystem.Exceptions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Fly.Common
{
    public class CustomerDAOPGSQL : Customer, ICustomerDAO
    {
        public readonly IConfiguration configuration;
        public readonly SqlConnection sqlConnection;

        public CustomerDAOPGSQL(IConfiguration configuration)
        {
            this.configuration = configuration;
            sqlConnection = new SqlConnection(configuration["ConnectionStrings:DbConn"]);

        }
        public int Add(Customer t)
        {

            int result = 0;
            long id = t._Id;
            string firstName = t._FirstName;
            string lastName = t._LastName;
            string address = t._Address;
            string phonenum = t._PhoneNum;
            string creditCardNumber = t._CreditCardNum;
            long userid = t._UserId;
            Customer customer = GetCustomerByUsername("");

            if (customer is null)
            {
              
                string cmdStr = $"INSERT INTO Customers VALUES('{firstName}','{lastName}','{address}','{phonenum}','{creditCardNumber}');SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(cmdStr, sqlConnection))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
               
            }

            else
            {
                throw new Exception($"The country {firstName} already exists with ID {customer._Id}");
            }

            return result;
        }

        public Customer Get(int id)
        {
  
            Customer customer = null;
            string cmdStr = $"SELECT * FROM Customers WHERE Id = {id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, sqlConnection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        customer = new Customer
                        {
                            _Id = (int)reader["Id"],
                            _FirstName = (string)reader["First_Name"],
                            _LastName = (string)reader["Last_Name"],
                            _Address = (string)reader["Address"],
                            _PhoneNum = (string)reader["Phone_No"],
                            _CreditCardNum = (string)reader["Credit_Card_No"],
                            _UserId = (int)reader["User_Id"],
                        };

                    }
                }
            }
           
            return customer;
        }

        public List<Customer> GetAll()
        {

            List<Customer> customers = new List<Customer>();
            string cmdStr = $"SELECT * FROM Customers";
            using (SqlCommand cmd = new SqlCommand(cmdStr, sqlConnection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer customer = new Customer
                        {
                            _Id = (int)reader["Id"],
                            _FirstName = (string)reader["First_Name"],
                            _LastName = (string)reader["Last_Name"],
                            _Address = (string)reader["Address"],
                            _PhoneNum = (string)reader["Phone_No"],
                            _CreditCardNum = (string)reader["Credit_Card_No"],
                            _UserId = (int)reader["User_Id"],
                        };
                        customers.Add(customer);
                    }
                }
            }

            return customers;
        }

        //GetCustomerByUsername
        public Customer GetCustomerByUsername(string username)
        {
           
            Customer customer = new Customer();
            string cmdStr = $"(SELECT Id FROM Users WHERE First_Name = {username})";
            using (SqlCommand cmd = new SqlCommand(cmdStr, sqlConnection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        customer = new Customer
                        {
                            _Id = (long)reader["Id"],
                            _FirstName = (string)reader["First_Name"],
                            _LastName = (string)reader["Last_Name"],
                            _Address = (string)reader["Address"],
                            _PhoneNum = (string)reader["Phone_No"],
                            _CreditCardNum = (string)reader["Credit_Card_No"],
                            _UserId = (long)reader["User_Id"],
                        };

                    }
                }
            }
        
            return customer;
        }

        //public Customer GetCustomerByUsername(string user)
        //{
        //    SQLConnection.SQLOpen(conSQL);
        //    Customer c = new Customer(); ;
        //    string cmdStr = @$"SELECT * FROM Customers WHERE First_Name = '{user}'";
        //    using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
        //    {
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            if (reader.HasRows)
        //            {
        //                reader.Read();
        //                c = new Customer
        //                {
        //                    _Id = (Int64)reader["Id"],
        //                    _FirstName = (string)reader["First_Name"],
        //                    _LastName = (string)reader["Last_Name"],
        //                    _Address = (string)reader["Address"],
        //                    _PhoneNum = (string)reader["Phone_No"],
        //                    _CreditCardNum = (string)reader["Credit_Card_No"],
        //                    _UserId = (Int64)reader["User_Id"],
        //                };


        //            }
        //        }
        //    }

        //    SQLConnection.SQLClose(conSQL);
        //    return c;
        //}

        public void Remove(Customer t)
        {
            Customer customer = Get((int)t._Id);
            if (customer is null)
            {
                throw new Exception($"The customer  with id {t._Id} does not exist");
            }

            string cmdStr = $"DELETE FROM Customers WHERE Id = {t._Id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, sqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
         
        }

        public void Update(Customer t)
        {
            sqlConnection.Open();
            Customer customer = Get((int)t._Id);
            if (customer is null)
            {
                throw new Exception($"The customer  with id {t._Id} does not exist");
            }
          
            string cmdStr = $"UPDATE Customers SET Id = '{t._Id}',First_Name = '{t._FirstName}'," +
                $"Last_Name = '{t._LastName}', Address = '{t._Address}',Phone_No = '{t._PhoneNum}'," +
                $"Credit_Card_No = '{t._CreditCardNum} User_Id = '{t._UserId}' WHERE Id = {t._Id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, sqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
            sqlConnection.Close();
        }
        public void DeleteAll()
        {
            sqlConnection.Open();
            string cmdStr = $"DELETE FROM Customers";
            using (SqlCommand cmd = new SqlCommand(cmdStr, sqlConnection))
            {
                cmd.ExecuteNonQuery();
            }
            sqlConnection.Close();
        }

        public Customer GetCustomer()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        void IBasicDb<Customer>.Add(Customer t)
        {
            throw new NotImplementedException();
        }

        public Customer Get(long id)
        {
            throw new NotImplementedException();
        }

        IList<Customer> IBasicDb<Customer>.GetAll()
        {
            throw new NotImplementedException();
        }
    }


}