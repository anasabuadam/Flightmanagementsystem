using Flightmanagementsystem.BasicFolderClass;
using Flightmanagementsystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Flightmanagementsystem.DAOClass
{
    public class FlightDAOPGSQL : IFlightDAO
    {
        static SqlConnection conSQL = new SqlConnection(SQLConnection.conStr);


        void IBasicDb<Flight>.Add(Flight t)
        {

            int result = 0;
            long id = t._Id;
            long airlineCompanyId = t._AirlineCompanyId;
            int originCountryCode = t._OriginCountryId;
            int destinationCountryCode = t._DestinationCountryId;
            string departureTime = t._DepartureTime;
            string landingTime = t._LandingTime;
            int remainingTickets = t._RimainingTickets;

            Flight f = GetByAllFields(airlineCompanyId, originCountryCode, destinationCountryCode, departureTime, landingTime);

            if (f is null)
            {
                SQLConnection.SQLOpen(conSQL);
                string cmdStr = $"INSERT INTO Flights VALUES({airlineCompanyId}," +
                    $"{originCountryCode},{destinationCountryCode},'{departureTime}'," +
                    $"'{landingTime}',{remainingTickets},);SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                SQLConnection.SQLClose(conSQL);
            }

            else
            {
                throw new FlighAlreadyExistsException($"The flight already exists with ID {f._Id}");
            }


        }

        public Flight Get(long id)
        {


            SQLConnection.SQLOpen(conSQL);
            Flight f = null;
            string cmdStr = $"SELECT * FROM Flights WHERE ID = {id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        f = new Flight
                        {
                            _Id = (long)reader["id"],
                            _AirlineCompanyId = (long)reader["Airline_Company_Id"],
                            _OriginCountryId = (int)reader["Origin_Country_Id"],
                            _DestinationCountryId = (int)reader["Destination_Country_Id"],
                            _DepartureTime = (string)reader["Departure_Time"],
                            _LandingTime = (string)reader["Landing_Time"],
                            _RimainingTickets = (int)reader["Remaining_Tickets"]

                        };

                    }
                }

            }
            SQLConnection.SQLClose(conSQL);
            return f;
        }


        public Flight GetByAllFields(long airlineCompanyId, int originCountryCode, int destinationCountryCode, string departureTime, string landingTime)
        {
            SQLConnection.SQLOpen(conSQL);
            Flight f = null;
            string cmdStr = $"SELECT * FROM Flights WHERE Airline_Company_Id = {airlineCompanyId} AND " +
                $"Origin_Country_Id = {originCountryCode} AND Destination_Country_Id = {destinationCountryCode} AND " +
                $"Departure_Time = '{departureTime}' AND Landing_Time = '{landingTime}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        f = new Flight
                        {
                            _Id = (long)reader["id"],
                            _AirlineCompanyId = (long)reader["Airline_Company_Id"],
                            _OriginCountryId = (int)reader["Origin_Country_Id"],
                            _DestinationCountryId = (int)reader["Destination_Country_Id"],
                            _DepartureTime = (string)reader["Departure_Time"],
                            _LandingTime = (string)reader["Landing_Time"],
                            _RimainingTickets = (int)reader["Remaining_Tickets"]
                        };

                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return f;
        }
        public IList<Flight> GetAll()
        {
            SQLConnection.SQLOpen(conSQL);
            List<Flight> flights = new List<Flight>();
            string cmdStr = $"SELECT * FROM Flights";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            _Id = (long)reader["id"],
                            _AirlineCompanyId = (long)reader["Airline_Company_Id"],
                            _OriginCountryId = (int)reader["Origin_Country_Id"],
                            _DestinationCountryId = (int)reader["Destination_Country_Id"],
                            _DepartureTime = (string)reader["Departure_Time"],
                            _LandingTime = (string)reader["Landing_Time"],
                            _RimainingTickets = (int)reader["Remaining_Tickets"]
                        };

                        flights.Add(f);
                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return flights;
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            Dictionary<Flight, int> FlightsVacancy = new Dictionary<Flight, int>();
            List<Flight> allFlights = new List<Flight>();
            foreach (Flight f in allFlights)
            {
                if (f._RimainingTickets > 0 && f._AirlineCompanyId == 1)
                    FlightsVacancy.Add(f, (int)f._Id);
            }
            return FlightsVacancy;
        }





        public List<Flight> GetFlightsByCustomer(Customer customer)
        {
            SQLConnection.SQLOpen(conSQL);
            List<Flight> flights = new List<Flight>();
            string cmdStr = $"SELECT Flights.id,Flights.Airline_Company_Id, Flights.Origin_Country_Id," +
                $"Flights.Destination_Country_Id,Flights.Departure_Time,Flights.Landing_Time,Flights.Remaining_Tickets, " +
                $"FROM  Tickets JOIN Flights ON Tickets.Flight_Id = Flights.id WHERE Tickets.Customer_Id = {customer._Id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            _Id = (long)reader["id"],
                            _AirlineCompanyId = (long)reader["Airline_Company_Id"],
                            _OriginCountryId = (int)reader["Origin_Country_Id"],
                            _DestinationCountryId = (int)reader["Destination_Country_Id"],
                            _DepartureTime = (string)reader["Departure_Time"],
                            _LandingTime = (string)reader["Landing_Time"],
                            _RimainingTickets = (int)reader["Remaining_Tickets"]
                        };

                        flights.Add(f);
                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return flights;
        }
        public List<Flight> GetFlightsByAirlineCompany(AirlineCompany airlineCompany)
        {
            SQLConnection.SQLOpen(conSQL);
            List<Flight> flights = new List<Flight>();
            string cmdStr = $"SELECT * FROM Flights WHERE Airline_Company_Id = {airlineCompany._id}";

            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            _Id = (long)reader["id"],
                            _AirlineCompanyId = (long)reader["Airline_Company_Id"],
                            _OriginCountryId = (int)reader["Origin_Country_Id"],
                            _DestinationCountryId = (int)reader["Destination_Country_Id"],
                            _DepartureTime = (string)reader["Departure_Time"],
                            _LandingTime = (string)reader["Landing_Time"],
                            _RimainingTickets = (int)reader["Remaining_Tickets"]
                        };

                        flights.Add(f);
                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return flights;
        }

        public List<Flight> GetFlightsByDepartureTime(string departureDate)
        {
            SQLConnection.SQLOpen(conSQL);
            List<Flight> flights = new List<Flight>();
            string cmdStr = $"SELECT * FROM Flights WHERE Departure_Time = '{departureDate}'";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            _Id = (long)reader["id"],
                            _AirlineCompanyId = (long)reader["Airline_Company_Id"],
                            _OriginCountryId = (int)reader["Origin_Country_Id"],
                            _DestinationCountryId = (int)reader["Destination_Country_Id"],
                            _DepartureTime = (string)reader["Departure_Time"],
                            _LandingTime = (string)reader["Landing_Time"],
                            _RimainingTickets = (int)reader["Remaining_Tickets"]
                        };

                        flights.Add(f);
                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return flights;
        }

        public List<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            SQLConnection.SQLOpen(conSQL);
            List<Flight> flights = new List<Flight>();
            string cmdStr = $"SELECT * FROM Flights WHERE Destination_Country_Id = {countryCode}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            _Id = (long)reader["id"],
                            _AirlineCompanyId = (long)reader["Airline_Company_Id"],
                            _OriginCountryId = (int)reader["Origin_Country_Id"],
                            _DestinationCountryId = (int)reader["Destination_Country_Id"],
                            _DepartureTime = (string)reader["Departure_Time"],
                            _LandingTime = (string)reader["Landing_Time"],
                            _RimainingTickets = (int)reader["Remaining_Tickets"]
                        };

                        flights.Add(f);
                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return flights;
        }

        public List<Flight> GetFlightsByLandingTime(string landingDate)
        {
            SQLConnection.SQLOpen(conSQL);
            List<Flight> flights = new List<Flight>();
            string cmdStr = $"SELECT * FROM Flights WHERE Landing_Time = '{landingDate}'";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            _Id = (long)reader["id"],
                            _AirlineCompanyId = (long)reader["Airline_Company_Id"],
                            _OriginCountryId = (int)reader["Origin_Country_Id"],
                            _DestinationCountryId = (int)reader["Destination_Country_Id"],
                            _DepartureTime = (string)reader["Departure_Time"],
                            _LandingTime = (string)reader["Landing_Time"],
                            _RimainingTickets = (int)reader["Remaining_Tickets"]
                        };

                        flights.Add(f);
                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return flights;
        }

        public List<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            SQLConnection.SQLOpen(conSQL);
            List<Flight> flights = new List<Flight>();
            string cmdStr = $"SELECT * FROM Flights WHERE Origin_Country_Id = {countryCode}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            _Id = (long)reader["id"],
                            _AirlineCompanyId = (long)reader["Airline_Company_Id"],
                            _OriginCountryId = (int)reader["Origin_Country_Id"],
                            _DestinationCountryId = (int)reader["Destination_Country_Id"],
                            _DepartureTime = (string)reader["Departure_Time"],
                            _LandingTime = (string)reader["Landing_Time"],
                            _RimainingTickets = (int)reader["Remaining_Tickets"]
                        };

                        flights.Add(f);
                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return flights;
        }

        public void Remove(Flight t)
        {
            Flight f = new Flight();
            if (f is null)
            {
                throw new FlightNotFoundException($"The flight  with id {t._Id} does not exist");
            }
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"DELETE FROM Flights WHERE id = {t._Id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }

        public void Update(Flight t)
        {
            Flight f = new Flight();
            if (f is null)
            {
                throw new FlightNotFoundException($"The flight  with id {t._Id} does not exist");
            }
            SQLConnection.SQLOpen(conSQL);

            string cmdStr = $"UPDATE Flights SET Airline_Company_Id = {t._AirlineCompanyId}," +
              $"Origin_Country_Id = {t._OriginCountryId}, Destination_Country_Id = {t._DestinationCountryId}," +
              $"Departure_Time = '{t._DepartureTime}', Landing_Time = '{t._LandingTime}'," +
              $"Remaining_Tickets ={t._RimainingTickets} WHERE id = {t._Id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }
        public void DeleteAll()
        {
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"DELETE FROM Flights ";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }
        public void DeleteAllHistory()
        {
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"DELETE FROM FlightsHistory ";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }
        public List<Flight> GetFlightsToTransfer()
        {
            SQLConnection.SQLOpen(conSQL);
            List<Flight> flights = new List<Flight>();
            string cmdStr = $"SELECT * FROM Flights where Remaining_Tickets = 3 AND Landing_Time <=(SELECT DATEADD(HOUR,{SQLConnection.transferTime}, GETDATE()))";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            _Id = (long)reader["id"],
                            _AirlineCompanyId = (long)reader["Airline_Company_Id"],
                            _OriginCountryId = (int)reader["Origin_Country_Id"],
                            _DestinationCountryId = (int)reader["Destination_Country_Id"],
                            _DepartureTime = (string)reader["Departure_Time"],
                            _LandingTime = (string)reader["Landing_Time"],
                            _RimainingTickets = (int)reader["Remaining_Tickets"]
                        };

                        flights.Add(f);
                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return flights;
        }
        public void TransferFlightToHistory(Flight flight)
        {
            Flight f = new Flight();
            if (f is null)
            {
                throw new FlightNotFoundException($"The flight  with id {flight._Id} does not exist");
            }
            long airlineCompanyId = flight._AirlineCompanyId;
            int originCountryCode = flight._OriginCountryId;
            int destinationCountryCode = flight._DestinationCountryId;
            string departureTime = flight._DepartureTime;
            string landingTime = flight._LandingTime;

            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"INSERT INTO FlightsHistory VALUES({flight._Id},{airlineCompanyId}," +
                    $"{originCountryCode},{destinationCountryCode},'{departureTime}','{landingTime}')";

            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);

        }


    }
}
