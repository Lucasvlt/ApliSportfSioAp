using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ApliSportfSioAp
{
    public partial class FrmModification : Form
    {
        private int idSportif;
        private bool estModeAjout;

        // MODE MODIFICATION
        public FrmModification(int id, string nom, string pre, DateTime dNais, string rue, string cp, string ville, int niv, string sportsStr)
        {
            InitializeComponent();
            this.idSportif = id;
            this.estModeAjout = false;

            // Remplir les champs
            txtNom.Text = nom;
            txtPrenom.Text = pre;
            dtpNaissance.Value = dNais;
            txtRue.Text = rue;
            txtCodePostal.Text = cp;
            txtVille.Text = ville;
            txtNiveau.Text = niv.ToString();

            // Charger les sports + cocher ceux du sportif
            ChargerEtCocherSports();

            btnInserer.Visible = false;
            btnModifier.Visible = true;
            this.Text = "Modifier Sportif n°" + id;
        }

        // MODE AJOUT
        public FrmModification()
        {
            InitializeComponent();
            this.estModeAjout = true;

            LoadSportsCheckedList();

            btnInserer.Visible = true;
            btnModifier.Visible = false;
            this.Text = "Nouveau Sportif";
        }

        private string GetCnx() =>
            ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;

        // CHARGER LA LISTE DES SPORTS
        private void LoadSportsCheckedList()
        {
            clbSports.Items.Clear();

            using (var cnx = new MySqlConnection(GetCnx()))
            {
                cnx.Open();
                var cmd = new MySqlCommand("SELECT id, nomSport FROM Sport ORDER BY nomSport", cnx);

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        clbSports.Items.Add(new SportItem
                        {
                            Id = rd.GetInt32(0),
                            Name = rd.GetString(1)
                        });
                    }
                }
            }
        }

        // CHARGER LES SPORTS DU SPORTIF + COCHER
        private void ChargerEtCocherSports()
        {
            LoadSportsCheckedList();

            using (var cnx = new MySqlConnection(GetCnx()))
            {
                cnx.Open();

                var cmd = new MySqlCommand("SELECT idSport FROM Participe WHERE idSportif = @id", cnx);
                cmd.Parameters.AddWithValue("@id", idSportif);

                var ids = new List<int>();

                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        ids.Add(rd.GetInt32(0));
                }

                // Cocher les sports correspondants
                for (int i = 0; i < clbSports.Items.Count; i++)
                {
                    var item = (SportItem)clbSports.Items[i];
                    if (ids.Contains(item.Id))
                        clbSports.SetItemChecked(i, true);
                }
            }
        }

        // ENREGISTRER (AJOUT OU MODIFICATION)
        private void Enregistrer(bool isUpdate)
        {
            // 🔥 Vérification obligatoire AVANT de supprimer les sports
            if (clbSports.CheckedItems.Count == 0)
            {
                MessageBox.Show("Un sportif doit pratiquer au moins un sport.");
                return;
            }

            try
            {
                using (var cnx = new MySqlConnection(GetCnx()))
                {
                    cnx.Open();

                    using (var tr = cnx.BeginTransaction())
                    {
                        string sql = isUpdate
                            ? @"UPDATE Sportif SET nom=@n, prenom=@p, dateNais=@d, rue=@r, 
                       codePostal=@cp, ville=@v, niveauExperience=@niv WHERE id=@id"
                            : @"INSERT INTO Sportif (nom, prenom, dateNais, rue, codePostal, ville, niveauExperience) 
                       VALUES (@n, @p, @d, @r, @cp, @v, @niv);
                       SELECT LAST_INSERT_ID();";

                        var cmd = new MySqlCommand(sql, cnx, tr);

                        cmd.Parameters.AddWithValue("@n", txtNom.Text);
                        cmd.Parameters.AddWithValue("@p", txtPrenom.Text);
                        cmd.Parameters.AddWithValue("@d", dtpNaissance.Value);
                        cmd.Parameters.AddWithValue("@r", txtRue.Text);
                        cmd.Parameters.AddWithValue("@cp", txtCodePostal.Text);
                        cmd.Parameters.AddWithValue("@v", txtVille.Text);
                        cmd.Parameters.AddWithValue("@niv", txtNiveau.Text);

                        if (isUpdate)
                        {
                            cmd.Parameters.AddWithValue("@id", idSportif);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            idSportif = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 🔥 Maintenant on peut supprimer les anciens sports
                        var cmdDel = new MySqlCommand("DELETE FROM Participe WHERE idSportif=@id", cnx, tr);
                        cmdDel.Parameters.AddWithValue("@id", idSportif);
                        cmdDel.ExecuteNonQuery();

                        // 🔥 Et réinsérer les nouveaux
                        foreach (SportItem item in clbSports.CheckedItems)
                        {
                            var cmdP = new MySqlCommand(
                                "INSERT INTO Participe (idSportif, idSport) VALUES (@ids, @idp)",
                                cnx, tr);

                            cmdP.Parameters.AddWithValue("@ids", idSportif);
                            cmdP.Parameters.AddWithValue("@idp", item.Id);
                            cmdP.ExecuteNonQuery();
                        }

                        tr.Commit();
                    }
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }


        private void btnModifier_Click(object sender, EventArgs e) =>
            Enregistrer(true);

        private void btnInserer_Click(object sender, EventArgs e) =>
            Enregistrer(false);

        // OBJET POUR STOCKER LES SPORTS DANS LE CHECKEDLISTBOX
        private class SportItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name;
        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
