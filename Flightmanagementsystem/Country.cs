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
    }
}
