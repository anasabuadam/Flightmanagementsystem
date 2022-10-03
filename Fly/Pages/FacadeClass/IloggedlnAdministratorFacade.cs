using Flightmanagementsystem.BasicFolderClass;

namespace Flightmanagementsystem.FacadeClass
{
    public interface IloggedlnAdministratorFacade
    {
        public interface ILoggedInAdministratorFacade : IAnonymousUserFacade
        {
            int CreateNewAirline(LoginToken<Administrator> token, AirlineCompany airline);
            void UpdateAirlineDetails(LoginToken<Administrator> token, AirlineCompany airline);
            void RemoveAirline(LoginToken<Administrator> token, AirlineCompany airline);
            int CreateNewCustomer(LoginToken<Administrator> token, Customer customer);
            void UpdateCustomerDetails(LoginToken<Administrator> token, Customer customer);
            void RemoveCustomer(LoginToken<Administrator> token, Customer customer);
            int CreateNewCountry(LoginToken<Administrator> token, Country country);
            void UpdateCountryName(LoginToken<Administrator> token, Country country);
            void RemoveCountry(LoginToken<Administrator> token, Country country);


        }


    }
}


