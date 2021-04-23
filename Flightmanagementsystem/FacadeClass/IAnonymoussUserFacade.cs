using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Flightmanagementsystem
{
    interface IAnonymoussUserFacade
    {
     

        string conn_string { get; }

        public IList<Flight> GetFlights(int id)
        {
            Flight res = null;
            using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from Flights";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        res = new Flight
                        {
                            Id = (int)reader["id"],
                            Airline_Company_Id = (int)reader["Airline_Company_Id"],
                            Origin_Country_Id = (int)reader["Origin_Country_Id"],
                            Destination_Country_Id = (int)reader["Destination_Country_Id"],
                            Departure_Time = (DateTime)reader["Departure_Time"],
                            Landing_Time = (DateTime)reader["Landing_Time"],
                            Remaining_Tickets = (int)reader["Remaining_Tickets"]
                        };
                    }
                }
                return (IList<Flight>)res;
            }
        }
     
        public IList<AirlineCompany> AllAirlineCompanies(int id)
        {
            AirlineCompany res = null;
            using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from Airline_Companies";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        res = new AirlineCompany
                        {
                            Id = (int)reader["id"],
                            User_Id = (int)reader["User_Id"],
                            Name = (string)reader["Name"],
                            Country_Id = (int)reader["Country_Id"]
                        };
                    }
                }
                return ((IList<AirlineCompany>)res);
            }
        }


        public Flight GetFlihgtById(int id)
        {
            Flight res = null;
            using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from Flights Where id = {id}  ";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        res = new Flight
                        {
                            Id = (int)reader["id"],
                            Airline_Company_Id = (int)reader["Airline_Company_Id"],
                            Origin_Country_Id = (int)reader["Origin_Country_Id"],
                            Destination_Country_Id = (int)reader["Destination_Country_Id"],
                            Departure_Time = (DateTime)reader["Departure_Time"],
                            Landing_Time = (DateTime)reader["Landing_Time"],
                            Remaining_Tickets = (int)reader["Remaining_Tickets"]
                        };
                    }
                }
                return res;
            }
        }

      
        public IList<Flight> GetFlightsByOriginCountry(int countryCode )
        {
            Flight res = null;
            using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from Flights Where Origin_Country_Id = {countryCode}";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        res = new Flight
                        {
                            Id = (int)reader["id"],
                            Airline_Company_Id = (int)reader["Airline_Company_Id"],
                            Origin_Country_Id = (int)reader["Origin_Country_Id"],
                            Destination_Country_Id = (int)reader["Destination_Country_Id"],
                            Departure_Time = (DateTime)reader["Departure_Time"],
                            Landing_Time = (DateTime)reader["Landing_Time"],
                            Remaining_Tickets = (int)reader["Remaining_Tickets"]
                        };
                    }
                }
                return (IList<Flight>)res;
            }
        }
    
        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
          Flight res = null;
            using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
            {


                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from Flights Where Destination_Country_Id = {countryCode}";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        res = new Flight
                        {
                            Id = (int)reader["id"],
                            Airline_Company_Id = (int)reader["Airline_Company_Id"],
                            Origin_Country_Id = (int)reader["Origin_Country_Id"],
                            Destination_Country_Id = (int)reader["Destination_Country_Id"],
                            Departure_Time = (DateTime)reader["Departure_Time"],
                            Landing_Time = (DateTime)reader["Landing_Time"],
                            Remaining_Tickets = (int)reader["Remaining_Tickets"]
                        };
                    }
                }
            }
            return (IList<Flight>)res;
        }

  
        public IList<Flight> GetFlightsByDepatureDate(DateTime departureDate)
        {
            Flight res = null;
            using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
            {


                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from Flights Where Departure_Time = {departureDate}";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        res = new Flight
                        {
                            Id = (int)reader["id"],
                            Airline_Company_Id = (int)reader["Airline_Company_Id"],
                            Origin_Country_Id = (int)reader["Origin_Country_Id"],
                            Destination_Country_Id = (int)reader["Destination_Country_Id"],
                            Departure_Time = (DateTime)reader["Departure_Time"],
                            Landing_Time = (DateTime)reader["Landing_Time"],
                            Remaining_Tickets = (int)reader["Remaining_Tickets"]
                        };
                    }
                }
            }
            return (IList<Flight>)res;
        }
      
        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate )
        {
            Flight res = null;
            using (SqlConnection sqlConnection1 = new SqlConnection(conn_string))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from Flights Where Landing_Time = {landingDate}";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        res = new Flight
                        {
                            Id = (int)reader["id"],
                            Airline_Company_Id = (int)reader["Airline_Company_Id"],
                            Origin_Country_Id = (int)reader["Origin_Country_Id"],
                            Destination_Country_Id = (int)reader["Destination_Country_Id"],
                            Departure_Time = (DateTime)reader["Departure_Time"],
                            Landing_Time = (DateTime)reader["Landing_Time"],
                            Remaining_Tickets = (int)reader["Remaining_Tickets"]
                        };
                    }
                }
            }
            return (IList<Flight>)res;
        }
    }
}
