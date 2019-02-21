using System;
using Problem1;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Problem5
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string updateTownNames = @"UPDATE Towns
                                         SET Name = UPPER(Name)
                                     WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                using (SqlCommand command = new SqlCommand(updateTownNames, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);
                    int rowAffected = command.ExecuteNonQuery();
                    Console.WriteLine($"{rowAffected} town names were affected.");
                }

                string townNameQuery = @" SELECT t.Name 
                                          FROM Towns as t
                                          JOIN Countries AS c ON c.Id = t.CountryCode
                                         WHERE c.Name = @countryName";

                List<string> towns = new List<string>();

                using (SqlCommand command = new SqlCommand(townNameQuery, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            towns.Add((string)reader[0]);
                        }
                    }

                    Console.WriteLine("[" + string.Join(", ", towns) + "]");
                }
            }
        }
    }
}
