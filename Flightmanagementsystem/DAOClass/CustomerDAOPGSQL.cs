﻿using Flightmanagementsystem.BasicFolderClass;
using Flightmanagementsystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Flightmanagementsystem.DAOClass
{
    public class CustomerDAOPGSQL : Customer, ICustomerDAO
    {


        static SqlConnection conSQL = new SqlConnection(SQLConnection.conStr);
       public void Add(Customer t)
        {

            int result = 0;
            long id = t._Id;
            string firstName = t._FirstName;
            string lastName = t._LastName;
            string address = t._Address;
            string phonenum = t._PhoneNum;
            string creditCardNumber = t._CreditCardNum;
            long userid = t._UserId;
            Customer customer = GetCustomerByUsername(t._FirstName);

            if (customer is null)
            {
                SQLConnection.SQLOpen(conSQL);
                string cmdStr = $"INSERT INTO Customers VALUES('{firstName}','{lastName}','{address}','{phonenum}','{creditCardNumber}');SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    
                }
                SQLConnection.SQLClose(conSQL);
            }

            else
            {
                throw new CustomerAlreadyExistsException($"The country {firstName} already exists with ID {customer._Id}");
            }

         
        }

        public Customer Get(int id)
        {
            SQLConnection.SQLOpen(conSQL);
            Customer customer = null;
            string cmdStr = $"SELECT * FROM Customers WHERE Id = {id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
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
            SQLConnection.SQLClose(conSQL);
            return customer;
        }

        public List<Customer> GetAll()
        {
            SQLConnection.SQLOpen(conSQL);
            List<Customer> customers = new List<Customer>();
            string cmdStr = $"SELECT * FROM Customers";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
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
            SQLConnection.SQLClose(conSQL);
            return customers;
        }

        //GetCustomerByUsername
        public Customer GetCustomerByUsername(string username)
        {
            SQLConnection.SQLOpen(conSQL);
            Customer customer = new Customer();
            string cmdStr = $"(SELECT Id FROM Users WHERE First_Name = {username})";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
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
            SQLConnection.SQLClose(conSQL);
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
                throw new CustomerNotFoundException($"The customer  with id {t._Id} does not exist");
            }
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"DELETE FROM Customers WHERE Id = {t._Id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }

        public void Update(Customer t)
        {
            Customer customer = Get((int)t._Id);
            if (customer is null)
            {
                throw new CustomerNotFoundException($"The customer  with id {t._Id} does not exist");
            }
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"UPDATE Customers SET Id = '{t._Id}',First_Name = '{t._FirstName}'," +
                $"Last_Name = '{t._LastName}', Address = '{t._Address}',Phone_No = '{t._PhoneNum}'," +
                $"Credit_Card_No = '{t._CreditCardNum} User_Id = '{t._UserId}' WHERE Id = {t._Id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }
        public void DeleteAll()
        {
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"DELETE FROM Customers";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }



    }
}