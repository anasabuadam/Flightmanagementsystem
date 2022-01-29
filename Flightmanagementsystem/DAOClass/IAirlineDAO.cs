using System.Collections.Generic;

namespace Flightmanagementsystem
{
    public interface IAirlineDAO : IBasicDb<AirlineCompany>
    {
    AirlineCompany GetAirlineByUserName(string name);
        List<AirlineCompany> GetAllAirlinesCompanyByCountry(int countryId);
    }

}
