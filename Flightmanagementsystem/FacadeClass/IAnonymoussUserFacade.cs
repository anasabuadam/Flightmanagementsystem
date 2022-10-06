using Flightmanagementsystem.BasicFolderClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Flightmanagementsystem.FacadeClass
{
    public interface IAnonymousUserFacade
    {
        IList<Flight> GetAllFlights();
        IList<AirlineCompany> GetAllAirlineCompanies();
        Dictionary<Flight, int> GetAllFlightsVacancy();
        Flight GetFlightById(int id);
        IList<Flight> GetFlightsByOriginCountry(int countryCode);
        IList<Flight> GetFlightsByDestinationCountry(int countryCode);
        IList<Flight> GetAllFlightsByAirLineCompanies(AirlineCompany comp);
        IList<Flight> GetFlightsByDepartureDate(string departureDate);
        IList<Flight> GetFlightsByLandingDate(string landingDate);


    }
}

