using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
    interface IAnonymoussUserFacade
    {
        void GetAllAirlineCompanies();
        void GetAllFlights();
        void GetAllFlightsVacancy();
        void GetFlightById();
        void GetFlightsByDepatrureDate();
        void GetFlightsByDestinationCountry();
        void GetFlightsByLandingDate();
        void GetFlightsByOriginCountry();


    }
}
