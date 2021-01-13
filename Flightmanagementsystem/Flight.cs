using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
    class Flight : IPoco
    {
        public Int64 Id { get; set; }
        public Int64 Airline_Company_Id { get; set; }
        public Int32 Origin_Country_Id { get; set; }
        public Int32 Destination_Country_Id { get; set; }
        public DateTime Departure_Time { get; set; }
        public DateTime Landing_Time { get; set; }

        public Int32 Remaining_Tickets { get; set; }

    }
}
