using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace BiblioSportif
{
    public class Participe
    {
        private int idSportif;
        private int idSport;

        public Participe(int idSportif, int idSport)
        {
            this.IdSportif = idSportif;
            this.IdSport = idSport;
        }

        public int IdSportif { get => idSportif; set => idSportif = value; }
        public int IdSport
        {
            get => idSport; set => idSport = value;
        }
    }
}