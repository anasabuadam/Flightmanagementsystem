using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
   abstract class FacadeBase
    {
        IAirlineDAO airlineDAO = new AirlineDAOPGSQL();

        ICountryDAO countryDAO = new CountryDAOPGSQL();
        ICustomerDAO customerDAO = new CustomerDAOPGSQL();
        IFlightDAO flightDAO = new FlightDAOPGSQL();
        ITicketDAO Ticket = new TicketDAOPGSQL();

    }
}
