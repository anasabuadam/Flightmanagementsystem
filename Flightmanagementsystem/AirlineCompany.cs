using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
    class AirlineCompany : IPoco , IUser
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public Int64 Country_Id { get; set; }
        public Int64 User_Id { get; set; }

    }
}
