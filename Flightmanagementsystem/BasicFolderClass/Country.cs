using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
    class Country : IPoco  , IUser
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }

        public Country()
        {
        }

        public Country(long id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }

        public override bool Equals(object obj) => obj is Country country &&
                   Id == country.Id;

        public override int GetHashCode() => HashCode.Combine(Id);

        public static bool operator !=(Country country, Country country1)
        {
            return !(country == country1);
        }
        public static bool operator ==(Country country, Country country1)
        {
            return country == country1;
        }

    }
}
