using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
    interface IAnonymoussUserFacade
    {
        IList<Flight> GetAllFlights();
        IList<AirlineCompany> GetAllAirlineCompanies();
        Dictionary<Flight, int> GetAllFlightsVacancy();
        Flight GetFlightById(int id);
        IList<Flight> GetFlightsByOriginCountry(int countryCode);
        IList<Flight> GetFlightsByDestinationCountry(int countryCode);
        IList<Flight> GetFlightsByDepatureDate(DateTime departureDate);
        IList<Flight> GetFlightsByLandingDate(DateTime landingDate);

        
      

    }
}
