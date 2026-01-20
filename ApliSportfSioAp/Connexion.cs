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
                ShowInfo("Veuillez remplir tous les champs.");
                return;
            }

            try
            {
                bool ok = Authenticate(login, motDePasse);
                if (ok)
                {
                    ShowInfo("Connexion réussie !");
                    this.Tag = login;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowWarning("Identifiants incorrects.");
                    txtMotDePasse.Clear();
                    txtMotDePasse.Focus();
                }
            }
            catch (MySqlException mex)
            {
                ShowError("Erreur base de données : " + mex.Message);
            }
            catch (Exception ex)
            {
                ShowError("Erreur inattendue : " + ex.Message);
            }
        }

        // Vérifie les identifiants (simple pour apprentissage)
        private bool Authenticate(string login, string motDePasse)
        {
            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
            using (var cnx = new MySqlConnection(chConnexion))
            using (var cmd = new MySqlCommand("SELECT motDePasse FROM Utilisateur WHERE login = @login LIMIT 1", cnx))
            {
                cmd.Parameters.AddWithValue("@login", login);
                cnx.Open();
                var result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    return false;

                string motDePasseStocke = result.ToString();
                // comparaison simple (texte). Remplacer par vérification de hash plus tard.
                return motDePasseStocke == motDePasse;
            }
        }

        // Affiche le panneau de réinitialisation du mot de passe
        private void btnMdPOublie_Click(object sender, EventArgs e)
        {
            panelMotDePasseOublie.Visible = !panelMotDePasseOublie.Visible;
        }

        // Valide et applique la mise à jour du mot de passe
        private void btnValiderMotDePasse_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string nouveau = txtNouveauMotDePasse.Text.Trim();
            string confirmer = txtConfirmerMotDePasse.Text.Trim();

            if (string.IsNullOrEmpty(login))
            {
                ShowInfo("Veuillez entrer votre login pour réinitialiser le mot de passe.");
                return;
            }

            if (string.IsNullOrEmpty(nouveau) || string.IsNullOrEmpty(confirmer))
            {
                ShowInfo("Veuillez remplir tous les champs de mot de passe.");
                return;
            }

            if (nouveau != confirmer)
            {
                ShowWarning("Les mots de passe ne correspondent pas.");
                return;
            }

            try
            {
                bool ok = UpdatePassword(login, nouveau);
                if (ok)
                {
                    ShowInfo("Mot de passe mis à jour !");
                    panelMotDePasseOublie.Visible = false;
                    txtNouveauMotDePasse.Clear();
                    txtConfirmerMotDePasse.Clear();
                }
                else
                {
                    ShowWarning("Login introuvable.");
                }
            }
            catch (MySqlException mex)
            {
                ShowError("Erreur base de données : " + mex.Message);
            }
            catch (Exception ex)
            {
                ShowError("Erreur inattendue : " + ex.Message);
            }
        }

        // Met à jour le mot de passe (simple). En production, hacher avant d'enregistrer.
        private bool UpdatePassword(string login, string nouveauMotDePasse)
        {
            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
            using (var cnx = new MySqlConnection(chConnexion))
            using (var cmd = new MySqlCommand("UPDATE Utilisateur SET motDePasse = @mdp WHERE login = @login", cnx))
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

        // Helpers pour messages (simplifie l'affichage)
        private void ShowInfo(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}