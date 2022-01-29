using System;

namespace Flightmanagementsystem
{
    public class AirlineCompany : IPoco, IUser
    { 
        private int _id;
        private string _airlineName;
        private string _userName;
        private string _password;
        private int _countryCode;
        public int Id
        {

            get { return _id; }
            set { _id = value; }

        }
        public string AirlineName
        {

            get { return _airlineName; }
            set { _airlineName = value; }

        }
        public string UserName
        {

            get { return _userName; }
            set { _userName = value; }


        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public int CountryCode
        {
            get { return _countryCode; }
            set { _countryCode = value; }
        }
        public AirlineCompany() { }
        public AirlineCompany(string airlineName, string userName, string password, int countryCode)
        {
            _airlineName = airlineName;
            _userName = userName;
            _password = password;
            _countryCode = countryCode;
        }

        public override bool Equals(object obj)
        {
            return obj is AirlineCompany company &&
                   Id == company.Id;
        }

        public override int GetHashCode()
        {
            return + Id.GetHashCode();
        }

        public override string ToString()
        {
            return ($"AirlineCompany {Id} ,{AirlineName}, {UserName}, {Password}, {CountryCode}");
        }
        public static bool operator ==(AirlineCompany ac1, AirlineCompany ac2)
        {
            return (ac1.Id == ac2.Id);
        }
        public static bool operator !=(AirlineCompany ac1, AirlineCompany ac2)
        {
            return !(ac1 == ac2);
        }
    }
}
