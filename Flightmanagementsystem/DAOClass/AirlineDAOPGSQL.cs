using Flightmanagementsystem.DAOClass;
using Flightmanagementsystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Flightmanagementsystem
{

    public class AirlineDAOMSSQL : IAirlineDAO
    {
        static SqlConnection conSQL = new SqlConnection(SQLConnection.conStr);
     void IBasicDb<AirlineCompany>.Add(AirlineCompany t)
        {
        int result = 0;
        string airlineName = t.AirlineName;
        string userName = t.UserName;
        string password = t.Password;
        int countryCode = t.CountryCode;
        AirlineCompany airComp = GetAirlineByUserName(t.UserName);

        if (airComp is null)
        {
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"INSERT INTO AirlineCompany VALUES('{airlineName}','{userName}','{password}',{countryCode});SELECT SCOPE_IDENTITY()";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            SQLConnection.SQLClose(conSQL);
        }

        else
        {
            throw new AirlineAlreadyExistsException($"The airline company {userName} already exists with ID {airComp.Id}");
        }      
    }

        public AirlineCompany Get(long id)
        {
        SQLConnection.SQLOpen(conSQL);
        AirlineCompany airComp = null;
        string cmdStr = $"SELECT * FROM AirlineCompany WHERE ID = {id}";
        using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    airComp = new AirlineCompany
                    {
                        Id = (int)reader["ID"],
                        AirlineName = (string)reader["AIRLINE_NAME"],
                        UserName = (string)reader["USER_NAME"],
                        Password = (string)reader["PASSWORD"],
                        CountryCode = (int)reader["COUNTRY_CODE"],
                    };

                }
            }
        }
        SQLConnection.SQLClose(conSQL);
        return airComp;
    }

    public AirlineCompany GetAirlineByUserName(string name)
    {
        SQLConnection.SQLOpen(conSQL);
        AirlineCompany airComp = null;
        string cmdStr = $"SELECT * FROM AirlineCompany WHERE USER_NAME = '{name}'";
        using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    airComp = new AirlineCompany
                    {
                        Id = (int)reader["ID"],
                        AirlineName = (string)reader["AIRLINE_NAME"],
                        UserName = (string)reader["USER_NAME"],
                        Password = (string)reader["PASSWORD"],
                        CountryCode = (int)reader["COUNTRY_CODE"]
                    };

                }
            }
        }

        SQLConnection.SQLClose(conSQL);
        return airComp;
    }

       public IList<AirlineCompany>  GetAll()
        {
        SQLConnection.SQLOpen(conSQL);
        List<AirlineCompany> airlineCompanies = new List<AirlineCompany>();
        string cmdStr = $"SELECT * FROM AirlineCompany";
        using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                AirlineCompany airComp = null;
                while (reader.Read())
                {
                    airComp = new AirlineCompany
                    {
                        Id = (int)reader["Id"],
                        AirlineName = (string)reader["AirlineName"],
                        UserName = (string)reader["UserName"],
                        Password = (string)reader["Password"],
                        CountryCode = (int)reader["CountryCode"]
                    };

                    airlineCompanies.Add(airComp);
                }
            }
        }
        SQLConnection.SQLClose(conSQL);
        return airlineCompanies;
    }

    public List<AirlineCompany> GetAllAirlinesCompanyByCountry(int countryId)
    {
        SQLConnection.SQLOpen(conSQL);
        List<AirlineCompany> airlineCompanies = new List<AirlineCompany>();
        string cmdStr = $"SELECT * FROM AirlineCompany WHERE COUNTRY_CODE = {countryId}";
        using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                AirlineCompany airComp = null;
                while (reader.Read())
                {
                    airComp = new AirlineCompany
                    {
                        Id = (int)reader["ID"],
                        AirlineName = (string)reader["AIRLINE_NAME"],
                        UserName = (string)reader["USER_NAME"],
                        Password = (string)reader["PASSWORD"],
                        CountryCode = (int)reader["COUNTRY_CODE"]
                    };

                    airlineCompanies.Add(airComp);
                }
            }
        }
        SQLConnection.SQLClose(conSQL);
        return airlineCompanies;
    }

    public void Remove(AirlineCompany t)
    {
        AirlineCompany airComp = Get(t.Id);
        if (airComp is null)
        {
            throw new AirCompanyNotFoundException($"The airline company  with id {t.Id} does not exist");
        }
        SQLConnection.SQLOpen(conSQL);
        string cmdStr = $"DELETE FROM AirlineCompany WHERE ID = {t.Id}";
        using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
        {
            cmd.ExecuteNonQuery();
        }
        SQLConnection.SQLClose(conSQL);
    }

    public void Update(AirlineCompany t)
    {
        AirlineCompany airComp = Get(t.Id);
        if (airComp is null)
        {
            throw new AirCompanyNotFoundException($"The airline company  with id {t.Id} does not exist");
        }
        SQLConnection.SQLOpen(conSQL);
        string cmdStr = $"UPDATE AirlineCompany SET AIRLINE_NAME = '{t.AirlineName}'," +
          $"USER_NAME = '{t.UserName}', PASSWORD = '{t.Password}'," +
          $"COUNTRY_CODE = {t.CountryCode} WHERE ID = {t.Id}";
        using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
        {
            cmd.ExecuteNonQuery();
        }
        SQLConnection.SQLClose(conSQL);
    }
    public void DeleteAll()
    {
        SQLConnection.SQLOpen(conSQL);
        string cmdStr = $"DELETE FROM AirlineCompany ";
        using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
        {
            cmd.ExecuteNonQuery();
        }
        SQLConnection.SQLClose(conSQL);
    }


    }
}


