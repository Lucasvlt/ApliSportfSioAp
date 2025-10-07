
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
using MySql.Data.MySqlClient; 

namespace ApliSportfSioAp
{
    // Déclaration du formulaire d'inscription
    public partial class FrmInscription : Form
    {
        // Constructeur du formulaire
        public FrmInscription()
        {
            InitializeComponent(); // Initialise les composants graphiques
        }

        // Événement déclenché lors du clic sur le bouton "Valider l'inscription"
        private void btnValiderInscription_Click(object sender, EventArgs e)
        {
            // Récupération des valeurs saisies par l'utilisateur
            string login = txtLogin.Text.Trim();
            string motDePasse = txtMotDePasse.Text.Trim();
            string confirmer = txtConfirmerMotDePasse.Text.Trim();

            // Vérifie que tous les champs sont remplis
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(motDePasse) || string.IsNullOrEmpty(confirmer))
            {
                MessageBox.Show("Tous les champs doivent être remplis.");
                return; // Stoppe l'exécution si un champ est vide
            }

            // Vérifie que les deux mots de passe sont identiques
            if (motDePasse != confirmer)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.");
                return; // Stoppe l'exécution si les mots de passe ne correspondent pas
            }

            // Récupère la chaîne de connexion depuis App.config
            string chConnexion = ConfigurationManager.ConnectionStrings["cnxBdSport"].ConnectionString;

            // Connexion à la base de données
            using (MySqlConnection cnx = new MySqlConnection(chConnexion))
            {
                cnx.Open(); // Ouvre la connexion

                // Requête SQL pour insérer un nouvel utilisateur
                string requete = "INSERT INTO Utilisateur (login, motDePasse) VALUES (@login, @motDePasse)";
                MySqlCommand cmd = new MySqlCommand(requete, cnx);

                // Ajout des paramètres à la requête
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@motDePasse", motDePasse);

                try
                {
                    // Exécution de la requête
                    cmd.ExecuteNonQuery();

                    // Affiche un message de succès
                    MessageBox.Show("Inscription réussie !");
                    this.Close(); // Ferme le formulaire après inscription
                }
                catch (MySqlException ex)
                {
                    // Si le login existe déjà (erreur 1062), affiche un message spécifique
                    if (ex.Number == 1062)
                        MessageBox.Show("Ce login est déjà pris.");
                    else
                        // Affiche toute autre erreur SQL
                        MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }
    }
}
