using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ApliSportfSioAp
{
    public partial class FrmAccueil : Form
    {
        private readonly string login;

        public FrmAccueil(string login)
        {
            InitializeComponent();
            this.login = login;

            // Remplissage du ComboBox
            comboBoxCritere.Items.AddRange(new string[] { "Ville", "Niveau", "Nom du Sport" });
            comboBoxCritere.SelectedIndex = 0;

            // Configuration du ListView
            listSportifs.View = View.Details;
            listSportifs.FullRowSelect = true;
            listSportifs.GridLines = true;
            listSportifs.Columns.Clear();
            listSportifs.Columns.Add("ID", 50);
            listSportifs.Columns.Add("Nom", 100);
            listSportifs.Columns.Add("Prénom", 100);
            listSportifs.Columns.Add("Date de naissance", 120);
            listSportifs.Columns.Add("Rue", 150);
            listSportifs.Columns.Add("Code Postal", 80);
            listSportifs.Columns.Add("Ville", 100);
            listSportifs.Columns.Add("Niveau", 60);
            listSportifs.Columns.Add("Sports", 150);

            listSportifs.ContextMenuStrip = contextMenuStrip1;
        }

        private void FrmAccueil_Load(object sender, EventArgs e)
        {
            RafraichirListe();
        }

        private void btnEnvoyer_Click_1(object sender, EventArgs e)
        {
            RafraichirListe();
        }

        private void RafraichirListe()
        {
            listSportifs.Items.Clear();

            string critere = comboBoxCritere.SelectedItem?.ToString();
            string valeur = txtValeur.Text.Trim();
            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;

            try
            {
                using (MySqlConnection cnx = new MySqlConnection(chConnexion))
                {
                    cnx.Open();

                    string sql = @"SELECT s.id, s.nom, s.prenom, s.dateNais, s.rue, s.codePostal, s.ville, s.niveauExperience,
                                   IFNULL(GROUP_CONCAT(sp.nomSport SEPARATOR ', '), 'Aucun') AS Sports
                                   FROM Sportif s
                                   LEFT JOIN Participe p ON s.id = p.idSportif
                                   LEFT JOIN Sport sp ON p.idSport = sp.id ";

                    // Ajout du filtre
                    if (!string.IsNullOrEmpty(valeur))
                    {
                        switch (critere)
                        {
                            case "Ville":
                                sql += " WHERE s.ville LIKE @valeur ";
                                break;

                            case "Niveau":
                                sql += " WHERE s.niveauExperience = @valeur ";
                                break;

                            case "Nom du Sport":
                                sql += " WHERE sp.nomSport LIKE @valeur ";
                                break;
                        }
                    }

                    sql += " GROUP BY s.id ORDER BY s.nom, s.prenom";

                    using (MySqlCommand cmd = new MySqlCommand(sql, cnx))
                    {
                        if (!string.IsNullOrEmpty(valeur))
                        {
                            if (critere == "Niveau")
                                cmd.Parameters.AddWithValue("@valeur", valeur);
                            else
                                cmd.Parameters.AddWithValue("@valeur", "%" + valeur + "%");
                        }

                        using (MySqlDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                ListViewItem item = new ListViewItem(rd["id"].ToString());
                                item.SubItems.Add(rd["nom"].ToString());
                                item.SubItems.Add(rd["prenom"].ToString());
                                item.SubItems.Add(Convert.ToDateTime(rd["dateNais"]).ToShortDateString());
                                item.SubItems.Add(rd["rue"].ToString());
                                item.SubItems.Add(rd["codePostal"].ToString());
                                item.SubItems.Add(rd["ville"].ToString());
                                item.SubItems.Add(rd["niveauExperience"].ToString());
                                item.SubItems.Add(rd["Sports"].ToString());

                                listSportifs.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement : " + ex.Message);
            }
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listSportifs.SelectedItems.Count == 0)
                return;

            ListViewItem it = listSportifs.SelectedItems[0];

            FrmModification frm = new FrmModification(
                int.Parse(it.Text),
                it.SubItems[1].Text,
                it.SubItems[2].Text,
                DateTime.Parse(it.SubItems[3].Text),
                it.SubItems[4].Text,
                it.SubItems[5].Text,
                it.SubItems[6].Text,
                int.Parse(it.SubItems[7].Text),
                it.SubItems[8].Text
            );

            if (frm.ShowDialog() == DialogResult.OK)
                RafraichirListe();
        }

        private void btnAjouter_Click_1(object sender, EventArgs e)
        {
            FrmModification frm = new FrmModification();
            if (frm.ShowDialog() == DialogResult.OK)
                RafraichirListe();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listSportifs.SelectedItems.Count == 0)
                return;

            int id = int.Parse(listSportifs.SelectedItems[0].Text);

            if (MessageBox.Show("Supprimer ce sportif ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (var cnx = new MySqlConnection(ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString))
                    {
                        cnx.Open();

                        // Suppression sécurisée
                        using (var cmd1 = new MySqlCommand("DELETE FROM Participe WHERE idSportif=@id", cnx))
                        {
                            cmd1.Parameters.AddWithValue("@id", id);
                            cmd1.ExecuteNonQuery();
                        }

                        using (var cmd2 = new MySqlCommand("DELETE FROM Sportif WHERE id=@id", cnx))
                        {
                            cmd2.Parameters.AddWithValue("@id", id);
                            cmd2.ExecuteNonQuery();
                        }
                    }

                    RafraichirListe();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur suppression : " + ex.Message);
                }
            }
        }

        private void btnQuitter_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGererSports_Click(object sender, EventArgs e)
        {
            using (var f = new FrmSports())
                f.ShowDialog();
        }

        private void listSportifs_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
