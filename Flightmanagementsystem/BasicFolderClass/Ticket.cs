using System;

namespace Flightmanagementsystem
{

    public class Ticket : IPoco, IUser
    {
        public int _id;
        private int _flightId;
        private int _customerId;

        public int Id
        {

            get { return _id; }
            set { _id = value; }

        }
        public int FlightId
        {

            get { return _flightId; }
            set { _flightId = value; }

        }
        public int CustomerId
        {

            get { return _customerId; }
            set { _customerId = value; }

        }


        public Ticket() { }

        public Ticket(int flightId, int customerId)
        {
            _flightId = flightId;
            _customerId = customerId;
        }

        public override bool Equals(object obj)
        {
            return obj is Ticket t &&
                   Id == t.Id;
        }

        public override int GetHashCode()
        {
            return +Id.GetHashCode();
        }

        public override string ToString()
        {
            return ($"Ticket {Id} ,{FlightId}, {CustomerId}");
        }



        public static bool operator ==(Ticket t1, Ticket t2)
        {
            return (t1.Id == t2.Id);
        }
        public static bool operator !=(Ticket t1, Ticket t2)
        {
            return !(t1 == t2);
        }

    }
}
