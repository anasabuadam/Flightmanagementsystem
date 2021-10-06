namespace Flightmanagementsystem
{
    public interface IAirlineDAO : IBasicDb<AirlineCompany>
    {
        void GetAirlineByUsername();
        void GetAllAirlineByCountry();

    }
}
