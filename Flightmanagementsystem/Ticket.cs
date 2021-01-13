using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
    class Ticket : IPoco
    {
        public Int64 Id { get; set; }
        public Int64 Flight_Id { get; set; }
        public Int32 Customer_Id { get; set; }

        public Ticket()
        {
        }

        public Ticket(long id, long flight_Id, int customer_Id)
        {
            Id = id;
            Flight_Id = flight_Id;
            Customer_Id = customer_Id;
        }
    }
}
