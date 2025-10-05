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

        // ✅ Connexion utilisateur
        
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string motDePasse = txtMotDePasse.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(motDePasse))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

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
                    this.Hide(); // cacher le formulaire de connexion
                    FrmAccueil frm = new FrmAccueil(); // ou ton formulaire principal
                    frm.ShowDialog();
                    this.Close(); // fermer le formulaire après fermeture de FrmAccueil
                }
                else
                {
                    MessageBox.Show("Login ou mot de passe incorrect.");
                }
            }
        }
        // ✅ Création de compte
        private void btnCreerCompte_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string motDePasse = txtMotDePasse.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(motDePasse))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

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
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062) // doublon
                        MessageBox.Show("Ce login existe déjà. Choisissez-en un autre.");
                    else
                        MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        // ✅ Mot de passe oublié
        private void btnMdPOublie_Click(object sender, EventArgs e)
        {
            txtNouveauMotDePasse.Visible = true;
            btnValiderReinitialisation.Visible = true;
            MessageBox.Show("Entrez un nouveau mot de passe et cliquez sur Valider.");
        }

       
        private void btnValiderReinitialisation_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string nouveau = txtNouveauMotDePasse.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(nouveau))
            {
                MessageBox.Show("Veuillez remplir le login et le nouveau mot de passe.");
                return;
            }

            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
            using (MySqlConnection cnx = new MySqlConnection(chConnexion))
            {
                cnx.Open();
                string requete = "UPDATE Utilisateur SET motDePasse = @mdp WHERE login = @login";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@mdp", nouveau);

                int lignes = cmd.ExecuteNonQuery();

                if (lignes == 1)
                {
                    MessageBox.Show("Mot de passe réinitialisé !");
                    txtNouveauMotDePasse.Visible = false;
                    btnValiderReinitialisation.Visible = false;
                    txtNouveauMotDePasse.Text = "";
                }
                else
                {
                    MessageBox.Show("Login introuvable.");
                }
            }
        }
    }
    }

