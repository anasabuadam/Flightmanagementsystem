using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Flightmanagementsystem.FacadeClass
{
    public class AnonymousUserFacade
    {

        string conn_string { get; }

        private string conString = "Database=FlightManagementSystem;Trusted_Connection=True;";
        public IList<Flight> GetFlights()
        {
            IList<Flight> flights = new List<Flight>();
            using (SqlConnection sqlConnection1 = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection1;
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"select * from Flights";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    Flight flight = new Flight
                    {
                        Id = (long)reader["id"],
                        Airline_Company_Id = (long)reader["Airline_Company_Id"],
                        Origin_Country_Id = (int)reader["Origin_Country_Id"],
                        Destination_Country_Id = (int)reader["Destination_Country_Id"],
                        Departure_Time = (DateTime)reader["Departure_Time"],
                        Landing_Time = (DateTime)reader["Landing_Time"],
                        Remaining_Tickets = (int)reader["Remaining_Tickets"]
                    };
                    flights.Add(flight);
                }
                return flights;
            }
        }

        public IList<AirlineCompany> AllAirlineCompanies()
        {
            IList<AirlineCompany> airlines = new List<AirlineCompany>();
            using (SqlConnection sqlConnection1 = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection1;
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"select * from Airline_Companies";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    AirlineCompany airline = new AirlineCompany
                    {
                        Id = (long)reader["id"],
                        User_Id = (long)reader["User_Id"],
                        Name = (string)reader["Name"],
                        Country_Id = (int)reader["CountryId"]
                    };
                    airlines.Add(airline);
                }
            }
            return airlines;
        }

        public Flight GetFlihgtById(int id)
        {
            Flight flights1 = new Flight();

            using (SqlConnection sqlConnection1 = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection1;
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"select * from Flights Where id = {id}";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Flight flight = new Flight
                    {

                        Id = (long)reader["id"],
                        Airline_Company_Id = (long)reader["Airline_Company_Id"],
                        Origin_Country_Id = (int)reader["Origin_Country_Id"],
                        Destination_Country_Id = (int)reader["Destination_Country_Id"],
                        Departure_Time = (DateTime)reader["Departure_Time"],
                        Landing_Time = (DateTime)reader["Landing_Time"],
                        Remaining_Tickets = (int)reader["Remaining_Tickets"]
                    };

                    return flight;
                }
            }
            return flights1;
        }

        public IList<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            IList<Flight> flights = new List<Flight>();
            using (SqlConnection sqlConnection1 = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection1;
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"select * from Flights Where Origin_Country_Id = {countryCode}";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Flight flight = new Flight
                    {
                        Id = (long)reader["id"],
                        Airline_Company_Id = (long)reader["Airline_Company_Id"],
                        Origin_Country_Id = (int)reader["Origin_Country_Id"],
                        Destination_Country_Id = (int)reader["Destination_Country_Id"],
                        Departure_Time = (DateTime)reader["Departure_Time"],
                        Landing_Time = (DateTime)reader["Landing_Time"],
                        Remaining_Tickets = (int)reader["Remaining_Tickets"]
                    };
                    flights.Add(flight);
                }
            }
            return flights;
        }


        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            IList<Flight> flights = new List<Flight>();

            using (SqlConnection sqlConnection1 = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection1;
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"select * from Flights Where Destination_Country_Id = {countryCode}";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Flight flight = new Flight
                    {
                        Id = (long)reader["id"],
                        Airline_Company_Id = (long)reader["Airline_Company_Id"],
                        Origin_Country_Id = (int)reader["Origin_Country_Id"],
                        Destination_Country_Id = (int)reader["Destination_Country_Id"],
                        Departure_Time = (DateTime)reader["Departure_Time"],
                        Landing_Time = (DateTime)reader["Landing_Time"],
                        Remaining_Tickets = (int)reader["Remaining_Tickets"]
                    };
                    flights.Add(flight);
                }
            }
            return flights;
        }

        public IList<Flight> GetFlightsByDepatureDate(DateTime departureDate)
        {
            IList<Flight> flights = new List<Flight>();
            using (SqlConnection sqlConnection1 = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection1;
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"select * from Flights Where Departure_Time = {departureDate}";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Flight flight = new Flight
                    {
                        Id = (long)reader["id"],
                        Airline_Company_Id = (long)reader["Airline_Company_Id"],
                        Origin_Country_Id = (int)reader["Origin_Country_Id"],
                        Destination_Country_Id = (int)reader["Destination_Country_Id"],
                        Departure_Time = (DateTime)reader["Departure_Time"],
                        Landing_Time = (DateTime)reader["Landing_Time"],
                        Remaining_Tickets = (int)reader["Remaining_Tickets"]
                    };
                    flights.Add(flight);
                }
            }
            return flights;
        }

        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            IList<Flight> flights = new List<Flight>();
            using (SqlConnection sqlConnection1 = new SqlConnection(conString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlConnection1;
                cmd.Connection.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"select * from Flights Where Landing_Time = {landingDate}";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Flight flight = new Flight
                    {
                        Id = (long)reader["id"],
                        Airline_Company_Id = (long)reader["Airline_Company_Id"],
                        Origin_Country_Id = (int)reader["Origin_Country_Id"],
                        Destination_Country_Id = (int)reader["Destination_Country_Id"],
                        Departure_Time = (DateTime)reader["Departure_Time"],
                        Landing_Time = (DateTime)reader["Landing_Time"],
                        Remaining_Tickets = (int)reader["Remaining_Tickets"]
                    };
                    flights.Add(flight);
                }
            }
            return flights;
        }

    }
}


