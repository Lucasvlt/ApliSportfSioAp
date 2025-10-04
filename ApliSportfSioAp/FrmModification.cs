using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ApliSportfSioAp
{
    public partial class FrmModification : Form
    {
        private int idSportif;

        public FrmModification(int idSportif, string nom, string prenom, DateTime dateNaissance, string rue, string codePostal, string ville, int niveau, string sport)
        {
            InitializeComponent();
            this.idSportif = idSportif;

            // Remplir les champs du formulaire
            txtNom.Text = nom;
            txtPrenom.Text = prenom;
            dtpNaissance.Value = dateNaissance;
            txtRue.Text = rue;
            txtCodePostal.Text = codePostal;
            txtVille.Text = ville;
            txtNiveau.Text = niveau.ToString();
            txtSport.Text = sport;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
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
                    cmd.Parameters.AddWithValue("@nom", txtNom.Text);
                    cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text);
                    cmd.Parameters.AddWithValue("@dateNaissance", dtpNaissance.Value);
                    cmd.Parameters.AddWithValue("@rue", txtRue.Text);
                    cmd.Parameters.AddWithValue("@codePostal", txtCodePostal.Text);
                    cmd.Parameters.AddWithValue("@ville", txtVille.Text);
                    cmd.Parameters.AddWithValue("@niveau", int.Parse(txtNiveau.Text));
                    cmd.Parameters.AddWithValue("@sport", txtSport.Text);
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

     

        
    }
}
