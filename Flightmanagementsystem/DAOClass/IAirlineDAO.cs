using System;
using System.Collections.Generic;
using System.Text;

namespace Flightmanagementsystem
{
   public interface IAirlineDAO 
    {
        void GetAirlineByUsername();
        void GetAllAirlineByCountry();

    }
}
