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
            Int64 id = t._Id;
            Int64 flightId = t.FlightId;
            Int64 customerId = t.CustomerId;

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
                throw new TicketAlreadyExistsException($"The flight already exists with ID {ticket._Id}");
            }

            
        }


        Ticket IBasicDb<Ticket>.Get(long id)
        {
            SQLConnection.SQLOpen(conSQL);
            Ticket ticket = null;
            string cmdStr = $"SELECT * FROM Tickets WHERE id = {id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        ticket = new Ticket
                        {
                            _Id = (int)reader["id"],
                            FlightId = (int)reader["Flight_Id"],
                            CustomerId = (int)reader["Customer_Id"]
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
                            _Id = (int)reader["id"],
                            FlightId = (int)reader["Flight_Id"],
                            CustomerId = (int)reader["Customer_Id"]
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
                throw new TicketNotFoundException($"The ticket  with id {t._Id} does not exist");
            }
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"DELETE FROM Tickets WHERE id = { t._Id }";
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
                throw new TicketNotFoundException($"The flight  with id {t._Id} does not exist");
            }
            SQLConnection.SQLOpen(conSQL);

            string cmdStr = $"UPDATE Tickets SET Flight_Id = {t.FlightId}, Customer_Id = {t.CustomerId} WHERE id = {t._Id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }
        public Ticket GetByAllFields(Int64 flightId, Int64 customerId)
        {
            SQLConnection.SQLOpen(conSQL);
            Ticket ticket = null;
            string cmdStr = $"SELECT * FROM Tickets WHERE Flight_Id = {flightId} AND Customer_Id = {customerId}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        ticket = new Ticket
                        {
                            _Id = (int)reader["id"],
                            FlightId = (int)reader["Flight_Id"],
                            CustomerId = (int)reader["Customer_Id"]
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
                throw new TicketNotFoundException($"The ticket  with id {ticket._Id} does not exist");
            }
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"INSERT INTO TicketsHistory VALUES({ticket._Id},{ticket.FlightId},{ticket.CustomerId})";
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
            string cmdStr = $"SELECT Tickets.id,Tickets.Flight_Id,Tickets.Customer_Id FROM Tickets JOIN Flights ON Tickets.Flight_Id = Flights.id WHERE Flights.Airline_Company_Id  = {airline._id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ticket ticket = new Ticket
                        {
                            _Id = (int)reader["id"],
                            FlightId = (int)reader["Flight_Id"],
                            CustomerId = (int)reader["Customer_Id"]
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
            string cmdStr = $"SELECT * FROM Tickets WHERE Flight_Id = {flight._Id} ";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ticket ticket = new Ticket
                        {
                            _Id = (int)reader["id"],
                            FlightId = (int)reader["Flight_Id"],
                            CustomerId = (int)reader["Customer_Id"]
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
