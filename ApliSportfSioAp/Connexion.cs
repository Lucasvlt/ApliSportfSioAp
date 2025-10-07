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
            InitializeComponent(); // Initialisation du formulaire
        }

        // Bouton de connexion
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            // Récupère les identifiants saisis
            string login = txtLogin.Text.Trim();
            string motDePasse = txtMotDePasse.Text.Trim();

            // Vérifie que les champs ne sont pas vides
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(motDePasse))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            // Connexion à la base
            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
            using (MySqlConnection cnx = new MySqlConnection(chConnexion))
            {
                cnx.Open();

                // Vérifie si l'utilisateur existe
                string requete = "SELECT COUNT(*) FROM Utilisateur WHERE login = @login AND motDePasse = @motDePasse";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@motDePasse", motDePasse);

                int nb = Convert.ToInt32(cmd.ExecuteScalar());

                if (nb > 0)
                {
                    MessageBox.Show("Connexion réussie !");
                    this.DialogResult = DialogResult.OK; // Signale au programme principal que la connexion est OK
                    this.Tag = login; // Stocke le login pour le transmettre à la suite
                    this.Close();     // Ferme le formulaire de connexion
                }
                else
                {
                    MessageBox.Show("Identifiants incorrects.");
                }
            }
        }

        //  Bouton "Mot de passe oublié" → affiche les champs de réinitialisation
        private void btnMdPOublie_Click(object sender, EventArgs e)
        {
            lblNouveau.Visible = true;
            txtNouveauMotDePasse.Visible = true;
            lblConfirmer.Visible = true;
            txtConfirmerMotDePasse.Visible = true;
            btnValiderMotDePasse.Visible = true;
        }

        // Bouton pour valider la réinitialisation du mot de passe
        private void btnValiderMotDePasse_Click(object sender, EventArgs e)
        {
            string nouveau = txtNouveauMotDePasse.Text.Trim();
            string confirmer = txtConfirmerMotDePasse.Text.Trim();
            string login = txtLogin.Text.Trim();

            // Vérifie que le login est bien rempli
            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Veuillez entrer votre login pour réinitialiser le mot de passe.");
                return;
            }

            // Vérifie que les deux champs de mot de passe sont remplis
            if (string.IsNullOrEmpty(nouveau) || string.IsNullOrEmpty(confirmer))
            {
                MessageBox.Show("Veuillez remplir tous les champs de mot de passe.");
                return;
            }

            // Vérifie que les deux mots de passe correspondent
            if (nouveau != confirmer)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.");
                return;
            }

            // Mise à jour du mot de passe dans la base
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

                    // On masque les champs de réinitialisation après succès
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

        // Bouton pour ouvrir le formulaire d’inscription
        private void btnInscription_Click(object sender, EventArgs e)
        {
            FrmInscription frm = new FrmInscription();
            frm.ShowDialog(); // Affiche le formulaire en modal
        }
    }
}