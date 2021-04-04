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
        protected IAirlineDAO _airlineDAO;
        protected ICountryDAO _countryDAO;
        protected ICustomerDAO _customerDAO;
        protected IAdminDAO _adminDAO;
        protected IUser _userDAO;
        protected IFlightDAO _flightDAO;
        protected ITicketDAO _ticketDAO;


    }
}
