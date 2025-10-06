using System;
using System.Configuration;
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

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string motDePasse = txtMotDePasse.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(motDePasse))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
            using (MySqlConnection cnx = new MySqlConnection(chConnexion))
            {
                cnx.Open();
                string requete = "SELECT COUNT(*) FROM Utilisateur WHERE login = @login AND motDePasse = @motDePasse";

                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@motDePasse", motDePasse);

                int nb = Convert.ToInt32(cmd.ExecuteScalar());

                if (nb > 0)
                {
                    MessageBox.Show("Connexion réussie !");
                    this.DialogResult = DialogResult.OK; // ✅ Indique au Main que c’est validé
                    this.Tag = login; // ✅ Stocke le login pour le récupérer dans Main
                    this.Close();     // ✅ Ferme le formulaire de connexion
                }
                else
                {
                    MessageBox.Show("Identifiants incorrects.");
                }
            }
        }

        private void btnMdPOublie_Click(object sender, EventArgs e)
        {
            lblNouveau.Visible = true;
            txtNouveauMotDePasse.Visible = true;
            lblConfirmer.Visible = true;
            txtConfirmerMotDePasse.Visible = true;
            btnValiderMotDePasse.Visible = true;
        }

        private void btnValiderMotDePasse_Click(object sender, EventArgs e)
        {
            string nouveau = txtNouveauMotDePasse.Text.Trim();
            string confirmer = txtConfirmerMotDePasse.Text.Trim();
            string login = txtLogin.Text.Trim();

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Veuillez entrer votre login pour réinitialiser le mot de passe.");
                return;
            }
            if (string.IsNullOrEmpty(nouveau) || string.IsNullOrEmpty(confirmer))
            {
                MessageBox.Show("Veuillez remplir tous les champs de mot de passe.");
                return;
            }
            if (nouveau != confirmer)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.");
                return;
            }
            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
            using (MySqlConnection cnx = new MySqlConnection(chConnexion))
            {
                cnx.Open();
                string requete = "UPDATE Utilisateur SET motDePasse = @mdp WHERE login = @login";

                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@mdp", nouveau);
                cmd.Parameters.AddWithValue("@login", login);

                int lignes = cmd.ExecuteNonQuery();

                if (lignes > 0)
                {
                    MessageBox.Show("Mot de passe mis à jour !");
                    // Tu peux cacher les champs à nouveau
                    lblNouveau.Visible = false;
                    txtNouveauMotDePasse.Visible = false;
                    lblConfirmer.Visible = false;
                    txtConfirmerMotDePasse.Visible = false;
                    btnValiderMotDePasse.Visible = false;
                }
                else
                {
                    MessageBox.Show("Login introuvable.");
                }
            }
        }

        private void btnInscription_Click(object sender, EventArgs e)
        {
            FrmInscription frm = new FrmInscription();
            frm.ShowDialog();
        }
    }
}

