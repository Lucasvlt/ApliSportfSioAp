using System;
using System.Configuration;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ApliSportfSioAp
{
    public partial class FrmAccueil : Form
    {
        private string login; // Stocke le login de l'utilisateur connecté

        public FrmAccueil(string login)
        {
            InitializeComponent(); // Initialise les composants graphiques
            this.login = login;    // Stocke le login reçu

            // Ajoute les critères de recherche dans la ComboBox
            comboBoxCritere.Items.Add("Ville");
            comboBoxCritere.Items.Add("Niveau");
            comboBoxCritere.Items.Add("Nom du Sport");
            comboBoxCritere.SelectedIndex = 0; // Sélectionne le premier critère par défaut

            // Configure la ListView pour afficher les sportifs
            listSportifs.View = View.Details;
            listSportifs.FullRowSelect = true;
            listSportifs.GridLines = true;

            // Ajoute les colonnes à la ListView
            listSportifs.Columns.Add("ID", 50, HorizontalAlignment.Left);
            listSportifs.Columns.Add("Nom", 100, HorizontalAlignment.Left);
            listSportifs.Columns.Add("Prénom", 100, HorizontalAlignment.Left);
            listSportifs.Columns.Add("Date de naissance", 120, HorizontalAlignment.Center);
            listSportifs.Columns.Add("Rue", 150, HorizontalAlignment.Left);
            listSportifs.Columns.Add("Code Postal", 80, HorizontalAlignment.Center);
            listSportifs.Columns.Add("Ville", 100, HorizontalAlignment.Left);
            listSportifs.Columns.Add("Niveau", 80, HorizontalAlignment.Right);
            listSportifs.Columns.Add("Sport", 100, HorizontalAlignment.Left);

            // Associe le menu contextuel à la ListView
            listSportifs.ContextMenuStrip = contextMenuStrip1;
        }

        // Chargement initial
        private void FrmAccueil_Load(object sender, EventArgs e)
        {
            btnEnvoyer_Click_1(sender, e);// Charge les sportifs dès l'ouverture du formulaire
        }

        // Bouton Rechercher
        private void btnEnvoyer_Click_1(object sender, EventArgs e)
        {
            listSportifs.Items.Clear(); // Vide la liste avant chaque recherche

            if (comboBoxCritere.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un critère de recherche.");
                return;
            }

            string critere = comboBoxCritere.SelectedItem.ToString(); // Récupère le critère
            string valeur = txtValeur.Text.Trim(); // Récupère la valeur saisie

            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
            try
            {
                using (MySqlConnection cnx = new MySqlConnection(chConnexion))
                {
                    cnx.Open();

                    MySqlCommand cmd;
                    bool filtrer = !string.IsNullOrEmpty(valeur); // Vérifie si une valeur est saisie

                    if (!filtrer)
                    {
                        // Appel de la procédure stockée qui retourne tous les sportifs
                        cmd = new MySqlCommand("CALL ToutSelectionner()", cnx);
                    }
                    else
                    {
                        // Requête paramétrée selon le critère
                        string chRequete = "SELECT s.id, s.nom, s.prenom, s.dateNais, s.rue, s.codePostal, s.ville, s.niveauExperience, sp.nomSport FROM Sportif s INNER JOIN Sport sp ON s.idSport = sp.id WHERE ";
                        switch (critere)
                        {
                            case "Ville":
                                chRequete += "s.Ville LIKE @valeur";
                                break;
                            case "Niveau":
                                chRequete += "s.niveauExperience = @valeur";
                                break;
                            case "Nom du Sport":
                                chRequete += "sp.nomSport LIKE @valeur";
                                break;
                            default:
                                chRequete += "1=1";
                                break;
                        }

                        cmd = new MySqlCommand(chRequete, cnx);

                        if (critere == "Niveau" && int.TryParse(valeur, out int niveau))
                            cmd.Parameters.AddWithValue("@valeur", niveau); // Filtre exact pour niveau
                        else
                            cmd.Parameters.AddWithValue("@valeur", "%" + valeur + "%"); // Filtre partiel
                    }

                    using (MySqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            // Lecture sûre des colonnes avec vérification des DBNull
                            int id = rd.IsDBNull(0) ? 0 : rd.GetInt32(0);
                            string nom = rd.IsDBNull(1) ? string.Empty : rd.GetString(1);
                            string prenom = rd.IsDBNull(2) ? string.Empty : rd.GetString(2);
                            string dateStr = rd.IsDBNull(3) ? string.Empty : rd.GetDateTime(3).ToShortDateString();
                            string rue = rd.IsDBNull(4) ? string.Empty : rd.GetString(4);
                            string cp = rd.IsDBNull(5) ? string.Empty : rd.GetString(5);
                            string ville = rd.IsDBNull(6) ? string.Empty : rd.GetString(6);
                            string niveauStr = rd.IsDBNull(7) ? "0" : rd.GetInt32(7).ToString();
                            string sport = rd.IsDBNull(8) ? string.Empty : rd.GetString(8);

                            // Crée un item pour chaque sportif
                            ListViewItem item = new ListViewItem(id.ToString());
                            item.SubItems.Add(nom);
                            item.SubItems.Add(prenom);
                            item.SubItems.Add(dateStr);
                            item.SubItems.Add(rue);
                            item.SubItems.Add(cp);
                            item.SubItems.Add(ville);
                            item.SubItems.Add(niveauStr);
                            item.SubItems.Add(sport);

                            listSportifs.Items.Add(item); // Ajoute à la ListView
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération des sportifs : " + ex.Message);
            }
        }

        private void btnQuitter_Click_1(object sender, EventArgs e)
        {
            this.Close();// Ferme le formulaire
        }

        private void txtValeur_TextChanged(object sender, EventArgs e)
        {
            // Optionnel : recherche en temps réel
        }

        // Supprimé : ne pas déclencher automatiquement la modification
        private void listSportifs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ne rien faire ici
        }

        // Menu contextuel : clic droit
        private void listSportifs_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = listSportifs.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                    contextMenuStrip1.Show(listSportifs, e.Location);// Affiche le menu
                }
            }
        }

        // Actions du menu contextuel
        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listSportifs.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listSportifs.SelectedItems[0];

                // Récupère les données du sportif sélectionné
                int idSportif = int.Parse(selectedItem.SubItems[0].Text);
                string nom = selectedItem.SubItems[1].Text;
                string prenom = selectedItem.SubItems[2].Text;
                DateTime dateNaissance = DateTime.Parse(selectedItem.SubItems[3].Text);
                string rue = selectedItem.SubItems[4].Text;
                string codePostal = selectedItem.SubItems[5].Text;
                string ville = selectedItem.SubItems[6].Text;
                int niveau = int.Parse(selectedItem.SubItems[7].Text);
                string sport = selectedItem.SubItems[8].Text;

                // Ouvre le formulaire de modification
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