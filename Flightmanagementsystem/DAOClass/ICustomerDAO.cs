namespace Flightmanagementsystem
{
    public interface ICustomerDAO : IBasicDb<Customer>
    {
        public CustomerDAOPGSQL GetCustomerByUsername();

    }
}
