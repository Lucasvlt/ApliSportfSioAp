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
            if (frmConnexion.ShowDialog() == DialogResult.OK)
            {
                // Si la connexion est réussie, ouvrir le formulaire principal
                Application.Run(new FrmAccueil());
            }
        }

    }
}
