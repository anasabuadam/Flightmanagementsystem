using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
    class Customer : IPoco , IUser
    {
        public Int64 Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string Phone_No { get; set; }
        public string Credit_Card_NO { get; set; }
        public Int64 User_Id { get; set; }

        public Customer()
        {
        }

        public Customer(long id, string first_Name, string last_Name, string address, string phone_No, string credit_Card_NO, long user_Id)
        {
            Id = id;
            First_Name = first_Name;
            Last_Name = last_Name;
            Address = address;
            Phone_No = phone_No;
            Credit_Card_NO = credit_Card_NO;
            User_Id = user_Id;
        }
    }
}
