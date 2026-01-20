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
        private System.Windows.Forms.ComboBox cbSport;
        private System.Windows.Forms.Button btnInserer;
        private System.Windows.Forms.Button btnModifier;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing"></param>
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
            this.cbSport = new System.Windows.Forms.ComboBox();
            this.btnInserer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Location = new System.Drawing.Point(12, 15);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(29, 13);
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Nom";
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(95, 12);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(250, 20);
            this.txtNom.TabIndex = 1;
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Location = new System.Drawing.Point(12, 45);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(43, 13);
            this.lblPrenom.TabIndex = 2;
            this.lblPrenom.Text = "Prénom";
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(95, 42);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(250, 20);
            this.txtPrenom.TabIndex = 3;
            // 
            // lblNaissance
            // 
            this.lblNaissance.AutoSize = true;
            this.lblNaissance.Location = new System.Drawing.Point(12, 75);
            this.lblNaissance.Name = "lblNaissance";
            this.lblNaissance.Size = new System.Drawing.Size(92, 13);
            this.lblNaissance.TabIndex = 4;
            this.lblNaissance.Text = "Date de naissance";
            // 
            // dtpNaissance
            // 
            this.dtpNaissance.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNaissance.Location = new System.Drawing.Point(110, 72);
            this.dtpNaissance.Name = "dtpNaissance";
            this.dtpNaissance.Size = new System.Drawing.Size(120, 20);
            this.dtpNaissance.TabIndex = 5;
            // 
            // lblRue
            // 
            this.lblRue.AutoSize = true;
            this.lblRue.Location = new System.Drawing.Point(12, 105);
            this.lblRue.Name = "lblRue";
            this.lblRue.Size = new System.Drawing.Size(28, 13);
            this.lblRue.TabIndex = 6;
            this.lblRue.Text = "Rue";
            // 
            // txtRue
            // 
            this.txtRue.Location = new System.Drawing.Point(95, 102);
            this.txtRue.Name = "txtRue";
            this.txtRue.Size = new System.Drawing.Size(250, 20);
            this.txtRue.TabIndex = 7;
            // 
            // lblCodePostal
            // 
            this.lblCodePostal.AutoSize = true;
            this.lblCodePostal.Location = new System.Drawing.Point(12, 135);
            this.lblCodePostal.Name = "lblCodePostal";
            this.lblCodePostal.Size = new System.Drawing.Size(67, 13);
            this.lblCodePostal.TabIndex = 8;
            this.lblCodePostal.Text = "Code postal";
            // 
            // txtCodePostal
            // 
            this.txtCodePostal.Location = new System.Drawing.Point(95, 132);
            this.txtCodePostal.Name = "txtCodePostal";
            this.txtCodePostal.Size = new System.Drawing.Size(120, 20);
            this.txtCodePostal.TabIndex = 9;
            // 
            // lblVille
            // 
            this.lblVille.AutoSize = true;
            this.lblVille.Location = new System.Drawing.Point(12, 165);
            this.lblVille.Name = "lblVille";
            this.lblVille.Size = new System.Drawing.Size(27, 13);
            this.lblVille.TabIndex = 10;
            this.lblVille.Text = "Ville";
            // 
            // txtVille
            // 
            this.txtVille.Location = new System.Drawing.Point(95, 162);
            this.txtVille.Name = "txtVille";
            this.txtVille.Size = new System.Drawing.Size(250, 20);
            this.txtVille.TabIndex = 11;
            // 
            // lblNiveau
            // 
            this.lblNiveau.AutoSize = true;
            this.lblNiveau.Location = new System.Drawing.Point(12, 195);
            this.lblNiveau.Name = "lblNiveau";
            this.lblNiveau.Size = new System.Drawing.Size(41, 13);
            this.lblNiveau.TabIndex = 12;
            this.lblNiveau.Text = "Niveau";
            // 
            // txtNiveau
            // 
            this.txtNiveau.Location = new System.Drawing.Point(95, 192);
            this.txtNiveau.Name = "txtNiveau";
            this.txtNiveau.Size = new System.Drawing.Size(60, 20);
            this.txtNiveau.TabIndex = 13;
            // 
            // lblSport
            // 
            this.lblSport.AutoSize = true;
            this.lblSport.Location = new System.Drawing.Point(12, 225);
            this.lblSport.Name = "lblSport";
            this.lblSport.Size = new System.Drawing.Size(29, 13);
            this.lblSport.TabIndex = 14;
            this.lblSport.Text = "Sport";
            // 
            // cbSport
            // 
            this.cbSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSport.FormattingEnabled = true;
            this.cbSport.Location = new System.Drawing.Point(95, 222);
            this.cbSport.Name = "cbSport";
            this.cbSport.Size = new System.Drawing.Size(250, 21);
            this.cbSport.TabIndex = 15;
            // 
            // btnInserer
            // 
            this.btnInserer.Location = new System.Drawing.Point(95, 260);
            this.btnInserer.Name = "btnInserer";
            this.btnInserer.Size = new System.Drawing.Size(90, 30);
            this.btnInserer.TabIndex = 16;
            this.btnInserer.Text = "Inserer";
            this.btnInserer.UseVisualStyleBackColor = true;
            this.btnInserer.Click += new System.EventHandler(this.btnInserer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(200, 260);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(90, 30);
            this.btnModifier.TabIndex = 17;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // FrmModification
            // 
            this.ClientSize = new System.Drawing.Size(370, 310);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnInserer);
            this.Controls.Add(this.cbSport);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modification / Ajout";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}