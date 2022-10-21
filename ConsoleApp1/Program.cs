using Flightmanagementsystem.BasicFolderClass;
using Flightmanagementsystem.DAOClass;
using Flightmanagementsystem.FacadeClass;
using System.Collections.Generic;
using Flightmanagementsystem.Exceptions;
using System;
using Flightmanagementsystem;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {



            //AnonymousUserFacade userFacade = new AnonymousUserFacade();
            //IList<AirlineCompany> airlines = userFacade.GetAllAirlineCompanies();
            //Console.WriteLine(airlines);

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




            //LoginService loginService = new LoginService();
            //_ = loginService.TryAdminLogin("ANAS", "1", out LoginToken<Administrator> token);
            //Console.WriteLine(loginService);

            ////LoginService UserLogin
            //LoginService loginService = new LoginService();
            //_ = loginService.TryLogin("ANAS", "1", out ILoginToken token);

            //LoginService loginService = new LoginService();
            //loginService.TryAdminLogin("ANAS", "1", out LoginToken<Administrator> t);
            //AdminDAOPGSQL adminDAOPGSQL = new AdminDAOPGSQL();
            //Administrator administrator = adminDAOPGSQL.Get(t._user.Id);
            //adminDAOPGSQL.Remove(administrator);
            //    Console.ReadLine();

            //User user = new User();
            //UserDAOPGSQL userDAOPGSQL = new UserDAOPGSQL();
            //user = userDAOPGSQL.Get(2);
            //Console.ReadLine();


        }
    }
}
