using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flightmanagementsystem.DAOClass;
using Microsoft.EntityFrameworkCore;


namespace Flightmanagementsystem.DAOClass
{
    public class SQLConnection : DbContext
    {
        p
       
        public static void SQLOpen(SqlConnection conSQL)
        {
            if (conSQL.State != System.Data.ConnectionState.Open)
                conSQL.Open();

        }
        public static void SQLClose(SqlConnection conSQL)
        {
            if (conSQL.State != System.Data.ConnectionState.Closed)
                conSQL.Close();
        }
        public SQLConnection(DbContextOptions<SQLConnection> contextOptions) : base (contextOptions)
        {

        }

        public Administrator Administrator { get; set; }
        public Ticket Ticket { get; set; }
        public AirlineCompany AirlineCompany { get; set; }
        public User User { get; set; }
        public Country Country { get; set; }
        public Flight Flight { get; set; }
        public UserRoles UserRoles { get; set; }
        public Customer Customer { get; set; }

    }
}

