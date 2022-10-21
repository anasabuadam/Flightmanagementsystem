using Flightmanagementsystem.DAOClass;
using System;

namespace Flightmanagementsystem.BasicFolderClass
{

    public class Country :  ICustomerDAO,IPoco
    {
        public long _id { get; set; }
        public string _Name { get; set; }

        public Country() { }

        public Country(long id, string name)
        {
            _id = id;
            _Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is Country c &&
                   _id == c._id;
        }

        public override int GetHashCode()
        {
            return +_id.GetHashCode();
        }

        public override string ToString()
        {
            return $"Country {_id} ,{_Name}";
        }



        public static bool operator ==(Country c1, Country c2)
        {
            if (c1 == null && c2 == null)
                return true;
            if (c1 == null && c2 != null || c2 == null && c1 != null)
                return false;
            return c1._id == c2._id;
        }
        public static bool operator !=(Country c1, Country c2)
        {
            return !(c1 == c2);
        }
    }
}