namespace ApliSportfSioAp
{
    partial class FrmModification
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.Label lblNaissance;
        private System.Windows.Forms.DateTimePicker dtpNaissance;
        private System.Windows.Forms.Label lblRue;
        private System.Windows.Forms.TextBox txtRue;
        private System.Windows.Forms.Label lblCodePostal;
        private System.Windows.Forms.TextBox txtCodePostal;
        private System.Windows.Forms.Label lblVille;
        private System.Windows.Forms.TextBox txtVille;
        private System.Windows.Forms.Label lblNiveau;
        private System.Windows.Forms.TextBox txtNiveau;
        private System.Windows.Forms.Label lblSport;
        // CHANGEMENT ICI : CheckedListBox au lieu de ComboBox pour correspondre à ton code C#
        private System.Windows.Forms.CheckedListBox clbSports;
        private System.Windows.Forms.Button btnInserer;
        private System.Windows.Forms.Button btnModifier;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNom = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.lblNaissance = new System.Windows.Forms.Label();
            this.dtpNaissance = new System.Windows.Forms.DateTimePicker();
            this.lblRue = new System.Windows.Forms.Label();
            this.txtRue = new System.Windows.Forms.TextBox();
            this.lblCodePostal = new System.Windows.Forms.Label();
            this.txtCodePostal = new System.Windows.Forms.TextBox();
            this.lblVille = new System.Windows.Forms.Label();
            this.txtVille = new System.Windows.Forms.TextBox();
            this.lblNiveau = new System.Windows.Forms.Label();
            this.txtNiveau = new System.Windows.Forms.TextBox();
            this.lblSport = new System.Windows.Forms.Label();
            this.clbSports = new System.Windows.Forms.CheckedListBox();
            this.btnInserer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Positions et tailles
            this.lblNom.Location = new System.Drawing.Point(12, 15);
            this.lblNom.Text = "Nom :";
            this.txtNom.Location = new System.Drawing.Point(110, 12);
            this.txtNom.Size = new System.Drawing.Size(230, 20);

            this.lblPrenom.Location = new System.Drawing.Point(12, 45);
            this.lblPrenom.Text = "Prénom :";
            this.txtPrenom.Location = new System.Drawing.Point(110, 42);
            this.txtPrenom.Size = new System.Drawing.Size(230, 20);

            this.lblNaissance.Location = new System.Drawing.Point(12, 75);
            this.lblNaissance.Text = "Naissance :";
            this.dtpNaissance.Location = new System.Drawing.Point(110, 72);
            this.dtpNaissance.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblRue.Location = new System.Drawing.Point(12, 105);
            this.lblRue.Text = "Rue :";
            this.txtRue.Location = new System.Drawing.Point(110, 102);
            this.txtRue.Size = new System.Drawing.Size(230, 20);

            this.lblCodePostal.Location = new System.Drawing.Point(12, 135);
            this.lblCodePostal.Text = "Code Postal :";
            this.txtCodePostal.Location = new System.Drawing.Point(110, 132);
            this.txtCodePostal.Size = new System.Drawing.Size(80, 20);

            this.lblVille.Location = new System.Drawing.Point(12, 165);
            this.lblVille.Text = "Ville :";
            this.txtVille.Location = new System.Drawing.Point(110, 162);
            this.txtVille.Size = new System.Drawing.Size(230, 20);

            this.lblNiveau.Location = new System.Drawing.Point(12, 195);
            this.lblNiveau.Text = "Niveau (1-10) :";
            this.txtNiveau.Location = new System.Drawing.Point(110, 192);
            this.txtNiveau.Size = new System.Drawing.Size(40, 20);

            this.lblSport.Location = new System.Drawing.Point(12, 225);
            this.lblSport.Text = "Sports pratiqués :";

            // CheckedListBox config
            this.clbSports.FormattingEnabled = true;
            this.clbSports.Location = new System.Drawing.Point(110, 222);
            this.clbSports.Name = "clbSports";
            this.clbSports.Size = new System.Drawing.Size(230, 94);
            this.clbSports.CheckOnClick = true;

            // Boutons (Superposés ou côte à côte)
            this.btnInserer.Location = new System.Drawing.Point(150, 330);
            this.btnInserer.Text = "Ajouter";
            this.btnInserer.Click += new System.EventHandler(this.btnInserer_Click);

            this.btnModifier.Location = new System.Drawing.Point(150, 330);
            this.btnModifier.Text = "Modifier";
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);

            // Fenêtre
            this.ClientSize = new System.Drawing.Size(360, 380);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnModifier, this.btnInserer, this.clbSports, this.lblSport,
                this.txtNiveau, this.lblNiveau, this.txtVille, this.lblVille,
                this.txtCodePostal, this.lblCodePostal, this.txtRue, this.lblRue,
                this.dtpNaissance, this.lblNaissance, this.txtPrenom, this.lblPrenom,
                this.txtNom, this.lblNom
            });
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Détails Sportif";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}