using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Flightmanagementsystem.FacadeClass
{
    class ClassAnonymousUserFacade : IAnonymoussUserFacade
    {
        string conn_string = "";
        public IList<AirlineCompany> AllAirlineCompanies
        {
            get
            {
                try
                {


                    using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {

                            cmd.CommandText = "GetAirline";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = sqlConnection1;

                            sqlConnection1.Open();

                            cmd.ExecuteNonQuery();
                            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to run sp from db {ex}");
                }
                return AllAirlineCompanies;
            }
        }

        public IList<Flight> AllFlights
        {
            get
            {
                try
                {


                    using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {

                            cmd.CommandText = "GetFlight";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = sqlConnection1;

                            sqlConnection1.Open();

                            cmd.ExecuteNonQuery();
                            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to run sp from db {ex}");
                }
                return AllFlights;
            }
            
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            throw new NotImplementedException();
        }

        public Flight GetFlightById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByDepatureDate(DateTime departureDate)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            throw new NotImplementedException();
        }

        public IList<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            throw new NotImplementedException();
        }
    }
}
