using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ApliSportfSioAp
{
    public partial class FrmAccueil : Form
    {
        private string login;

        public FrmAccueil()
        {
            InitializeComponent();
            FrmAccueil frm = new FrmAccueil(login);
            // Initialisation des critères de recherche
            comboBoxCritere.Items.Add("Ville");
            comboBoxCritere.Items.Add("Niveau");
            comboBoxCritere.Items.Add("Nom du Sport");
            comboBoxCritere.SelectedIndex = 0;

            // Configuration de la ListView
            listSportifs.View = View.Details;
            listSportifs.FullRowSelect = true;
            listSportifs.GridLines = true;

            listSportifs.Columns.Add("ID", 50, HorizontalAlignment.Left);
            listSportifs.Columns.Add("Nom", 100, HorizontalAlignment.Left);
            listSportifs.Columns.Add("Prénom", 100, HorizontalAlignment.Left);
            listSportifs.Columns.Add("Date de naissance", 120, HorizontalAlignment.Center);
            listSportifs.Columns.Add("Rue", 150, HorizontalAlignment.Left);
            listSportifs.Columns.Add("Code Postal", 80, HorizontalAlignment.Center);
            listSportifs.Columns.Add("Ville", 100, HorizontalAlignment.Left);
            listSportifs.Columns.Add("Niveau", 80, HorizontalAlignment.Right);
            listSportifs.Columns.Add("Sport", 100, HorizontalAlignment.Left);

            // Associer le menu contextuel
            listSportifs.ContextMenuStrip = contextMenuStrip1;
        }

        public FrmAccueil(string login)
        {
            this.login = login;
        }

        private void FrmAccueil_Load(object sender, EventArgs e)
        {
            btnEnvoyer_Click_1(sender, e);
        }

        private void btnEnvoyer_Click_1(object sender, EventArgs e)
        {
            listSportifs.Items.Clear();

            string critere = comboBoxCritere.SelectedItem.ToString();
            string valeur = txtValeur.Text.Trim();

            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
            using (MySqlConnection cnx = new MySqlConnection(chConnexion))
            {
                cnx.Open();

                string chRequete = "SELECT * FROM Sportif";
                bool filtrer = !string.IsNullOrEmpty(valeur);

                if (filtrer)
                {
                    chRequete += " WHERE ";
                    switch (critere)
                    {
                        case "Ville":
                            chRequete += "Ville LIKE @valeur";
                            break;
                        case "Niveau":
                            chRequete += "NiveauExperience = @valeur";
                            break;
                        case "Nom du Sport":
                            chRequete += "NomSport LIKE @valeur";
                            break;
                    }
                }

                MySqlCommand cmd = new MySqlCommand(chRequete, cnx);

                if (filtrer)
                {
                    if (critere == "Niveau" && int.TryParse(valeur, out int niveau))
                        cmd.Parameters.AddWithValue("@valeur", niveau);
                    else
                        cmd.Parameters.AddWithValue("@valeur", "%" + valeur + "%");
                }

                MySqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    ListViewItem item = new ListViewItem(rd.GetInt32(0).ToString());
                    item.SubItems.Add(rd.GetString(1));
                    item.SubItems.Add(rd.GetString(2));
                    item.SubItems.Add(rd.GetDateTime(3).ToShortDateString());
                    item.SubItems.Add(rd.GetString(4));
                    item.SubItems.Add(rd.GetString(5));
                    item.SubItems.Add(rd.GetString(6));
                    item.SubItems.Add(rd.GetInt32(7).ToString());
                    item.SubItems.Add(rd.GetString(8));

                    listSportifs.Items.Add(item);
                }

                rd.Close();
            }
        }


        private void btnQuitter_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtValeur_TextChanged(object sender, EventArgs e)
        {
            // Optionnel : recherche en temps réel
        }

        // ❌ Supprimé : ne pas déclencher automatiquement la modification
        private void listSportifs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ne rien faire ici
        }

        // ✅ Menu contextuel : clic droit
        private void listSportifs_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = listSportifs.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                    contextMenuStrip1.Show(listSportifs, e.Location);
                }
            }
        }

        // ✅ Actions du menu contextuel
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listSportifs.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listSportifs.SelectedItems[0];

                int idSportif = int.Parse(selectedItem.SubItems[0].Text);
                string nom = selectedItem.SubItems[1].Text;
                string prenom = selectedItem.SubItems[2].Text;
                DateTime dateNaissance = DateTime.Parse(selectedItem.SubItems[3].Text);
                string rue = selectedItem.SubItems[4].Text;
                string codePostal = selectedItem.SubItems[5].Text;
                string ville = selectedItem.SubItems[6].Text;
                int niveau = int.Parse(selectedItem.SubItems[7].Text);
                string sport = selectedItem.SubItems[8].Text;

                FrmModification frmModif = new FrmModification(idSportif, nom, prenom, dateNaissance, rue, codePostal, ville, niveau, sport);
                frmModif.ShowDialog();

                // Recharge la liste après modification
                btnEnvoyer_Click_1(null, null);
            }
            else
            {
                MessageBox.Show("Sélectionne un sportif dans la liste.");
            }
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listSportifs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Sélectionne un sportif dans la liste.");
                return;
            }

            ListViewItem selectedItem = listSportifs.SelectedItems[0];
            int idSportif;

            // Vérification de l'ID
            if (!int.TryParse(selectedItem.SubItems[0].Text, out idSportif))
            {
                MessageBox.Show("ID invalide.");
                return;
            }

            // Confirmation
            DialogResult confirm = MessageBox.Show("Confirmer la suppression ?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
                using (MySqlConnection cnx = new MySqlConnection(chConnexion))
                {
                    cnx.Open();

                    string requete = "DELETE FROM Sportif WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(requete, cnx))
                    {
                        cmd.Parameters.AddWithValue("@id", idSportif);
                        int lignesAffectées = cmd.ExecuteNonQuery();

                        if (lignesAffectées > 0)
                        {
                            MessageBox.Show("Sportif supprimé !");
                            btnEnvoyer_Click_1(null, null); // Recharge la liste
                        }
                        else
                        {
                            MessageBox.Show("Aucun sportif trouvé avec cet ID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FrmModification frmAjout = new FrmModification(); // Ouvre le formulaire vide
            frmAjout.ShowDialog(); // Attend que l'utilisateur insère et ferme

            // Recharge la liste après ajout
            btnEnvoyer_Click_1(null, null);
        }
    }
    }

