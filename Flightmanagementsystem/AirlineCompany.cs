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

        public AirlineCompany()
        {
        }

        public AirlineCompany(long id, string name, long country_Id, long user_Id)
        {
            Id = id;
            Name = name;
            Country_Id = country_Id;
            User_Id = user_Id;
        }
    }
}
