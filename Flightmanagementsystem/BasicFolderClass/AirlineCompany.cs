using System;

namespace Flightmanagementsystem.BasicFolderClass
{
    public class AirlineCompany : IPoco, IUser
    {
        public long _id { get; set; }
        public string _Name { get; set; }
        public int CountryId { get; set; }
        public long User_Id { get; set; }



        public AirlineCompany() { }

        public AirlineCompany(long id, string name, int countryId, long user_Id)
        {
            _id = id;
            _Name = name;
            CountryId = countryId;
            User_Id = user_Id;
        }

        public override bool Equals(object obj)
        {
            return obj is AirlineCompany company &&
                   _id == company._id;
        }

        public override int GetHashCode()
        {
            return +_id.GetHashCode();
        }

        public override string ToString()
        {
            return $"AirlineCompany {_id} ,{_Name}, {CountryId},  {User_Id}";
        }
        public static bool operator ==(AirlineCompany ac1, AirlineCompany ac2)
        {
            return ac1._id == ac2._id;
        }
        public static bool operator !=(AirlineCompany ac1, AirlineCompany ac2)
        {
            return !(ac1 == ac2);
        }
    }
}
