using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace ApliSportfSioAp
{
    public partial class FrmSports : Form
    {
        public FrmSports()
        {
            InitializeComponent();
            LoadSports(); // Charge la liste au démarrage
        }

        // Récupère la chaîne de connexion
        private string GetCnx()
        {
            return ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;
        }

        // Charge la liste des sports dans le DataGridView
        private void LoadSports()
        {
            dgvSports.Rows.Clear(); // Vide la liste avant de la remplir

            try
            {
                using (var cnx = new MySqlConnection(GetCnx()))
                using (var cmd = new MySqlCommand("CALL ListeSports()", cnx))
                {
                    cnx.Open();

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            dgvSports.Rows.Add(
                                rd.GetInt32("id"),
                                rd.GetString("nomSport")
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement sports : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ajouter un sport
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            string nom = Interaction.InputBox("Nom du sport :", "Ajouter un sport", "").Trim();

            if (string.IsNullOrWhiteSpace(nom))
                return;

            try
            {
                using (var cnx = new MySqlConnection(GetCnx()))
                using (var cmd = new MySqlCommand("CALL InsererSport(@nom)", cnx))
                {
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadSports(); // Rafraîchit la liste
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur ajout : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Modifier un sport
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvSports.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sélectionnez un sport.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvSports.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells[0].Value);
            string current = row.Cells[1].Value.ToString();

            string nom = Interaction.InputBox("Modifier le nom :", "Modifier sport", current).Trim();

            if (string.IsNullOrWhiteSpace(nom))
                return;

            try
            {
                using (var cnx = new MySqlConnection(GetCnx()))
                using (var cmd = new MySqlCommand("CALL ModifierSport(@id, @nom)", cnx))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nom", nom);
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadSports();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur modification : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Supprimer un sport
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvSports.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sélectionnez un sport.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvSports.SelectedRows[0]; // Récupère la ligne sélectionnée
            
            int id = int.Parse(row.Cells[0].Value.ToString()); // Récupère l'ID du sport à supprimer 


            if (MessageBox.Show("Confirmer la suppression ?", "Supprimer",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                using (var cnx = new MySqlConnection(GetCnx()))
                using (var cmd = new MySqlCommand("CALL SupprimerSport(@id)", cnx))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadSports();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur suppression : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Rafraîchir la liste
        private void btnRafraichir_Click(object sender, EventArgs e)
        {
            LoadSports();
        }
    }
}
