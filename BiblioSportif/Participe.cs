using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace BiblioSportif
{
    public class Participe
    {
        public int IdSportif { get; set; }
        public int IdSport { get; set; } // Renommé pour cohérence SQL

        public Participe(int idSportif, int idSport)
        {
            IdSportif = idSportif;
            IdSport = idSport;
        }

        public Participe() { }

        public void Enregistrer(string chaineConnexion)
        {
            using (var cnx = new MySqlConnection(chaineConnexion))
            {
                // Utilisation de idSport pour correspondre à ta table SQL
                string sql = "INSERT IGNORE INTO Participe (idSportif, idSport) VALUES (@idS, @idSp)";
                var cmd = new MySqlCommand(sql, cnx);
                cmd.Parameters.AddWithValue("@idS", this.IdSportif);
                cmd.Parameters.AddWithValue("@idSp", this.IdSport);

                cnx.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}