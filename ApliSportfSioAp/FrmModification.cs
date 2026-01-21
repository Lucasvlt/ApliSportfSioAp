using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic; // Ajouté pour List et HashSet
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

            LoadSportsChecked();
            LoadSelectedSports();
            ActiverModeModification();
        }

        // Constructeur pour ajout
        public FrmModification()
        {
            InitializeComponent();
            LoadSportsChecked();
            ActiverModeAjout();
        }

        private void ActiverModeAjout()
        {
            btnInserer.Visible = true;
            btnModifier.Visible = false;
            this.Text = "Ajout d’un sportif";
            dtpNaissance.Value = DateTime.Today;
        }

        private void ActiverModeModification()
        {
            btnInserer.Visible = false;
            btnModifier.Visible = true;
            this.Text = "Modification du sportif";
        }

        private string GetConnectionString() => ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;

        private void LoadSportsChecked()
        {
            try
            {
                clbSports.Items.Clear();
                using (var cnx = new MySqlConnection(GetConnectionString()))
                using (var cmd = new MySqlCommand("SELECT id, nomSport FROM Sport ORDER BY nomSport", cnx))
                {
                    cnx.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            clbSports.Items.Add(new SportItem
                            {
                                Id = rd.GetInt32("id"),
                                Name = rd.GetString("nomSport")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement sports : " + ex.Message);
            }
        }

        private void LoadSelectedSports()
        {
            try
            {
                using (var cnx = new MySqlConnection(GetConnectionString()))
                using (var cmd = new MySqlCommand("SELECT idSport FROM Participe WHERE idSportif = @idSportif", cnx))
                {
                    cmd.Parameters.AddWithValue("@idSportif", idSportif);
                    cnx.Open();
                    var ids = new HashSet<int>();
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read()) ids.Add(rd.GetInt32("idSport"));
                    }

                    for (int i = 0; i < clbSports.Items.Count; i++)
                    {
                        if (clbSports.Items[i] is SportItem si && ids.Contains(si.Id))
                            clbSports.SetItemChecked(i, true);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Erreur sports sélectionnés : " + ex.Message); }
        }

        // BOUTON MODIFIER (Correction des colonnes manquantes)
        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection cnx = new MySqlConnection(GetConnectionString()))
                {
                    cnx.Open();
                    using (MySqlTransaction tr = cnx.BeginTransaction())
                    {
                        // CORRECTION : Ajout de dateNais, rue, codePostal dans l'UPDATE
                        string sqlU = "UPDATE Sportif SET nom=@n, prenom=@p, dateNais=@d, rue=@r, codePostal=@cp, ville=@v, niveauExperience=@niv WHERE id=@id";
                        MySqlCommand cmdU = new MySqlCommand(sqlU, cnx, tr);
                        cmdU.Parameters.AddWithValue("@n", txtNom.Text);
                        cmdU.Parameters.AddWithValue("@p", txtPrenom.Text);
                        cmdU.Parameters.AddWithValue("@d", dtpNaissance.Value);
                        cmdU.Parameters.AddWithValue("@r", txtRue.Text);
                        cmdU.Parameters.AddWithValue("@cp", txtCodePostal.Text);
                        cmdU.Parameters.AddWithValue("@v", txtVille.Text);
                        cmdU.Parameters.AddWithValue("@niv", txtNiveau.Text);
                        cmdU.Parameters.AddWithValue("@id", this.idSportif);
                        cmdU.ExecuteNonQuery();

                        // 2. Refresh les sports
                        MySqlCommand cmdDel = new MySqlCommand("DELETE FROM Participe WHERE idSportif = @id", cnx, tr);
                        cmdDel.Parameters.AddWithValue("@id", this.idSportif);
                        cmdDel.ExecuteNonQuery();

                        foreach (SportItem item in clbSports.CheckedItems)
                        {
                            MySqlCommand cmdIns = new MySqlCommand("INSERT INTO Participe (idSportif, idSport) VALUES (@ids, @idp)", cnx, tr);
                            cmdIns.Parameters.AddWithValue("@ids", this.idSportif);
                            cmdIns.Parameters.AddWithValue("@idp", item.Id);
                            cmdIns.ExecuteNonQuery();
                        }
                        tr.Commit();
                    }
                }
                MessageBox.Show("Modification effectuée !");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex) { MessageBox.Show("Erreur modification : " + ex.Message); }
        }

        // BOUTON INSERER
        private void btnInserer_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection cnx = new MySqlConnection(GetConnectionString()))
                {
                    cnx.Open();
                    using (MySqlTransaction tr = cnx.BeginTransaction())
                    {
                        string sqlS = "INSERT INTO Sportif (nom, prenom, dateNais, rue, codePostal, ville, niveauExperience) " +
                                      "VALUES (@nom, @pre, @date, @rue, @cp, @ville, @niv); SELECT LAST_INSERT_ID();";

                        MySqlCommand cmdS = new MySqlCommand(sqlS, cnx, tr);
                        cmdS.Parameters.AddWithValue("@nom", txtNom.Text);
                        cmdS.Parameters.AddWithValue("@pre", txtPrenom.Text);
                        cmdS.Parameters.AddWithValue("@date", dtpNaissance.Value);
                        cmdS.Parameters.AddWithValue("@rue", txtRue.Text);
                        cmdS.Parameters.AddWithValue("@cp", txtCodePostal.Text);
                        cmdS.Parameters.AddWithValue("@ville", txtVille.Text);
                        cmdS.Parameters.AddWithValue("@niv", txtNiveau.Text);

                        int nouvelId = Convert.ToInt32(cmdS.ExecuteScalar());

                        foreach (SportItem item in clbSports.CheckedItems)
                        {
                            MySqlCommand cmdP = new MySqlCommand("INSERT INTO Participe (idSportif, idSport) VALUES (@ids, @idp)", cnx, tr);
                            cmdP.Parameters.AddWithValue("@ids", nouvelId);
                            cmdP.Parameters.AddWithValue("@idp", item.Id);
                            cmdP.ExecuteNonQuery();
                        }
                        tr.Commit();
                    }
                }
                MessageBox.Show("Sportif ajouté avec succès !");
                this.DialogResult = DialogResult.OK; // Ferme automatiquement si ShowDialog() est utilisé
            }
            catch (Exception ex) { MessageBox.Show("Erreur insertion : " + ex.Message); }
        }

        private class SportItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }
    }
}