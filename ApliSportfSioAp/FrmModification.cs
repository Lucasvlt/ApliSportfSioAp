using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ApliSportfSioAp
{
    public partial class FrmModification : Form
    {
        private int idSportif;

        // 🔧 Constructeur pour modification
        public FrmModification(int idSportif, string nom, string prenom, DateTime dateNaissance, string rue, string codePostal, string ville, int niveau, string sport)
        {
            InitializeComponent();
            this.idSportif = idSportif;

            // Préremplir les champs
            txtNom.Text = nom;
            txtPrenom.Text = prenom;
            dtpNaissance.Value = dateNaissance;
            txtRue.Text = rue;
            txtCodePostal.Text = codePostal;
            txtVille.Text = ville;
            txtNiveau.Text = niveau.ToString();
            txtSport.Text = sport;

            ActiverModeModification();
        }

        // 🔧 Constructeur pour ajout
        public FrmModification()
        {
            InitializeComponent();
            ActiverModeAjout();
        }

        // ✅ Méthode pour mode ajout
        private void ActiverModeAjout()
        {
            btnInserer.Visible = true;
            btnModifier.Visible = false;
            this.Text = "Ajout d’un sportif";

            txtNom.Text = "";
            txtPrenom.Text = "";
            txtRue.Text = "";
            txtCodePostal.Text = "";
            txtVille.Text = "";
            txtNiveau.Text = "";
            txtSport.Text = "";
            dtpNaissance.Value = DateTime.Today;
        }

        // ✅ Méthode pour mode modification
        private void ActiverModeModification()
        {
            btnInserer.Visible = false;
            btnModifier.Visible = true;
            this.Text = "Modification du sportif";
        }

        // ✅ Bouton Modifier
        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtNiveau.Text.Trim(), out int niveau))
                {
                    MessageBox.Show("Le champ 'Niveau' doit contenir un nombre entier.");
                    return;
                }

                string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
                using (MySqlConnection cnx = new MySqlConnection(chConnexion))
                {
                    cnx.Open();
                    string requete = @"UPDATE Sportif SET  
                                        nom = @nom,  
                                        prenom = @prenom,  
                                        dateNais = @dateNaissance,  
                                        rue = @rue,  
                                        codePostal = @codePostal,  
                                        ville = @ville,  
                                        niveauExperience = @niveau,  
                                        nomSport = @sport  
                                        WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(requete, cnx);
                    cmd.Parameters.AddWithValue("@nom", txtNom.Text.Trim());
                    cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text.Trim());
                    cmd.Parameters.AddWithValue("@dateNaissance", dtpNaissance.Value);
                    cmd.Parameters.AddWithValue("@rue", txtRue.Text.Trim());
                    cmd.Parameters.AddWithValue("@codePostal", txtCodePostal.Text.Trim());
                    cmd.Parameters.AddWithValue("@ville", txtVille.Text.Trim());
                    cmd.Parameters.AddWithValue("@niveau", niveau);
                    cmd.Parameters.AddWithValue("@sport", txtSport.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", idSportif);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sportif modifié avec succès !");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message);
            }
        }

        // ✅ Bouton Insérer
        private void btnInserer_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérification des champs obligatoires
                if (string.IsNullOrWhiteSpace(txtNom.Text) ||
                    string.IsNullOrWhiteSpace(txtPrenom.Text) ||
                    string.IsNullOrWhiteSpace(txtRue.Text) ||
                    string.IsNullOrWhiteSpace(txtCodePostal.Text) ||
                    string.IsNullOrWhiteSpace(txtVille.Text) ||
                    string.IsNullOrWhiteSpace(txtSport.Text))
                {
                    MessageBox.Show("Tous les champs doivent être remplis.");
                    return;
                }

                if (!int.TryParse(txtNiveau.Text.Trim(), out int niveau))
                {
                    MessageBox.Show("Le champ 'Niveau' doit contenir un nombre entier.");
                    return;
                }

                DateTime dateNaissance = dtpNaissance.Value;

                string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
                using (MySqlConnection cnx = new MySqlConnection(chConnexion))
                {
                    cnx.Open();

                    string requete = @"INSERT INTO Sportif 
                        (nom, prenom, dateNais, rue, codePostal, ville, niveauExperience, nomSport) 
                        VALUES 
                        (@nom, @prenom, @dateNaissance, @rue, @codePostal, @ville, @niveau, @sport)";

                    MySqlCommand cmd = new MySqlCommand(requete, cnx);
                    cmd.Parameters.AddWithValue("@nom", txtNom.Text.Trim());
                    cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text.Trim());
                    cmd.Parameters.AddWithValue("@dateNaissance", dateNaissance);
                    cmd.Parameters.AddWithValue("@rue", txtRue.Text.Trim());
                    cmd.Parameters.AddWithValue("@codePostal", txtCodePostal.Text.Trim());
                    cmd.Parameters.AddWithValue("@ville", txtVille.Text.Trim());
                    cmd.Parameters.AddWithValue("@niveau", niveau);
                    cmd.Parameters.AddWithValue("@sport", txtSport.Text.Trim());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sportif ajouté avec succès !");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'insertion : " + ex.Message);
            }
        }

        
    }
}
