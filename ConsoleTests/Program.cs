using Flightmanagementsystem;
using Flightmanagementsystem.BasicFolderClass;
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
            //IList<AirlineCompany> airlines = userFacade.GetAllAirlineCompanies();
            //Console.WriteLine();

            //AnonymousUserFacade userFacade = new AnonymousUserFacade();
            //Flight flight = userFacade.GetFlightById(1);
            //Console.WriteLine();

            //AnonymousUserFacade anonymousUser = new AnonymousUserFacade();
            //IList<Flight> flights = anonymousUser.GetFlightsByOriginCountry(1);
            //Console.WriteLine();

            //AnonymousUserFacade anonymousUser = new AnonymousUserFacade();
            //IList<Flight> flights = anonymousUser.GetFlightsByDestinationCountry(2);
            //Console.WriteLine();

            //AnonymousUserFacade userFacade = new AnonymousUserFacade();
            //IList<Flight> flights = userFacade.GetFlightsByDepartureDate($"{DateTime.MinValue}");
            //Console.WriteLine();

            //AnonymousUserFacade userFacade = new AnonymousUserFacade();
            //IList<Flight> flights = userFacade.GetFlightsByLandingDate(DateTime.Parse(Console.ReadLine()));
            //Console.WriteLine();



            //LoginService
            LoginService loginService = new LoginService();
            _ = loginService.TryAdminLogin("ANAS", "1", out LoginToken<Administrator> token);
            Console.WriteLine(loginService);
            
































        }



    }
    
    }

