using Flightmanagementsystem.BasicFolderClass;
using Flightmanagementsystem.DAOClass;
using IAirlineDAO = Flightmanagementsystem.DAOClass.IAirlineDAO;

namespace Flightmanagementsystem.FacadeClass
{
    public abstract class FacadeBase
    {
        protected IAirlineDAO _airlineDAO;

        protected ICountryDAO _countryDAO;

        protected ICustomerDAO _customerDAO;

        protected IFlightDAO _flightDAO;

        protected ITicketDAO _ticketDAO;
        protected IUser _userDAO;
        protected IUserRoles _userRoles;



        public FacadeBase()
        {
            _airlineDAO = new AirlineDAOMSSQL();
            _countryDAO = new CountryDAOMSSQL();
            _customerDAO = new CustomerDAOPGSQL();
            _flightDAO = new FlightDAOPGSQL();
            _ticketDAO = new TicketDAOMSSQL();
            _userDAO = new UserDAOPGSQL();
            _userRoles = new UserRolesDAOPGSQL();

        }
    }
}

