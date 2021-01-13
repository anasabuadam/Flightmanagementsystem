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

    }
}
