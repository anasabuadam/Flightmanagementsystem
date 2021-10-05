using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
   public interface IAirlineDAO : IBasicDb<AirlineCompany>
    {
        void GetAirlineByUsername();
        void GetAllAirlineByCountry();

    }
}
