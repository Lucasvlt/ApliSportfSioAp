using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApliSportfSioAp
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
       
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Démarrer par le formulaire de connexion
            FrmConnexion frmConnexion = new FrmConnexion();
            DialogResult result = frmConnexion.ShowDialog();

            if (result == DialogResult.OK)
            {
                string login = frmConnexion.Tag?.ToString(); // ✅ Récupère le login
                Application.Run(new FrmAccueil(login));      // ✅ Lance le reste du projet
            }
        }

    }
}
