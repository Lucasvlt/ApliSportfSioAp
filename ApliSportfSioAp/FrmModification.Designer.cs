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
        private System.Windows.Forms.CheckedListBox clbSports;
        private System.Windows.Forms.Button btnInserer;
        private System.Windows.Forms.Button btnModifier;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

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
            // 
            // lblNom
            // 
            this.lblNom.Location = new System.Drawing.Point(12, 15);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(100, 23);
            this.lblNom.TabIndex = 17;
            this.lblNom.Text = "Nom :";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(110, 12);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(230, 20);
            this.txtNom.TabIndex = 16;
            // 
            // lblPrenom
            // 
            this.lblPrenom.Location = new System.Drawing.Point(12, 45);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(100, 23);
            this.lblPrenom.TabIndex = 15;
            this.lblPrenom.Text = "Prénom :";
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(110, 42);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(230, 20);
            this.txtPrenom.TabIndex = 14;
            // 
            // lblNaissance
            // 
            this.lblNaissance.Location = new System.Drawing.Point(12, 75);
            this.lblNaissance.Name = "lblNaissance";
            this.lblNaissance.Size = new System.Drawing.Size(100, 23);
            this.lblNaissance.TabIndex = 13;
            this.lblNaissance.Text = "Naissance :";
            // 
            // dtpNaissance
            // 
            this.dtpNaissance.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNaissance.Location = new System.Drawing.Point(110, 72);
            this.dtpNaissance.Name = "dtpNaissance";
            this.dtpNaissance.Size = new System.Drawing.Size(200, 20);
            this.dtpNaissance.TabIndex = 12;
            // 
            // lblRue
            // 
            this.lblRue.Location = new System.Drawing.Point(12, 105);
            this.lblRue.Name = "lblRue";
            this.lblRue.Size = new System.Drawing.Size(100, 23);
            this.lblRue.TabIndex = 11;
            this.lblRue.Text = "Rue :";
            // 
            // txtRue
            // 
            this.txtRue.Location = new System.Drawing.Point(110, 102);
            this.txtRue.Name = "txtRue";
            this.txtRue.Size = new System.Drawing.Size(230, 20);
            this.txtRue.TabIndex = 10;
            // 
            // lblCodePostal
            // 
            this.lblCodePostal.Location = new System.Drawing.Point(12, 135);
            this.lblCodePostal.Name = "lblCodePostal";
            this.lblCodePostal.Size = new System.Drawing.Size(100, 23);
            this.lblCodePostal.TabIndex = 9;
            this.lblCodePostal.Text = "Code Postal :";
            // 
            // txtCodePostal
            // 
            this.txtCodePostal.Location = new System.Drawing.Point(110, 132);
            this.txtCodePostal.Name = "txtCodePostal";
            this.txtCodePostal.Size = new System.Drawing.Size(80, 20);
            this.txtCodePostal.TabIndex = 8;
            // 
            // lblVille
            // 
            this.lblVille.Location = new System.Drawing.Point(12, 165);
            this.lblVille.Name = "lblVille";
            this.lblVille.Size = new System.Drawing.Size(100, 23);
            this.lblVille.TabIndex = 7;
            this.lblVille.Text = "Ville :";
            // 
            // txtVille
            // 
            this.txtVille.Location = new System.Drawing.Point(110, 162);
            this.txtVille.Name = "txtVille";
            this.txtVille.Size = new System.Drawing.Size(230, 20);
            this.txtVille.TabIndex = 6;
            // 
            // lblNiveau
            // 
            this.lblNiveau.Location = new System.Drawing.Point(12, 195);
            this.lblNiveau.Name = "lblNiveau";
            this.lblNiveau.Size = new System.Drawing.Size(100, 23);
            this.lblNiveau.TabIndex = 5;
            this.lblNiveau.Text = "Niveau :";
            // 
            // txtNiveau
            // 
            this.txtNiveau.Location = new System.Drawing.Point(110, 192);
            this.txtNiveau.Name = "txtNiveau";
            this.txtNiveau.Size = new System.Drawing.Size(40, 20);
            this.txtNiveau.TabIndex = 4;
            // 
            // lblSport
            // 
            this.lblSport.Location = new System.Drawing.Point(12, 225);
            this.lblSport.Name = "lblSport";
            this.lblSport.Size = new System.Drawing.Size(100, 23);
            this.lblSport.TabIndex = 3;
            this.lblSport.Text = "Sports pratiqués :";
            // 
            // clbSports
            // 
            this.clbSports.CheckOnClick = true;
            this.clbSports.Location = new System.Drawing.Point(110, 222);
            this.clbSports.Name = "clbSports";
            this.clbSports.Size = new System.Drawing.Size(230, 94);
            this.clbSports.TabIndex = 2;
            // 
            // btnInserer
            // 
            this.btnInserer.Location = new System.Drawing.Point(150, 330);
            this.btnInserer.Name = "btnInserer";
            this.btnInserer.Size = new System.Drawing.Size(75, 23);
            this.btnInserer.TabIndex = 1;
            this.btnInserer.Text = "Ajouter";
            this.btnInserer.Click += new System.EventHandler(this.btnInserer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(150, 330);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(75, 23);
            this.btnModifier.TabIndex = 0;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // FrmModification
            // 
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(360, 380);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnInserer);
            this.Controls.Add(this.clbSports);
            this.Controls.Add(this.lblSport);
            this.Controls.Add(this.txtNiveau);
            this.Controls.Add(this.lblNiveau);
            this.Controls.Add(this.txtVille);
            this.Controls.Add(this.lblVille);
            this.Controls.Add(this.txtCodePostal);
            this.Controls.Add(this.lblCodePostal);
            this.Controls.Add(this.txtRue);
            this.Controls.Add(this.lblRue);
            this.Controls.Add(this.dtpNaissance);
            this.Controls.Add(this.lblNaissance);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.lblPrenom);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lblNom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmModification";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
