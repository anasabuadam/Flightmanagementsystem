using Flightmanagementsystem.BasicFolderClass;

namespace Flightmanagementsystem
{
    interface ILoginService
    {

        bool TryAdminLogin(string userName, string password, out LoginToken<Administrator> token);
        bool TryAirlineLogin(string userName, string password, out LoginToken<AirlineCompany> token);
        bool TryCustomerLogin(string userName, string password, out LoginToken<Customer> token);
    }
}

