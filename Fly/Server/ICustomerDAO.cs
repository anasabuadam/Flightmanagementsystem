using Flightmanagementsystem.BasicFolderClass;

namespace Fly.Server
{
    public interface ICustomerDAO : IBasicDb<Customer>
    {
        public Customer GetCustomerByUsername(string user);
        public Customer GetCustomer();
        public Customer GetCustomerById(int id);


    }
}

