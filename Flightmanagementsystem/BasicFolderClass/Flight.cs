using Flightmanagementsystem.DAOClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flightmanagementsystem.BasicFolderClass
{
    public class Flight 


    {
        public long _Id { get; set; }
        public long _AirlineCompanyId { get; set; }
        public int _OriginCountryId { get; set; }
        public int _DestinationCountryId { get; set; }
        public string _DepartureTime { get; set; }
        public string _LandingTime { get; set; }
        public int _RimainingTickets { get; set; }

        public Flight(long id, long airlineCompanyId, int originCountryId, int destinationCountryId, string departureTime, string landingTime, int rimainingTickets)
        {
            _Id = id;
            _AirlineCompanyId = airlineCompanyId;
            _OriginCountryId = originCountryId;
            _DestinationCountryId = destinationCountryId;
            _DepartureTime = departureTime;
            _LandingTime = landingTime;
            _RimainingTickets = rimainingTickets;
        }

        public Flight() { }



        public override bool Equals(object obj)
        {
            return obj is Flight f &&
                   _Id == f._Id;
        }



        public override string ToString()
        {
            return $"Flight {_Id} ,{_AirlineCompanyId}, {_OriginCountryId}, {_DestinationCountryId}, {_DepartureTime}, {_LandingTime}, {_RimainingTickets}";
        }

        public override int GetHashCode()
        {
            return +_Id.GetHashCode();
        }

        public static bool operator ==(Flight f1, Flight f2)
        {
            return f1._Id == f2._Id;
        }
        public static bool operator !=(Flight f1, Flight f2)
        {
            return !(f1 == f2);
        }
    }
}
