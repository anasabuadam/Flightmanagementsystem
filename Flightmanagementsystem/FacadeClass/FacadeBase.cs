namespace Flightmanagementsystem
{
    public abstract class FacadeBase
    {
        protected IAirlineDAO _airlineDAO;
        protected ICountryDAO _countryDAO;
        protected ICustomerDAO _customerDAO;
        protected IAdminDAO _adminDAO;
        protected IUser _user;
        protected IFlightDAO _flightDAO;
        protected ITicketDAO _ticketDAO;
        public bool? TreatWarningsAsErrors { get; }
        protected FacadeBase(bool test)
        {

            _airlineDAO = new AirlineDAOPGSQL();
            _countryDAO = new CountryDAOPGSQL();
            _customerDAO = new CustomerDAOPGSQL();
            _adminDAO = new AdminDAOPGSQL();
            _user = new User();
            _flightDAO = new FlightDAOPGSQL();
            _ticketDAO = new TicketDAOPGSQL();
        }
        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }

}
