using Flightmanagementsystem.DAOClass;
using Flightmanagementsystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Flightmanagementsystem
{

    public class TicketDAOMSSQL : ITicketDAO
    {
        static SqlConnection conSQL = new SqlConnection(SQLConnection.conStr);
        Ticket Ticket = new Ticket();   
        void IBasicDb<Ticket>.Add(Ticket t)
        {
            int result = 0;
            int flightId = t.FlightId;
            int customerId = t.CustomerId;

            Ticket ticket = GetByAllFields(flightId, customerId);

            if (ticket is null)
            {
                SQLConnection.SQLOpen(conSQL);
                string cmdStr = $"INSERT INTO Tickets VALUES({flightId},{customerId});SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }
                SQLConnection.SQLClose(conSQL);
            }

            else
            {
                throw new TicketAlreadyExistsException($"The flight already exists with ID {ticket.Id}");
            }

            
        }

        Ticket IBasicDb<Ticket>.Get(long id)
        {
            SQLConnection.SQLOpen(conSQL);
            Ticket ticket = null;
            string cmdStr = $"SELECT * FROM Tickets WHERE ID = {id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        ticket = new Ticket
                        {
                            Id = (int)reader["ID"],
                            FlightId = (int)reader["FLIGHT_ID"],
                            CustomerId = (int)reader["CUSTOMER_ID"]
                        };

                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return ticket;
        }

        IList<Ticket> IBasicDb<Ticket>.GetAll()
        {
            SQLConnection.SQLOpen(conSQL);
            List<Ticket> tickets = new List<Ticket>();
            string cmdStr = $"SELECT * FROM Tickets";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Ticket ticket = null;
                    while (reader.Read())
                    {
                        ticket = new Ticket
                        {
                            Id = (int)reader["ID"],
                            FlightId = (int)reader["FLIGHT_ID"],
                            CustomerId = (int)reader["CUSTOMER_ID"]
                        };

                        tickets.Add(ticket);
                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return tickets;
        }

        public void Remove(Ticket  t)
        {
            Ticket ticket = new Ticket();
            if (ticket is null)
            {
                throw new TicketNotFoundException($"The ticket  with id {t.Id} does not exist");
            }
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"DELETE FROM Tickets WHERE ID = { t.Id }";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }

        public void Update(Ticket t)
        {
            Ticket ticket = new Ticket();
            if (ticket is null)
            {
                throw new TicketNotFoundException($"The flight  with id {t.Id} does not exist");
            }
            SQLConnection.SQLOpen(conSQL);

            string cmdStr = $"UPDATE Tickets SET FLIGHT_ID = {t.FlightId}, CUSTOMER_ID = {t.CustomerId} WHERE ID = {t.Id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }
        public Ticket GetByAllFields(int flightId, int customerId)
        {
            SQLConnection.SQLOpen(conSQL);
            Ticket ticket = null;
            string cmdStr = $"SELECT * FROM Tickets WHERE FLIGHT_ID = {flightId} AND CUSTOMER_ID = {customerId}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        ticket = new Ticket
                        {
                            Id = (int)reader["ID"],
                            FlightId = (int)reader["FLIGHT_ID"],
                            CustomerId = (int)reader["CUSTOMER_ID"]
                        };

                    }
                }
            }

            SQLConnection.SQLClose(conSQL);
            return ticket;
        }
        public void TransferTicketToHistory(Ticket ticket)
        {
            Ticket t = new Ticket();
            if (t is null)
            {
                throw new TicketNotFoundException($"The ticket  with id {ticket.Id} does not exist");
            }
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"INSERT INTO TicketsHistory VALUES({ticket.Id},{ticket.FlightId},{ticket.CustomerId})";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
            Remove(ticket);
        }
        public void DeleteAll()
        {
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"DELETE FROM Tickets ";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }
        public void DeleteAllHistory()
        {
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"DELETE FROM TicketsHistory ";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }

        public List<Ticket> GetTicketsByAirlineCompany(AirlineCompany airline)
        {
            SQLConnection.SQLOpen(conSQL);
            List<Ticket> tickets = new List<Ticket>();
            string cmdStr = $"SELECT Tickets.ID,Tickets.FLIGHT_ID,Tickets.CUSTOMER_ID FROM Tickets JOIN Flights ON Tickets.FLIGHT_ID = Flights.ID WHERE Flights.AIRLINECOMPANY_ID  = {airline.Id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ticket ticket = new Ticket
                        {
                            Id = (int)reader["ID"],
                            FlightId = (int)reader["FLIGHT_ID"],
                            CustomerId = (int)reader["CUSTOMER_ID"]
                        };
                        tickets.Add(ticket);
                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return tickets;
        }
        public List<Ticket> GetTicketsByFlight(Flight flight)
        {
            SQLConnection.SQLOpen(conSQL);
            List<Ticket> tickets = new List<Ticket>();
            string cmdStr = $"SELECT * FROM Tickets WHERE FLIGHT_ID = {flight.Id} ";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ticket ticket = new Ticket
                        {
                            Id = (int)reader["ID"],
                            FlightId = (int)reader["FLIGHT_ID"],
                            CustomerId = (int)reader["CUSTOMER_ID"]
                        };
                        tickets.Add(ticket);
                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return tickets;
        }




    }

}
