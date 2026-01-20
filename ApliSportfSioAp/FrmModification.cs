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

            txtNom.Text = "";
            txtPrenom.Text = "";
            txtRue.Text = "";
            txtCodePostal.Text = "";
            txtVille.Text = "";
            txtNiveau.Text = "";
            dtpNaissance.Value = DateTime.Today;
        }

        private void ActiverModeModification()
        {
            btnInserer.Visible = false;
            btnModifier.Visible = true;
            this.Text = "Modification du sportif";
        }

        // Charge la liste des sports dans la CheckedListBox
        private void LoadSportsChecked()
        {
            try
            {
                clbSports.Items.Clear();
                string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
                using (var cnx = new MySqlConnection(chConnexion))
                using (var cmd = new MySqlCommand("SELECT id, nomSport FROM Sport ORDER BY nomSport", cnx))
                {
                    cnx.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            int id = rd.GetInt32("id");
                            string nom = rd.GetString("nomSport");
                            clbSports.Items.Add(new SportItem { Id = id, Name = nom });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des sports : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Charge les sports liés au sportif et coche les éléments correspondants
        private void LoadSelectedSports()
        {
            try
            {
                string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
                using (var cnx = new MySqlConnection(chConnexion))
                using (var cmd = new MySqlCommand("SELECT idSport FROM Participe WHERE idSportif = @idSportif", cnx))
                {
                    cmd.Parameters.AddWithValue("@idSportif", idSportif);
                    cnx.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        var ids = new System.Collections.Generic.HashSet<int>();
                        while (rd.Read())
                            ids.Add(rd.GetInt32("idSport"));
                        for (int i = 0; i < clbSports.Items.Count; i++)
                        {
                            var si = clbSports.Items[i] as SportItem;
                            if (si != null && ids.Contains(si.Id))
                                clbSports.SetItemChecked(i, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des sports du sportif : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var sportsSelectionnes = GetSelectedSportIds();
                if (sportsSelectionnes.Count == 0)
                {
                    MessageBox.Show("Veuillez sélectionner au moins un sport.");
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
                                        niveauExperience = @niveau
                                        WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(requete, cnx);
                    cmd.Parameters.AddWithValue("@nom", txtNom.Text.Trim());
                    cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text.Trim());
                    cmd.Parameters.AddWithValue("@dateNaissance", dtpNaissance.Value);
                    cmd.Parameters.AddWithValue("@rue", txtRue.Text.Trim());
                    cmd.Parameters.AddWithValue("@codePostal", txtCodePostal.Text.Trim());
                    cmd.Parameters.AddWithValue("@ville", txtVille.Text.Trim());
                    cmd.Parameters.AddWithValue("@niveau", niveau);
                    cmd.Parameters.AddWithValue("@id", idSportif);
                    cmd.ExecuteNonQuery();

                    using (var tr = cnx.BeginTransaction())
                    {
                        using (var del = new MySqlCommand("DELETE FROM Participe WHERE idSportif = @idSportif", cnx, tr))
                        {
                            del.Parameters.AddWithValue("@idSportif", idSportif);
                            del.ExecuteNonQuery();
                        }

                        using (var ins = new MySqlCommand("INSERT INTO Participe (idSportif, idSport) VALUES (@idSportif, @idSport)", cnx, tr))
                        {
                            ins.Parameters.AddWithValue("@idSportif", idSportif);
                            var pId = ins.Parameters.Add("@idSport", MySqlDbType.Int32);
                            foreach (var sid in sportsSelectionnes)
                            {
                                pId.Value = sid;
                                ins.ExecuteNonQuery();
                            }
                        }
                        tr.Commit();
                    }

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
                if (string.IsNullOrWhiteSpace(txtNom.Text) ||
                    string.IsNullOrWhiteSpace(txtPrenom.Text) ||
                    string.IsNullOrWhiteSpace(txtRue.Text) ||
                    string.IsNullOrWhiteSpace(txtCodePostal.Text) ||
                    string.IsNullOrWhiteSpace(txtVille.Text))
                {
                    MessageBox.Show("Tous les champs doivent être remplis et un sport sélectionné.");
                    return;
                }

                if (!int.TryParse(txtNiveau.Text.Trim(), out int niveau))
                {
                    MessageBox.Show("Le champ 'Niveau' doit contenir un nombre entier.");
                    return;
                }

                var sportsSelectionnes = GetSelectedSportIds();
                if (sportsSelectionnes.Count == 0)
                {
                    MessageBox.Show("Veuillez sélectionner au moins un sport.");
                    return;
                }

                DateTime dateNaissance = dtpNaissance.Value;
                string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
                using (MySqlConnection cnx = new MySqlConnection(chConnexion))
                {
                    cnx.Open();

                    string requete = @"INSERT INTO Sportif 
                        (nom, prenom, dateNais, rue, codePostal, ville, niveauExperience) 
                        VALUES 
                        (@nom, @prenom, @dateNaissance, @rue, @codePostal, @ville, @niveau)";

                    using (var cmd = new MySqlCommand(requete, cnx))
                    {
                        cmd.Parameters.AddWithValue("@nom", txtNom.Text.Trim());
                        cmd.Parameters.AddWithValue("@prenom", txtPrenom.Text.Trim());
                        cmd.Parameters.AddWithValue("@dateNaissance", dateNaissance);
                        cmd.Parameters.AddWithValue("@rue", txtRue.Text.Trim());
                        cmd.Parameters.AddWithValue("@codePostal", txtCodePostal.Text.Trim());
                        cmd.Parameters.AddWithValue("@ville", txtVille.Text.Trim());
                        cmd.Parameters.AddWithValue("@niveau", niveau);

                        cmd.ExecuteNonQuery();
                    }

                    long nouvelId;
                    using (var idCmd = new MySqlCommand("SELECT LAST_INSERT_ID()", cnx))
                    {
                        nouvelId = Convert.ToInt64(idCmd.ExecuteScalar());
                    }

                    using (var tr = cnx.BeginTransaction())
                    using (var ins = new MySqlCommand("INSERT INTO Participe (idSportif, idSport) VALUES (@idSportif, @idSport)", cnx, tr))
                    {
                        ins.Parameters.AddWithValue("@idSportif", nouvelId);
                        var pId = ins.Parameters.Add("@idSport", MySqlDbType.Int32);
                        foreach (var sid in sportsSelectionnes)
                        {
                            pId.Value = sid;
                            ins.ExecuteNonQuery();
                        }
                        tr.Commit();
                    }

                    MessageBox.Show("Sportif ajouté avec succès !");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'insertion : " + ex.Message);
            }
        }

        // Récupère les ids des sports cochés
        private System.Collections.Generic.List<int> GetSelectedSportIds()
        {
            var list = new System.Collections.Generic.List<int>();
            foreach (var o in clbSports.CheckedItems)
            {
                var si = o as SportItem;
                if (si != null) list.Add(si.Id);
            }
            return list;
        }

        private class SportItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }
        }
    }

