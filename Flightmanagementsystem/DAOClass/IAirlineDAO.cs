using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
   public interface IAirlineDAO : IBasicDb<Administrator>
    {
        void GetAirlineByUsername();
        void GetAllAirlineByCountry();

    }
}
