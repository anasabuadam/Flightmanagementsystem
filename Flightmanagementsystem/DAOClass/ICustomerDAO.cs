using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
    interface ICustomerDAO : IBasicDb<Customer>
    {
        void GetCustomerByUsername();

    }
}
