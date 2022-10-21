using Flightmanagementsystem.BasicFolderClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem.FacadeClass
{
    public interface FlightFaced
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
        IList<(Flight, Flight)> GetFlightsByLocation(string location);
    }
}
