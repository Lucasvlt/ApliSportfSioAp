using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioSportif
{
    public class Utilisateur
    {
        private int id;
        private string login;
        private string motDePasse;

        public Utilisateur(int id, string login, string motDePasse)
        {
            this.Id = id;
            this.Login = login;
            this.MotDePasse = motDePasse;
        }

        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string MotDePasse { get => motDePasse; set => motDePasse = value; }


    }
}
