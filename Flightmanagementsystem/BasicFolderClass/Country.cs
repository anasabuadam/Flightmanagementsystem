using System;

namespace Flightmanagementsystem
{

    public class Country : IPoco, IUser
    {
        private int _id;
        private string _countryName;

        public int Id
        {

            get { return _id; }
            set { _id = value; }

        }
        public string CountryName
        {

            get { return _countryName; }
            set { _countryName = value; }

        }

        public Country() { }
        public Country(string countryName)
        {
            _countryName = countryName;

        }


        public override bool Equals(object obj)
        {
            return obj is Country c &&
                   Id == c.Id;
        }

        public override int GetHashCode()
        {
            return  + Id.GetHashCode();
        }

        public override string ToString()
        {
            return ($"Country {Id} ,{CountryName}");
        }



        public static bool operator ==(Country c1, Country c2)
        {
            if (c1 == null && c2 == null)
                return true;
            if (c1 == null && c2 != null || c2 == null && c1 != null)
                return false;
            return (c1.Id == c2.Id);
        }
        public static bool operator !=(Country c1, Country c2)
        {
            return !(c1 == c2);
        }
    }
}