namespace Flightmanagementsystem
{
    public interface ICustomerDAO : IBasicDb<Customer>
    {
        public Customer GetCustomerByUsername(string user);

    }
}

