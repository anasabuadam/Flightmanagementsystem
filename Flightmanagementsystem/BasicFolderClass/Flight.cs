using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
    public class Flight :  IPoco
    {
        AirlineCompany AirlineCompany = new AirlineCompany();

        public Int64 Id { get; set; }
        public Int64 Airline_Company_Id { get; set; }
        public Int32 Origin_Country_Id { get; set; }
        public Int32 Destination_Country_Id { get; set; }
        public DateTime Departure_Time { get; set; }
        public DateTime Landing_Time { get; set; }

        public Int32 Remaining_Tickets { get; set; }

        public Flight()
        {
        }

        public Flight(long id, long airline_Company_Id, int origin_Country_Id, int destination_Country_Id, DateTime departure_Time, DateTime landing_Time, int remaining_Tickets)
        {
            Id = id;
            Airline_Company_Id = airline_Company_Id;
            Origin_Country_Id = origin_Country_Id;
            Destination_Country_Id = destination_Country_Id;
            Departure_Time = departure_Time;
            Landing_Time = landing_Time;
            Remaining_Tickets = remaining_Tickets;
        }
        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override bool Equals(object obj)
        {
            return obj is Flight flight &&
                   Id == flight.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
        public static bool operator !=(Flight flight, Flight flight1)
        {
            return !(flight == flight1);
        }
        public static bool operator ==(Flight flight, Flight flight1)
        {
            return flight == flight1;
        }

    }
}
