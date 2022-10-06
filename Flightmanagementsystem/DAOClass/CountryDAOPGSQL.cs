using Flightmanagementsystem.BasicFolderClass;
using Flightmanagementsystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Flightmanagementsystem.DAOClass
{

    public class CountryDAOMSSQL : ICountryDAO
    {
        static SqlConnection conSQL = new SqlConnection(SQLConnection.conStr);
        void IBasicDb<Country>.Add(Country t)
        {
            int result = 0;
            string countryName = t._Name;
            string cmdStr = $"SELECT * FROM Countries WHERE Name = '{countryName}'";
            SQLConnection.SQLOpen(conSQL);
            int countryId = 0;
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        countryId = (int)reader["ID"];
                        SQLConnection.SQLClose(conSQL);
                        throw new CountryAlreadyExistsException($"The country {countryName} already exists with ID {countryId}");
                    }
                }
            }
            if (countryId == 0)
            {
                cmdStr = $"INSERT INTO Countries VALUES('{countryName}');SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            SQLConnection.SQLClose(conSQL);

        }

        public Country Get(long id)
        {
            SQLConnection.SQLOpen(conSQL);
            Country country = null;
            string cmdStr = $"SELECT * FROM Countries WHERE Id = {id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        country = new Country
                        {
                            _id = (int)reader["Id"],
                            _Name = (string)reader["Name"],
                        };
                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return country;
        }


        IList<Country> IBasicDb<Country>.GetAll()
        {
            SQLConnection.SQLOpen(conSQL);
            List<Country> countries = new List<Country>();
            string cmdStr = $"SELECT * FROM Countries";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Country country = null;
                    while (reader.Read())
                    {
                        country = new Country
                        {
                            _id = (int)reader["Id"],
                            _Name = (string)reader["Name"],
                        };
                        countries.Add(country);
                    }
                }
            }
            SQLConnection.SQLClose(conSQL);
            return countries;
        }

        public void Remove(Country t)
        {
            Country country = Get(t._id);
            if (country is null)
            {
                throw new CountryNotFoundException($"The country  with id {t._id} does not exist");
            }
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"DELETE FROM Countries WHERE ID = {t._id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }

        public void Update(Country t)
        {
            Country country = Get(t._id);
            if (country is null)
            {
                throw new CountryNotFoundException($"The country  with id {t._id}  does not exist");
            }
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"UPDATE Countries SET Name = '{t._Name}' WHERE Id = {t._id}";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }
        public Country GetCountryByName(string name)
        {
            SQLConnection.SQLOpen(conSQL);
            Country c = null;
            string cmdStr = $"SELECT * FROM Countries WHERE Name = '{name}'";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        c = new Country
                        {
                            _id = (int)reader["Id"],
                            _Name = (string)reader["Name"],
                        };

                    }
                }
            }

            SQLConnection.SQLClose(conSQL);
            return c;
        }
        public void DeleteAll()
        {
            SQLConnection.SQLOpen(conSQL);
            string cmdStr = $"DELETE FROM Countries ";
            using (SqlCommand cmd = new SqlCommand(cmdStr, conSQL))
            {
                cmd.ExecuteNonQuery();
            }
            SQLConnection.SQLClose(conSQL);
        }







    }
}
