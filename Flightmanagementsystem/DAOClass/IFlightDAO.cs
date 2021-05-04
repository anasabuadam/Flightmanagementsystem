using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
   public interface IFlightDAO : IBasicDb<Flight>
    {
        void GetAllFlightsVacancy();
        void GetFlightById();
        void GetFlightByCustomer();
        void GetFlightByDepartureDate();
        void GetFlightByDestinationCountry();
        void GetFlightByLandingDate();
        void GetFlightByOriginCountry();

    }
}
