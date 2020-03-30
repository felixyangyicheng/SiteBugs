using MySql.Data.MySqlClient;
using System.Collections.Generic;

using System;
using System.Text;
using SiteBugs.BD.Models;

namespace SiteBugs.BD.DAL
{
    public class BugsContext

    {
        private string connectionString;
        public BugsContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Bug> GetAll()
        {
            List<Bug> bugs = new List<Bug>();

            using (MySqlConnection connection = new MySqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT identifiant, Titre, date, bloquant, identifiantSeverite FROM Bugs;";

                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Bug bug = new Bug();
                    bug.identifiant = reader.GetInt32("identifiant");
                }

            }

        }
    }
}