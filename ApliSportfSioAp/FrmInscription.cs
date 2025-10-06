using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ApliSportfSioAp
{
    public partial class FrmInscription : Form
    {
        public FrmInscription()
        {
            InitializeComponent();
        }
        private void btnValiderInscription_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string motDePasse = txtMotDePasse.Text.Trim();
            string confirmer = txtConfirmerMotDePasse.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(motDePasse) || string.IsNullOrEmpty(confirmer))
            {
                MessageBox.Show("Tous les champs doivent être remplis.");
                return;
            }

            if (motDePasse != confirmer)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.");
                return;
            }

            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
            using (MySqlConnection cnx = new MySqlConnection(chConnexion))
            {
                cnx.Open();

                string requete = "INSERT INTO Utilisateur (login, motDePasse) VALUES (@login, @motDePasse)";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@motDePasse", motDePasse);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inscription réussie !");
                    this.Close();
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062) // login déjà utilisé
                        MessageBox.Show("Ce login est déjà pris.");
                    else
                        MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

      
    }
}
