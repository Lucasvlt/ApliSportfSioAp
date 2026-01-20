using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ApliSportfSioAp
{
    public partial class FrmModification : Form
    {
        private int idSportif;

        // Constructeur pour modification
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

            LoadSportsCombo();

            // Sélectionne le sport correspondant par nom (si présent)
            if (!string.IsNullOrWhiteSpace(sport) && cbSport.Items.Count > 0)
            {
                for (int i = 0; i < cbSport.Items.Count; i++)
                {
                    var drv = cbSport.Items[i] as DataRowView;
                    if (drv != null && string.Equals(drv["nomSport"].ToString(), sport, StringComparison.OrdinalIgnoreCase))
                    {
                        cbSport.SelectedIndex = i;
                        break;
                    }
                }
            }

            ActiverModeModification();
        }

        // Constructeur pour ajout
        public FrmModification()
        {
            InitializeComponent();
            LoadSportsCombo();
            ActiverModeAjout();
        }

        // Méthode pour mode ajout
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
            dtpNaissance.Value = DateTime.Today;

            if (cbSport.Items.Count > 0)
                cbSport.SelectedIndex = 0;
        }

        // Méthode pour mode modification
        private void ActiverModeModification()
        {
            btnInserer.Visible = false;
            btnModifier.Visible = true;
            this.Text = "Modification du sportif";
        }

        // Charge la combo des sports depuis la table Sport
        private void LoadSportsCombo()
        {
            try
            {
                var dt = new DataTable();
                string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
                using (var cnx = new MySqlConnection(chConnexion))
                using (var cmd = new MySqlCommand("SELECT id, nomSport FROM Sport ORDER BY nomSport", cnx))
                {
                    cnx.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        dt.Load(rd);
                    }
                }

                cbSport.DisplayMember = "nomSport";
                cbSport.ValueMember = "id";
                cbSport.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des sports : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bouton Modifier
        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtNiveau.Text.Trim(), out int niveau))
                {
                    MessageBox.Show("Le champ 'Niveau' doit contenir un nombre entier.");
                    return;
                }

                if (cbSport.SelectedValue == null)
                {
                    MessageBox.Show("Veuillez sélectionner un sport.");
                    return;
                }

                int idSport = Convert.ToInt32(cbSport.SelectedValue);

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
                                        idSport = @idSport  
                                        WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(requete, cnx);
                    cmd.Parameters.AddWithValue("@nom", txtNom.Text.Trim());
                    cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text.Trim());
                    cmd.Parameters.AddWithValue("@dateNaissance", dtpNaissance.Value);
                    cmd.Parameters.AddWithValue("@rue", txtRue.Text.Trim());
                    cmd.Parameters.AddWithValue("@codePostal", txtCodePostal.Text.Trim());
                    cmd.Parameters.AddWithValue("@ville", txtVille.Text.Trim());
                    cmd.Parameters.AddWithValue("@niveau", niveau);
                    cmd.Parameters.AddWithValue("@idSport", idSport);
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

        // Bouton Insérer
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
                    cbSport.SelectedValue == null)
                {
                    MessageBox.Show("Tous les champs doivent être remplis et un sport sélectionné.");
                    return;
                }

                if (!int.TryParse(txtNiveau.Text.Trim(), out int niveau))
                {
                    MessageBox.Show("Le champ 'Niveau' doit contenir un nombre entier.");
                    return;
                }

                DateTime dateNaissance = dtpNaissance.Value;
                int idSport = Convert.ToInt32(cbSport.SelectedValue);

                // Connexion et insertion
                string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
                using (MySqlConnection cnx = new MySqlConnection(chConnexion))
                {
                    cnx.Open();

                    string requete = @"INSERT INTO Sportif 
                        (nom, prenom, dateNais, rue, codePostal, ville, niveauExperience, idSport) 
                        VALUES 
                        (@nom, @prenom, @dateNaissance, @rue, @codePostal, @ville, @niveau, @idSport)";

                    MySqlCommand cmd = new MySqlCommand(requete, cnx);
                    cmd.Parameters.AddWithValue("@nom", txtNom.Text.Trim());
                    cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text.Trim());
                    cmd.Parameters.AddWithValue("@dateNaissance", dateNaissance);
                    cmd.Parameters.AddWithValue("@rue", txtRue.Text.Trim());
                    cmd.Parameters.AddWithValue("@codePostal", txtCodePostal.Text.Trim());
                    cmd.Parameters.AddWithValue("@ville", txtVille.Text.Trim());
                    cmd.Parameters.AddWithValue("@niveau", niveau);
                    cmd.Parameters.AddWithValue("@idSport", idSport);

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
