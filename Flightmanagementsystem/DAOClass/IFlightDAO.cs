namespace Flightmanagementsystem
{
    public interface IFlightDAO : IBasicDb<Flight>
    {
        FlightDAOPGSQL GetAllFlightsVacancy();
        FlightDAOPGSQL GetFlightById();
        FlightDAOPGSQL GetFlightByCustomer();
        FlightDAOPGSQL GetFlightByDepartureDate();
        FlightDAOPGSQL GetFlightByDestinationCountry();
        FlightDAOPGSQL GetFlightByLandingDate();
        FlightDAOPGSQL GetFlightByOriginCountry();

    }
}
