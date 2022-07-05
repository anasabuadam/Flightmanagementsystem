using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flightmanagementsystem.DAOClass;

namespace Flightmanagementsystem.DAOClass
{
    internal class SQLConnection
    {
        public static int transferTime = -3;
        public static int threadTime = 86400000;
        public static string conStr = @"Data Source=DESKTOP-LCKHR3P\MSSQLSERVER2019;Initial Catalog=FlightManagementSystem;Integrated Security=True";
       
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


    }
}

