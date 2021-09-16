using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
  public  interface ICustomerDAO : IBasicDb<Customer>
    {
      public  CustomerDAOPGSQL GetCustomerByUsername();

    }
}
