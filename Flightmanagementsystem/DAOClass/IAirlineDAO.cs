using Flightmanagementsystem.BasicFolderClass;
using System.Collections.Generic;

namespace Flightmanagementsystem.DAOClass
{
    public interface IAirlineDAO : IBasicDb<AirlineCompany>
    {
        AirlineCompany GetAirlineByUserName(string name);
        List<AirlineCompany> GetAllAirlinesCompanyByCountry(int countryId);
    }

}
