﻿using System;
using Problem1;
using System.Data.SqlClient;

namespace Problem9
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string uspGetOlderproc = "EXEC usp_GetOlder @id";

                using (SqlCommand command = new SqlCommand(uspGetOlderproc, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        string name = (string)reader[0];
                        int age = (int)reader[1];

                        Console.WriteLine($"{name}– {age} years old");

                    }
                }
            }
        }
    }
}
