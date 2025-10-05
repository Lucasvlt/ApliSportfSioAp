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
    public partial class FrmConnexion : Form
    {
        public FrmConnexion()
        {
            InitializeComponent();
        }

        private void btnCreerCompte_Click(object sender, EventArgs e)
        {
            string login = txtNewLogin.Text.Trim();
            string motDePasse = txtNewMotDePasse.Text;

            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
            using (MySqlConnection cnx = new MySqlConnection(chConnexion))
            {
                cnx.Open();
                string requete = "INSERT INTO Utilisateur (login, motDePasse) VALUES (@login, @mdp)";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@mdp", motDePasse);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Compte créé avec succès !");
                    this.Close();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string motDePasse = txtMotDePasse.Text;

            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
            using (MySqlConnection cnx = new MySqlConnection(chConnexion))
            {
                cnx.Open();
                string requete = "SELECT COUNT(*) FROM Utilisateur WHERE login = @login AND motDePasse = @mdp";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@mdp", motDePasse);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    MessageBox.Show("Connexion réussie !");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login ou mot de passe incorrect.");
                }
            }
        }
        private void btnChangerMotDePasse_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string ancien = txtAncienMotDePasse.Text;
            string nouveau = txtNouveauMotDePasse.Text;

            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
            using (MySqlConnection cnx = new MySqlConnection(chConnexion))
            {
                cnx.Open();
                string requete = "UPDATE Utilisateur SET motDePasse = @nouveau WHERE login = @login AND motDePasse = @ancien";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@ancien", ancien);
                cmd.Parameters.AddWithValue("@nouveau", nouveau);

                int lignes = cmd.ExecuteNonQuery();

                if (lignes == 1)
                    MessageBox.Show("Mot de passe mis à jour !");
                else
                    MessageBox.Show("Ancien mot de passe incorrect.");
            }
        }

        
    }
}
