using Flightmanagementsystem;
using Flightmanagementsystem.BasicFolderClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flightmanagementsystem.DAOClass
{



    public interface IFlightDAO : IBasicDb<Flight>
    {
        Dictionary<Flight, int> GetAllFlightsVacancy();
        // Flight GetFlightById(int id);=> Get(id)

        List<Flight> GetFlightsByOriginCountry(int countryCode);
        List<Flight> GetFlightsByDestinationCountry(int countryCode);

        List<Flight> GetFlightsByDepartureTime(string departureDate);

        List<Flight> GetFlightsByLandingTime(string landingDate);

        List<Flight> GetFlightsByCustomer(Customer customer);

    }
}


