using Flightmanagementsystem.BasicFolderClass;
using Flightmanagementsystem.DAOClass;
using Flightmanagementsystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Flightmanagementsystem
{
    public class FlightDAOPGSQL : IFlightDAO
    {
        static SqlConnection conSQL = new SqlConnection(SQLConnection.conStr);


        void IBasicDb<Flight>.Add(Flight t)
        {

            int result = 0;
            int airlineCompanyId = t.AirlineCompanyId;
            int originCountryCode = t.OriginCountryCode;
            int destinationCountryCode = t.DestinationCountryCode;
            string departureTime = t.DepartureTime;
            string landingTime = t.LandingTime;
            int remainingTickets = t.RemainingTickets;
            int flightStatus = t.FlightStatus;
            Flight f = GetByAllFields(airlineCompanyId, originCountryCode, destinationCountryCode, departureTime, landingTime);

            if (f is null)
            {
                SQLConnection.SQLOpen(conSQL);
                string cmdStr = $"INSERT INTO Flights VALUES({airlineCompanyId}," +
                    $"{originCountryCode},{destinationCountryCode},'{departureTime}'," +
                    $"'{landingTime}',{remainingTickets},{flightStatus});SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                SQLConnection.SQLClose(conSQL);
            }

            else
            {
                throw new FlighAlreadyExistsException($"The flight already exists with ID {f.Id}");
            }
         
          
        }

        public Flight Get(long id)
        {
           

                SQLConnection.SQLOpen(conSQL);
                Flight f = null;
                string cmdStr = $"SELECT * FROM Flight WHERE ID = {id}";
                using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            f = new Flight
                            {
                                Id = (int)reader["Id"],
                                AirlineCompanyId = (int)reader["AirlineCompanyId"],
                                OriginCountryCode = (int)reader["OriginCountryCode"],
                                DestinationCountryCode = (int)reader["DestinationCountryCode"],
                                DepartureTime = (string)reader["DepartureTime"],
                                LandingTime = (string)reader["LandingTime"],
                                RemainingTickets = (int)reader["RemainingTickets"],
                                FlightStatus = (int)reader["FlightStatus"]
                            };

                        }
                    }
            
                }
            SQLConnection.SQLClose(conSQL);
            return f;
        }
            

        public Flight GetByAllFields(int airlineCompanyId, int originCountryCode, int destinationCountryCode, string departureTime, string landingTime)
        {
            SQLConnection.SQLOpen(conSQL);
            Flight f = null;
            string cmdStr = $"SELECT * FROM Flights WHERE AIRLINECOMPANY_ID = {airlineCompanyId} AND " +
                $"ORIGIN_COUNTRY_CODE = {originCountryCode} AND DESTINATION_COUNTRY_CODE = {destinationCountryCode} AND " +
                $"DEPARTURE_TIME = '{departureTime}' AND LANDING_TIME = '{landingTime}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        f = new Flight
                        {
                            Id = (int)reader["Id"],
                            AirlineCompanyId = (int)reader["AirlineCompanyId"],
                            OriginCountryCode = (int)reader["OriginCountryCode"],
                            DestinationCountryCode = (int)reader["DestinationCountryCode"],
                            DepartureTime = (string)reader["DepartureTime"],
                            LandingTime = (string)reader["LandingTime"],
                            RemainingTickets = (int)reader["RemainingTickets"],
                            FlightStatus = (int)reader["FlightStatus"]
                        };

                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return f;
        }
       public IList<Flight>  GetAll()
        {
            SQLConnection.SQLOpen(conSQL);
            List<Flight> flights = new List<Flight>();
            string cmdStr = $"SELECT * FROM Flight";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            Id = (int)reader["Id"],
                            AirlineCompanyId = (int)reader["AirlineCompanyId"],
                            OriginCountryCode = (int)reader["OriginCountryCode"],
                            DestinationCountryCode = (int)reader["DestinationCountryCode"],
                            DepartureTime = (string)reader["DepartureTime"],
                            LandingTime = (string)reader["LandingTime"],
                            RemainingTickets = (int)reader["RemainingTickets"],
                            FlightStatus = (int)reader["FlightStatus"]
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
                if (f.RemainingTickets > 0 && f.FlightStatus == 1)
                    FlightsVacancy.Add(f, f.Id);
            }
            return FlightsVacancy;
        }





        public List<Flight> GetFlightsByCustomer(Customer customer)
        {
            SQLConnection.SQLOpen(conSQL);
            List<Flight> flights = new List<Flight>();
            string cmdStr = $"SELECT Flights.ID,Flights.AIRLINECOMPANY_ID, Flights.ORIGIN_COUNTRY_CODE," +
                $"Flights.DESTINATION_COUNTRY_CODE,Flights.DEPARTURE_TIME,Flights.LANDING_TIME,Flights.REMAINING_TICKETS," +
                $"Flights.FLIGHT_STATUS_ID FROM  Tickets JOIN Flights ON Tickets.FLIGHT_ID = Flights.ID WHERE Tickets.CUSTOMER_ID = {customer.Id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            Id = (int)reader["Id"],
                            AirlineCompanyId = (int)reader["AirlineCompanyId"],
                            OriginCountryCode = (int)reader["OriginCountryCode"],
                            DestinationCountryCode = (int)reader["DestinationCountryCode"],
                            DepartureTime = (string)reader["DepartureTime"],
                            LandingTime = (string)reader["LandingTime"],
                            RemainingTickets = (int)reader["RemainingTickets"],
                            FlightStatus = (int)reader["FlightStatus"]
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
            string cmdStr = $"SELECT * FROM Flight WHERE AirlineCompanyId = {airlineCompany.Id}";

            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            Id = (int)reader["Id"],
                            AirlineCompanyId = (int)reader["AirlineCompanyId"],
                            OriginCountryCode = (int)reader["OriginCountryCode"],
                            DestinationCountryCode = (int)reader["DestinationCountryCode"],
                            DepartureTime = (string)reader["DepartureTime"],
                            LandingTime = (string)reader["LandingTime"],
                            RemainingTickets = (int)reader["RemainingTickets"],
                            FlightStatus = (int)reader["FlightStatus"]
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
            string cmdStr = $"SELECT * FROM Flight WHERE DepartureTime = '{departureDate}'";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            Id = (int)reader["Id"],
                            AirlineCompanyId = (int)reader["AirlineCompanyId"],
                            OriginCountryCode = (int)reader["OriginCountryCode"],
                            DestinationCountryCode = (int)reader["DestinationCountryCode"],
                            DepartureTime = (string)reader["DepartureTime"],
                            LandingTime = (string)reader["LandingTime"],
                            RemainingTickets = (int)reader["RemainingTickets"],
                            FlightStatus = (int)reader["FlightStatus"]
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
            string cmdStr = $"SELECT * FROM Flight WHERE DestinationCountryCode = {countryCode}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            Id = (int)reader["Id"],
                            AirlineCompanyId = (int)reader["AirlineCompanyId"],
                            OriginCountryCode = (int)reader["OriginCountryCode"],
                            DestinationCountryCode = (int)reader["DestinationCountryCode"],
                            DepartureTime = (string)reader["DepartureTime"],
                            LandingTime = (string)reader["LandingTime"],
                            RemainingTickets = (int)reader["RemainingTickets"],
                            FlightStatus = (int)reader["FlightStatus"]
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
            string cmdStr = $"SELECT * FROM Flight WHERE LandingTime = '{landingDate}'";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            Id = (int)reader["Id"],
                            AirlineCompanyId = (int)reader["AirlineCompanyId"],
                            OriginCountryCode = (int)reader["OriginCountryCode"],
                            DestinationCountryCode = (int)reader["DestinationCountryCode"],
                            DepartureTime = (string)reader["DepartureTime"],
                            LandingTime = (string)reader["LandingTime"],
                            RemainingTickets = (int)reader["RemainingTickets"],
                            FlightStatus = (int)reader["FlightStatus"]
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
            string cmdStr = $"SELECT * FROM Flight WHERE OriginCountryCode = {countryCode}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            Id = (int)reader["Id"],
                            AirlineCompanyId = (int)reader["AirlineCompanyId"],
                            OriginCountryCode = (int)reader["OriginCountryCode"],
                            DestinationCountryCode = (int)reader["DestinationCountryCode"],
                            DepartureTime = (string)reader["DepartureTime"],
                            LandingTime = (string)reader["LandingTime"],
                            RemainingTickets = (int)reader["RemainingTickets"],
                            FlightStatus = (int)reader["FlightStatus"]
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
                throw new FlightNotFoundException($"The flight  with id {t.Id} does not exist");
            }
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"DELETE FROM Flight WHERE ID = { t.Id }";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }

        public void Update(Flight t)
        {
            Flight f =new Flight();
            if (f is null)
            {
                throw new FlightNotFoundException($"The flight  with id {t.Id} does not exist");
            }
            SQLConnection.SQLOpen(conSQL);

            string cmdStr = $"UPDATE Flights SET AirlineCompanyId = {t.AirlineCompanyId}," +
              $"OriginCountryCode = {t.OriginCountryCode}, DestinationCountryCode = {t.DestinationCountryCode}," +
              $"DepartureTime = '{t.DepartureTime}', LandingTime = '{t.LandingTime}'," +
              $"RemainingTickets ={t.RemainingTickets}, FlightStatus = {t.FlightStatus} WHERE ID = {t.Id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }
        public void DeleteAll()
        {
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"DELETE FROM Flight ";
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
            string cmdStr = $"SELECT * FROM Flight where FlightStatus = 3 AND LandingTime <=(SELECT DATEADD(HOUR,{SQLConnection.transferTime}, GETDATE()))";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Flight f = null;
                    while (reader.Read())
                    {
                        f = new Flight
                        {
                            Id = (int)reader["Id"],
                            AirlineCompanyId = (int)reader["AirlineCompanyId"],
                            OriginCountryCode = (int)reader["OriginCountryCode"],
                            DestinationCountryCode = (int)reader["DestinationCountryCode"],
                            DepartureTime = (string)reader["DepartureTime"],
                            LandingTime = (string)reader["LandingTime"],
                            RemainingTickets = (int)reader["RemainingTickets"],
                            FlightStatus = (int)reader["FlightStatus"]
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
            Flight f =new Flight();
            if (f is null)
            {
                throw new FlightNotFoundException($"The flight  with id {flight.Id} does not exist");
            }
            int airlineCompanyId = flight.AirlineCompanyId;
            int originCountryCode = flight.OriginCountryCode;
            int destinationCountryCode = flight.DestinationCountryCode;
            string departureTime = flight.DepartureTime;
            string landingTime = flight.LandingTime;

            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"INSERT INTO FlightsHistory VALUES({flight.Id},{ airlineCompanyId}," +
                    $"{originCountryCode},{destinationCountryCode},'{departureTime}','{landingTime}')";

            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);

        }


    }
}
