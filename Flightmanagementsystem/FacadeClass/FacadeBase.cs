using Flightmanagementsystem.DAOClass;

namespace Flightmanagementsystem
{
    public abstract class FacadeBase
    {
        protected IAirlineDAO _airlineDAO;

        protected ICountryDAO _countryDAO;

        protected ICustomerDAO _customerDAO;

        protected IFlightDAO _flightDAO;

        protected ITicketDAO _ticketDAO;



        public FacadeBase()
        {
            _airlineDAO = new AirlineDAOMSSQL();
            _countryDAO = new CountryDAOMSSQL();
            _customerDAO = new CustomerDAOPGSQL();
            _flightDAO = new FlightDAOPGSQL();
            _ticketDAO = new TicketDAOMSSQL();

        }
    }
}

