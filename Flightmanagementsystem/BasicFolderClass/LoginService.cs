using Flightmanagementsystem.BasicFolderClass;
using Flightmanagementsystem.Exceptions;
using Flightmanagementsystem.FacadeClass;
using System;
using System.Collections.Generic;

namespace Flightmanagementsystem
{

    public class LoginService : ILoginService
    {
        private IAirlineDAO _airlineDAO;
        private ICustomerDAO _customerDAO;
        private IAdminDAO _administratorDAO;
        
        
        public bool TryAdminLogin(string userName, string password, out LoginToken<Administrator> token)
        {
            
            bool result = false;
            token = new LoginToken<Administrator>();
            _administratorDAO = new AdminDAOPGSQL();
            Administrator administrator = _administratorDAO.Get(Convert.ToInt64(password));
            if (userName ==  administrator.First_Name || password == administrator.Id.ToString())
            {
                token = new LoginToken<Administrator>();
                token._user = new  Administrator();
                result = true;
            }
            else
            {
                throw new UserNotFoundException(userName);
            }

            return result;
        }

        public bool TryAirlineLogin(string userName, string password, out LoginToken<AirlineCompany> token)
        {

            bool result = false;
            token = new LoginToken<AirlineCompany>();
            AirlineCompany airline = null;

            _airlineDAO = new AirlineDAOMSSQL();
            AirlineDAOMSSQL _airlineDAO1 = (AirlineDAOMSSQL)_airlineDAO;
            airline = _airlineDAO1.GetAirlineByUserName(userName);
            if (!(airline is null))
            {
                if (airline._Name != userName)
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
            token = new LoginToken<Customer>();
            Customer customer = new Customer();
            
            _customerDAO = new CustomerDAOPGSQL();
            CustomerDAOPGSQL _customerDAO1 = (CustomerDAOPGSQL)_customerDAO;
            customer = _customerDAO1.GetCustomerByUsername(userName);
            if (!(customer is null))
            {
                if (password == customer._Id.ToString())
                {
                    if (customer._FirstName != userName)
                    {
                        throw new WrongPasswordException("This UserName is wrong");
                    }
                    else
                    {
                        
                        token = new LoginToken<Customer>();
                        token._user = customer; 
                        result = true;
                        
                    }
                    throw new WrongPasswordException("This password is wrong");
                }
               
            }
            return result;
        }
        public bool TryLogin(string userName, string password, out ILoginToken token)
        {
            Administrator administrator = new Administrator();
            Customer customer = new Customer();
            AirlineCompany airline = new AirlineCompany();
            bool result = false;
            LoginToken<Administrator> tokenA = new LoginToken<Administrator>();
            result = TryAdminLogin(administrator.First_Name, administrator.Id.ToString(), out tokenA);
            if (result == true)
                token = tokenA;
            else
            {
                LoginToken<AirlineCompany> tokenAC = new  LoginToken<AirlineCompany>();
                result = TryAirlineLogin(airline._Name , airline._id.ToString(), out tokenAC);
                if (result == true)
                    token = tokenAC;
                else
                {
                    LoginToken<Customer> tokenC = new LoginToken<Customer>();
                    result = TryCustomerLogin(customer._FirstName, customer._Id.ToString(), out LoginToken<Customer> tokin) ;
                    if (result == true)
                        tokin = tokenC;
                    else
                        throw new UserNotFoundException("User Not Found");
                }

            }

            token = new  LoginToken<Administrator>();
            return result;


        }

    }
}


