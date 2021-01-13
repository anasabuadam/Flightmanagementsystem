using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
    class Ticket : IPoco
    {
        Flight Flight = new Flight();
        Customer Customer = new Customer();

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

        public override bool Equals(object obj)
        {
            return obj is Ticket ticket &&
                   Id == ticket.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
        public static bool operator !=(Ticket ticket, Ticket  ticket1)
        {
            return !(ticket == ticket1);
        }
        public static bool operator ==(Ticket ticket, Ticket ticket1)
        {
            return ticket == ticket1;
        }
    }
}
