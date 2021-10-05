using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
    public class AirlineCompany : IPoco , IUser
    {
        User User = new User();

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
        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override bool Equals(object obj) => obj is AirlineCompany company &&
                   Id == company.Id;

        public override int GetHashCode() => HashCode.Combine(Id);
        public static bool operator !=(AirlineCompany airlineCompany, AirlineCompany airlineCompany1)
        {
            return !(airlineCompany == airlineCompany1);
        }
        public static bool operator ==(AirlineCompany airlineCompany, AirlineCompany airlineCompany1)
        {
            return airlineCompany == airlineCompany1;
        }

    }
}
