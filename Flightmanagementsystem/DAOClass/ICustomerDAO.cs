using Flightmanagementsystem.BasicFolderClass;

namespace Flightmanagementsystem.DAOClass
{
    public interface ICustomerDAO : IBasicDb<Customer>
    {
        public Customer GetCustomerByUsername(string user);

    }
}

