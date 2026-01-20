using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApliSportfSioAp
{
    public partial class FrmSports : Form
    {
        public FrmSports()
        {
            InitializeComponent();
            LoadSports();
        }
        private string GetCnx() => ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;

        private void LoadSports()
        {
            dgvSports.Rows.Clear();
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
                            int id = Convert.ToInt32(rd["id"]);
                            string nom = rd["nomSport"].ToString();
                            dgvSports.Rows.Add(id, nom);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement sports : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            string nom = Interaction.InputBox("Nom du sport :", "Ajouter sport", "");
            if (string.IsNullOrWhiteSpace(nom)) return;

            try
            {
                using (var cnx = new MySqlConnection(GetCnx()))
                using (var cmd = new MySqlCommand("CALL InsererSport(@nom)", cnx))
                {
                    cmd.Parameters.AddWithValue("@nom", nom.Trim());
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadSports();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur ajout : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvSports.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sélectionnez un sport.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvSports.SelectedRows[0].Cells[0].Value);
            string current = dgvSports.SelectedRows[0].Cells[1].Value.ToString();
            string nom = Interaction.InputBox("Modifier nom du sport :", "Modifier sport", current);
            if (string.IsNullOrWhiteSpace(nom)) return;

            try
            {
                using (var cnx = new MySqlConnection(GetCnx()))
                using (var cmd = new MySqlCommand("CALL ModifierSport(@id, @nom)", cnx))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nom", nom.Trim());
                    cnx.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadSports();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur modification : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvSports.SelectedRows.Count == 0)
            {
                MessageBox.Show("Sélectionnez un sport.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = Convert.ToInt32(dgvSports.SelectedRows[0].Cells[0].Value);
            var confirm = MessageBox.Show("Confirmer la suppression ?", "Supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

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
                MessageBox.Show("Erreur suppression : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRafraichir_Click(object sender, EventArgs e) => LoadSports();

        
    }
}
        
