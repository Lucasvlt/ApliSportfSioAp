using System;
using System.Configuration;
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

            // Vérification des champs
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(motDePasse) || string.IsNullOrEmpty(confirmer))
            {
                MessageBox.Show("Tous les champs doivent être remplis.");
                return;
            }

            // Vérification des mots de passe identiques
            if (motDePasse != confirmer)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.");
                return;
            }

            // Vérification simple de longueur
            if (motDePasse.Length < 4)
            {
                MessageBox.Show("Le mot de passe doit contenir au moins 4 caractères.");
                return;
            }

            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;

            using (MySqlConnection cnx = new MySqlConnection(chConnexion))
            {
                cnx.Open();

                // Vérifier si le login existe déjà
                using (var checkCmd = new MySqlCommand("SELECT COUNT(*) FROM Utilisateur WHERE login=@login", cnx))
                {
                    checkCmd.Parameters.AddWithValue("@login", login);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Ce login est déjà utilisé.");
                        return;
                    }
                }

                // Insérer le nouvel utilisateur
                using (var cmd = new MySqlCommand(
                    "INSERT INTO Utilisateur (login, motDePasse) VALUES (@login, @mdp)", cnx))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@mdp", motDePasse);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Inscription réussie !");
                        this.Close();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Erreur SQL : " + ex.Message);
                    }
                }
            }

        }
    }
}

