using System;

namespace Flightmanagementsystem
{

    public class Ticket : IPoco, IUser
    {
        public Int64 _Id { get; set; }
        public Int64 FlightId { get; set; }
        public Int64 CustomerId { get; set; }

        
    


        public Ticket() { }

        public Ticket(long id, long flightId, long customerId)
        {
            _Id = id;
            FlightId = flightId;
            CustomerId = customerId;
        }

        public override bool Equals(object obj)
        {
            return obj is Ticket t &&
                   _Id == t._Id;
        }

        public override int GetHashCode()
        {
            return +_Id.GetHashCode();
        }

        public override string ToString()
        {
            return ($"Ticket {_Id} ,{FlightId}, {CustomerId}");
        }



        public static bool operator ==(Ticket t1, Ticket t2)
        {
            return (t1._Id == t2._Id);
        }
        public static bool operator !=(Ticket t1, Ticket t2)
        {
            return !(t1 == t2);
        }

    }
}
