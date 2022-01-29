using Flightmanagementsystem.DAOClass;
using Flightmanagementsystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Flightmanagementsystem
{
    public class  CustomerDAOPGSQL : Customer , ICustomerDAO
    {


        static SqlConnection conSQL = new SqlConnection(SQLConnection.conStr);
        public int Add(Customer t)
        {

            int result = 0;
            string firstName = t.FirstName; 
            string lastName = t.LastName;
            string userName = t.UserName;
            string password = t.Password;
            string address = t.Address;
            string phoneNo = t.PhoneNo;
            string creditCardNumber = t.CreditCardNumber;
            Customer customer = GetCustomerByUsername("");

            if (customer is null)
            {
                SQLConnection.SQLOpen(conSQL);
                string cmdStr = $"INSERT INTO Customers VALUES('{firstName}','{lastName}','{userName}','{password}','{address}','{phoneNo}','{creditCardNumber}');SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                SQLConnection.SQLClose(conSQL);
            }

            else
            {
                throw new CustomerAlreadyExistsException($"The country {userName} already exists with ID {customer.Id}");
            }

            return result;
        }

        public Customer Get(int id)
        {
            SQLConnection.SQLOpen(conSQL);
            Customer customer = null;
            string cmdStr = $"SELECT * FROM Customers WHERE ID = {id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        customer = new Customer
                        {
                            Id = (int)reader["ID"],
                            FirstName = (string)reader["FIRST_NAME"],
                            LastName = (string)reader["LAST_NAME"],
                            UserName = (string)reader["USER_NAME"],
                            Password = (string)reader["PASSWORD"],
                            Address = (string)reader["ADDRESS"],
                            PhoneNo = (string)reader["PHONE_NO"],
                            CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"],
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
                            Id = (int)reader["ID"],
                            FirstName = (string)reader["FIRST_NAME"],
                            LastName = (string)reader["LAST_NAME"],
                            UserName = (string)reader["USER_NAME"],
                            Password = (string)reader["PASSWORD"],
                            Address = (string)reader["ADDRESS"],
                            PhoneNo = (string)reader["PHONE_NO"],
                            CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"],
                        };
                        customers.Add(customer);
                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return customers;
        }

        public Customer GetCustomerByUsername(string user)
        {
            SQLConnection.SQLOpen(conSQL);
            Customer c = null; ;
            string cmdStr = @$"SELECT * FROM Customers WHERE USER_NAME = '{user}'";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        c = new Customer
                        {
                            Id = (int)reader["ID"],
                            FirstName = (string)reader["FIRST_NAME"],
                            LastName = (string)reader["LAST_NAME"],
                            UserName = (string)reader["USER_NAME"],
                            Password = (string)reader["PASSWORD"],
                            Address = (string)reader["ADDRESS"],
                            PhoneNo = (string)reader["PHONE_NO"],
                            CreditCardNumber = (string)reader["CREDIT_CARD_NUMBER"]
                        };
                       

                    }
                }
            }

            SQLConnection.SQLClose(conSQL);
            return c;   
        }

        public void Remove(Customer t)
        {
            Customer customer = Get(t.Id);
            if (customer is null)
            {
                throw new CustomerNotFoundException($"The customer  with id {t.Id} does not exist");
            }
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"DELETE FROM Customers WHERE ID = {t.Id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }

        public void Update(Customer t)
        {
            Customer customer = Get(t.Id);
            if (customer is null)
            {
                throw new CustomerNotFoundException($"The customer  with id {t.Id} does not exist");
            }
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"UPDATE Customers SET FIRST_NAME = '{t.FirstName}',LAST_NAME = '{t.LastName}'," +
                $"USER_NAME = '{t.UserName}', PASSWORD = '{t.Password}',Address = '{t.Address}',PHONE_NO = '{t.PhoneNo}'," +
                $"CREDIT_CARD_NUMBER = '{t.CreditCardNumber}' WHERE ID = {t.Id}";
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



        void IBasicDb<Customer>.Add(Customer t)
        {
            throw new NotImplementedException();
        }

        Customer IBasicDb<Customer>.Get(long id)
        {
            throw new NotImplementedException();
        }

        IList<Customer> IBasicDb<Customer>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IBasicDb<Customer>.Remove(Customer t)
        {
            throw new NotImplementedException();
        }

        void IBasicDb<Customer>.Update(Customer t)
        {
            throw new NotImplementedException();
        }

    }
}