using System;
using System.Collections.Generic;
using System.Text;
using WebGrease.Configuration;

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
          
            _airlineDAO = new AirlineCompany();
            _countryDAO = new Country();
            _customerDAO =Customer;
            _adminDAO = Administrator;
            _user = User;
            _flightDAO = Flight;
            _ticketDAO = Ticket;
        }
        public override string ToString()
        {
            return $"{Newtonsoft.Json.JsonConvert.SerializeObject(this)}";
        }
    }

}
