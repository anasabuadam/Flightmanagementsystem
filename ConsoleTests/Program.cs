using Flightmanagementsystem;
using Flightmanagementsystem.FacadeClass;
using System;
using System.Collections.Generic;
namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //AnonymousUserFacade facade = new AnonymousUserFacade();
            //IList<Flight> flights = facade.GetFlights();
            //Console.WriteLine();

            //AnonymousUserFacade userFacade = new AnonymousUserFacade();
            //IList<AirlineCompany> airlines = userFacade.AllAirlineCompanies();
            //Console.WriteLine();

            //AnonymousUserFacade userFacade = new AnonymousUserFacade();
            //Flight flight = userFacade.GetFlihgtById(1);
            //Console.WriteLine();

            //AnonymousUserFacade anonymousUser = new AnonymousUserFacade();
            //IList<Flight> flights = anonymousUser.GetFlightsByOriginCountry(1);
            //Console.WriteLine();

            //  AnonymousUserFacade anonymousUser = new AnonymousUserFacade();
            //IList<Flight> flights = anonymousUser.GetFlightsByDestinationCountry(2);
            //  Console.WriteLine();

            //AnonymousUserFacade userFacade = new AnonymousUserFacade();
            //IList<Flight> flights = userFacade.GetFlightsByDepatureDate(DateTime.Parse(Console.ReadLine()));
            //Console.WriteLine();

            AnonymousUserFacade userFacade = new AnonymousUserFacade();
            IList<Flight> flights = userFacade.GetFlightsByLandingDate(DateTime.Parse(Console.ReadLine()));
            Console.WriteLine();



        }
    }
}
