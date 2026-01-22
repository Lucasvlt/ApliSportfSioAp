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

        // Bouton Connexion
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string motDePasse = txtMotDePasse.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(motDePasse))
            {
                Info("Veuillez remplir tous les champs.");
                return;
            }

            try
            {
                bool ok = Authenticate(login, motDePasse);
                if (ok)
                {
                    // 🔥 Message personnalisé
                    if (login == "a" && motDePasse == "a")
                    {
                        Info("Bienvenue administrateur !");
                    }
                    else
                    {
                        Info("Bienvenue " + login + " !");
                    }

                    this.Tag = login; // Permet de récupérer le login dans FrmAccueil
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    Attention("Identifiants incorrects.");
                    txtMotDePasse.Clear();
                    txtMotDePasse.Focus();
                }
            }
            catch (MySqlException mex)
            {
                MessageErreur("Erreur base de données : " + mex.Message);
            }
            catch (Exception ex)
            {
                MessageErreur("Erreur inattendue : " + ex.Message);
            }
        }

        // Vérifie les identifiants
        private bool Authenticate(string login, string motDePasse)
        {
            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;

            using (var cnx = new MySqlConnection(chConnexion))
            using (var cmd = new MySqlCommand(
                "SELECT motDePasse FROM Utilisateur WHERE login = @login LIMIT 1", cnx))
            {
                cmd.Parameters.AddWithValue("@login", login);
                cnx.Open();

                var result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    return false;

                string motDePasseStocke = result.ToString();
                return motDePasseStocke == motDePasse;
            }
        }

        // Affiche / masque le panneau de réinitialisation
        private void btnMdPOublie_Click(object sender, EventArgs e)
        {
            panelMotDePasseOublie.Visible = !panelMotDePasseOublie.Visible;
        }

        // Valide la réinitialisation du mot de passe
        private void btnValiderMotDePasse_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string nouveau = txtNouveauMotDePasse.Text.Trim();
            string confirmer = txtConfirmerMotDePasse.Text.Trim();

            if (string.IsNullOrEmpty(login))
            {
                Info("Veuillez entrer votre login pour réinitialiser le mot de passe.");
                return;
            }

            if (string.IsNullOrEmpty(nouveau) || string.IsNullOrEmpty(confirmer))
            {
                Info("Veuillez remplir tous les champs de mot de passe.");
                return;
            }

            if (nouveau != confirmer)
            {
                Attention("Les mots de passe ne correspondent pas.");
                return;
            }

            try
            {
                bool ok = UpdatePassword(login, nouveau);
                if (ok)
                {
                    Info("Mot de passe mis à jour !");
                    panelMotDePasseOublie.Visible = false;
                    txtNouveauMotDePasse.Clear();
                    txtConfirmerMotDePasse.Clear();
                }
                else
                {
                    Attention("Login introuvable.");
                }
            }
            catch (MySqlException mex)
            {
                MessageErreur("Erreur base de données : " + mex.Message);
            }
            catch (Exception ex)
            {
                MessageErreur("Erreur inattendue : " + ex.Message);
            }
        }

        // Mise à jour du mot de passe
        private bool UpdatePassword(string login, string nouveauMotDePasse)
        {
            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;

            using (var cnx = new MySqlConnection(chConnexion))
            using (var cmd = new MySqlCommand(
                "UPDATE Utilisateur SET motDePasse = @mdp WHERE login = @login", cnx))
            {
                cmd.Parameters.AddWithValue("@mdp", nouveauMotDePasse);
                cmd.Parameters.AddWithValue("@login", login);

                cnx.Open();
                int lignes = cmd.ExecuteNonQuery();
                return lignes > 0;
            }
        }

        // Ouvre le formulaire d'inscription
        private void btnInscription_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmInscription())
            {
                frm.ShowDialog();
            }
        }

        // Helpers pour messages
        private void Info(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Attention(string message)
        {
            MessageBox.Show(message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MessageErreur(string message)
        {
            MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

       
    }
}
