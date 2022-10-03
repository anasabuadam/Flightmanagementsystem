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
            Int64 id = t._id;
        string name = t._Name;
            int countryid = t.CountryId;
            Int64 userid = t.User_Id;
        AirlineCompany airComp = GetAirlineByUserName(t._Name);

        if (airComp is null)
        {
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"INSERT INTO Airline_Companies VALUES('{id}','{name}','{countryid}',{userid});SELECT SCOPE_IDENTITY()";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            SQLConnection.SQLClose(conSQL);
        }

        else
        {
            throw new AirlineAlreadyExistsException($"The airline company {name} already exists with ID {airComp._id}");
        }      
    }

        public AirlineCompany Get(long id)
        {
        SQLConnection.SQLOpen(conSQL);
        AirlineCompany airComp = null;
        string cmdStr = $"SELECT * FROM Airline_Companies WHERE ID = {id}";
        using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    airComp = new AirlineCompany
                    {
                        _id = (Int64)reader["Id"],
                        _Name = (string)reader["Name"],
                        CountryId = (int)reader["CountryId"],
                        User_Id = (Int64)reader["User_Id"]
                      
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
        string cmdStr = $"SELECT * FROM Airline_Companies WHERE Name = '{name}'";
        using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    airComp = new AirlineCompany
                    {
                        _id = (Int64)reader["Id"],
                        _Name = (string)reader["Name"],
                        CountryId = (int)reader["CountryId"],
                        User_Id = (Int64)reader["User_Id"]
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
        string cmdStr = $"SELECT * FROM Airline_Companies";
        using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                AirlineCompany airComp = null;
                while (reader.Read())
                {
                    airComp = new AirlineCompany
                    {
                        _id = (Int64)reader["Id"],
                        _Name = (string)reader["Name"],
                        CountryId = (int)reader["CountryId"],
                        User_Id = (Int64)reader["User_Id"]
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
        string cmdStr = $"SELECT * FROM Airline_Companies WHERE COUNTRY_CODE = {countryId}";
        using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                AirlineCompany airComp = null;
                while (reader.Read())
                {
                    airComp = new AirlineCompany
                    {
                        _id = (Int64)reader["Id"],
                        _Name = (string)reader["Name"],
                        CountryId = (int)reader["CountryId"],
                        User_Id = (Int64)reader["User_Id"]
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
        AirlineCompany airComp = Get(t._id);
        if (airComp is null)
        {
            throw new AirCompanyNotFoundException($"The airline company  with id {t._id} does not exist");
        }
        SQLConnection.SQLOpen(conSQL);
        string cmdStr = $"DELETE FROM Airline_Companies WHERE ID = {t._id}";
        using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
        {
            cmd.ExecuteNonQuery();
        }
        SQLConnection.SQLClose(conSQL);
    }

    public void Update(AirlineCompany t)
    {
        AirlineCompany airComp = Get(t._id);
        if (airComp is null)
        {
            throw new AirCompanyNotFoundException($"The airline company  with id {t._id} does not exist");
        }
        SQLConnection.SQLOpen(conSQL);
        string cmdStr = $"UPDATE Airline_Companies SET Id = '{t._id}'," +
          $"Name = '{t._Name}', CountryId = '{t.CountryId}'," +
          $"User_Id = {t.User_Id}";
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


