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

    }
}
