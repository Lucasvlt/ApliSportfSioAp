namespace ApliSportfSioAp
{
    partial class FrmConnexion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.btnCreerCompte = new System.Windows.Forms.Button();
            this.labelUtilisateur = new System.Windows.Forms.Label();
            this.btnMdPOublie = new System.Windows.Forms.Button();
            this.txtNouveauMotDePasse = new System.Windows.Forms.TextBox();
            this.btnValiderReinitialisation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(318, 111);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(100, 20);
            this.txtLogin.TabIndex = 3;
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.Location = new System.Drawing.Point(318, 165);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.Size = new System.Drawing.Size(100, 20);
            this.txtMotDePasse.TabIndex = 4;
            // 
            // btnCreerCompte
            // 
            this.btnCreerCompte.Location = new System.Drawing.Point(307, 226);
            this.btnCreerCompte.Name = "btnCreerCompte";
            this.btnCreerCompte.Size = new System.Drawing.Size(136, 33);
            this.btnCreerCompte.TabIndex = 6;
            this.btnCreerCompte.Text = "Creer un Compte";
            this.btnCreerCompte.UseVisualStyleBackColor = true;
            this.btnCreerCompte.Click += new System.EventHandler(this.btnCreerCompte_Click);
            // 
            // labelUtilisateur
            // 
            this.labelUtilisateur.AutoSize = true;
            this.labelUtilisateur.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUtilisateur.Location = new System.Drawing.Point(314, 60);
            this.labelUtilisateur.Name = "labelUtilisateur";
            this.labelUtilisateur.Size = new System.Drawing.Size(101, 24);
            this.labelUtilisateur.TabIndex = 11;
            this.labelUtilisateur.Text = "Utilisateur";
            // 
            // btnMdPOublie
            // 
            this.btnMdPOublie.Location = new System.Drawing.Point(528, 104);
            this.btnMdPOublie.Name = "btnMdPOublie";
            this.btnMdPOublie.Size = new System.Drawing.Size(136, 33);
            this.btnMdPOublie.TabIndex = 12;
            this.btnMdPOublie.Text = "Mot de Passe Oublié";
            this.btnMdPOublie.UseVisualStyleBackColor = true;
            // 
            // txtNouveauMotDePasse
            // 
            this.txtNouveauMotDePasse.Location = new System.Drawing.Point(528, 353);
            this.txtNouveauMotDePasse.Name = "txtNouveauMotDePasse";
            this.txtNouveauMotDePasse.Size = new System.Drawing.Size(100, 20);
            this.txtNouveauMotDePasse.TabIndex = 13;
            this.txtNouveauMotDePasse.Visible = false;
            // 
            // btnValiderReinitialisation
            // 
            this.btnValiderReinitialisation.Location = new System.Drawing.Point(528, 298);
            this.btnValiderReinitialisation.Name = "btnValiderReinitialisation";
            this.btnValiderReinitialisation.Size = new System.Drawing.Size(173, 23);
            this.btnValiderReinitialisation.TabIndex = 14;
            this.btnValiderReinitialisation.Text = "Valider Reinitialisation ";
            this.btnValiderReinitialisation.UseVisualStyleBackColor = true;
            this.btnValiderReinitialisation.Click += new System.EventHandler(this.btnValiderReinitialisation_Click);
            // 
            // FrmConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnValiderReinitialisation);
            this.Controls.Add(this.txtNouveauMotDePasse);
            this.Controls.Add(this.btnMdPOublie);
            this.Controls.Add(this.labelUtilisateur);
            this.Controls.Add(this.btnCreerCompte);
            this.Controls.Add(this.txtMotDePasse);
            this.Controls.Add(this.txtLogin);
            this.Name = "FrmConnexion";
            this.Text = "Connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtMotDePasse;
        private System.Windows.Forms.Button btnCreerCompte;
        private System.Windows.Forms.Label labelUtilisateur;
        private System.Windows.Forms.Button btnMdPOublie;
        private System.Windows.Forms.TextBox txtNouveauMotDePasse;
        private System.Windows.Forms.Button btnValiderReinitialisation;
    }
}