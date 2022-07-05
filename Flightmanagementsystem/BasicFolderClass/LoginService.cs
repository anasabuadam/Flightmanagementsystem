using Flightmanagementsystem.BasicFolderClass;
using Flightmanagementsystem.Exceptions;

namespace Flightmanagementsystem
{

    public class LoginService : ILoginService
    {
        private IAirlineDAO _airlineDAO;
        private ICustomerDAO _customerDAO;
        public bool TryAdminLogin(string userName, string password, out LoginToken<Administrator> token)
        {
            bool result = false;
            token = null;
            Administrator administrator = new Administrator();

            if (userName == administrator.First_Name  && password == administrator.Id.ToString())
            {
                token = new LoginToken<Administrator>();
                token._user = new Administrator();
                result = true;
            }
            return result;
        }

        public bool TryAirlineLogin(string userName, string password, out LoginToken<AirlineCompany> token)
        {
            bool result = false;
            token = null;
            AirlineCompany airline = null;

            _airlineDAO = new AirlineDAOMSSQL();
            AirlineDAOMSSQL _airlineDAO1 = (AirlineDAOMSSQL)_airlineDAO;
            airline = _airlineDAO1.GetAirlineByUserName(userName);
            if (!(airline is null))
            {
                if (airline._Name != password)
                {
                    throw new WrongPasswordException("This password is wrong");
                }
                else
                {
                    token = new LoginToken<AirlineCompany>();
                    token._user = airline;
                    result = true;
                }
            }
            return result;

        }

        public bool TryCustomerLogin(string userName, string password, out LoginToken<Customer> token)
        {
            bool result = false;
            token = null;
            Customer customer = null;

            _customerDAO = new CustomerDAOPGSQL();
            CustomerDAOPGSQL _customerDAO1 = (CustomerDAOPGSQL)_customerDAO;
            customer = _customerDAO1.GetCustomerByUsername(userName.Trim());
            if (!(customer is null))
            {
                if (customer._FirstName != password)
                {
                    throw new WrongPasswordException("This password is wrong");
                }
                else
                {
                    token = new LoginToken<Customer>();
                    token._user = customer;
                    result = true;
                }
            }
            return result;
        }
        public bool TryLogin(string userName, string password, out ILoginToken token)
        {
            bool result = false;
            LoginToken<Administrator> tokenA = null;
            result = TryAdminLogin(userName, password, out tokenA);
            if (result == true)
                token = tokenA;
            else
            {
                LoginToken<AirlineCompany> tokenAC = null;
                result = TryAirlineLogin(userName, password, out tokenAC);
                if (result == true)
                    token = tokenAC;
                else
                {
                    LoginToken<Customer> tokenC = null;
                    result = TryCustomerLogin(password, userName, out LoginToken<Customer> tokin) ;
                    if (result == true)
                        tokin = tokenC;
                    else
                        throw new UserNotFoundException("User Not Found");
                }

            }

            token = null;
            return result;


        }

    }
}


