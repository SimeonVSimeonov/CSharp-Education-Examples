using System;
using Problem1;
using System.Data.SqlClient;

namespace Problem6
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string villianQuery = "SELECT Name FROM Villains WHERE Id = @villainId";

                string villianName;

                using (SqlCommand command = new SqlCommand(villianQuery, connection))
                {
                    command.Parameters.AddWithValue("@villainId", id);
                    villianName = (string)command.ExecuteScalar();

                    if (villianName == null)
                    {
                        Console.WriteLine($"No such villain was found.");
                        return;
                    }
                }

                int affectedRows = DeleteMinionsVillainsById(connection, id);

                DeleteVillainById(connection, id);

                Console.WriteLine($"{villianName} was deleted.");
                Console.WriteLine($"{affectedRows} minions were released.");
            }
        }

        private static void DeleteVillainById(SqlConnection connection, int id)
        {
            string deleteVillianQuery = @"DELETE FROM Villains
                                        WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(deleteVillianQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", id);
                command.ExecuteNonQuery();
            }
        }

        private static int DeleteMinionsVillainsById(SqlConnection connection, int id)
        {
            string deleteVillianQuery = @"DELETE FROM MinionsVillains 
                                         WHERE VillainId = @villainId";

            using (SqlCommand command = new SqlCommand(deleteVillianQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", id);
                return command.ExecuteNonQuery();
            }
        }
    }
}
