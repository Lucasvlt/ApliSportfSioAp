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
            this.btnConnexion1 = new System.Windows.Forms.Button();
            this.btnInscription1 = new System.Windows.Forms.Button();
            this.btnMotDeOublié = new System.Windows.Forms.Button();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.btnChangerMotDePasse = new System.Windows.Forms.Button();
            this.btnCreerCompte = new System.Windows.Forms.Button();
            this.txtNewMotDePasse = new System.Windows.Forms.TextBox();
            this.txtAncienMotDePasse = new System.Windows.Forms.TextBox();
            this.txtNouveauMotDePasse = new System.Windows.Forms.TextBox();
            this.txtNewLogin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConnexion1
            // 
            this.btnConnexion1.Location = new System.Drawing.Point(308, 108);
            this.btnConnexion1.Name = "btnConnexion1";
            this.btnConnexion1.Size = new System.Drawing.Size(75, 29);
            this.btnConnexion1.TabIndex = 0;
            this.btnConnexion1.Text = "Connexion";
            this.btnConnexion1.UseVisualStyleBackColor = true;
            
            // 
            // btnInscription1
            // 
            this.btnInscription1.Location = new System.Drawing.Point(298, 160);
            this.btnInscription1.Name = "btnInscription1";
            this.btnInscription1.Size = new System.Drawing.Size(85, 31);
            this.btnInscription1.TabIndex = 1;
            this.btnInscription1.Text = "Inscription";
            this.btnInscription1.UseVisualStyleBackColor = true;
            // 
            // btnMotDeOublié
            // 
            this.btnMotDeOublié.Location = new System.Drawing.Point(247, 210);
            this.btnMotDeOublié.Name = "btnMotDeOublié";
            this.btnMotDeOublié.Size = new System.Drawing.Size(136, 33);
            this.btnMotDeOublié.TabIndex = 2;
            this.btnMotDeOublié.Text = "Mot de passe oublié";
            this.btnMotDeOublié.UseVisualStyleBackColor = true;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(405, 113);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(100, 20);
            this.txtLogin.TabIndex = 3;
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.Location = new System.Drawing.Point(405, 166);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.Size = new System.Drawing.Size(100, 20);
            this.txtMotDePasse.TabIndex = 4;
            // 
            // btnChangerMotDePasse
            // 
            this.btnChangerMotDePasse.Location = new System.Drawing.Point(247, 276);
            this.btnChangerMotDePasse.Name = "btnChangerMotDePasse";
            this.btnChangerMotDePasse.Size = new System.Drawing.Size(136, 33);
            this.btnChangerMotDePasse.TabIndex = 5;
            this.btnChangerMotDePasse.Text = "Changer de mot de passe";
            this.btnChangerMotDePasse.UseVisualStyleBackColor = true;
            // 
            // btnCreerCompte
            // 
            this.btnCreerCompte.Location = new System.Drawing.Point(452, 276);
            this.btnCreerCompte.Name = "btnCreerCompte";
            this.btnCreerCompte.Size = new System.Drawing.Size(136, 33);
            this.btnCreerCompte.TabIndex = 6;
            this.btnCreerCompte.Text = "Creer un Compte";
            this.btnCreerCompte.UseVisualStyleBackColor = true;
            this.btnCreerCompte.Click += new System.EventHandler(this.btnCreerCompte_Click);
            // 
            // txtNewMotDePasse
            // 
            this.txtNewMotDePasse.Location = new System.Drawing.Point(405, 217);
            this.txtNewMotDePasse.Name = "txtNewMotDePasse";
            this.txtNewMotDePasse.Size = new System.Drawing.Size(100, 20);
            this.txtNewMotDePasse.TabIndex = 7;
            // 
            // txtAncienMotDePasse
            // 
            this.txtAncienMotDePasse.Location = new System.Drawing.Point(263, 340);
            this.txtAncienMotDePasse.Name = "txtAncienMotDePasse";
            this.txtAncienMotDePasse.Size = new System.Drawing.Size(100, 20);
            this.txtAncienMotDePasse.TabIndex = 8;
            // 
            // txtNouveauMotDePasse
            // 
            this.txtNouveauMotDePasse.Location = new System.Drawing.Point(462, 340);
            this.txtNouveauMotDePasse.Name = "txtNouveauMotDePasse";
            this.txtNouveauMotDePasse.Size = new System.Drawing.Size(100, 20);
            this.txtNouveauMotDePasse.TabIndex = 9;
            // 
            // txtNewLogin
            // 
            this.txtNewLogin.Location = new System.Drawing.Point(553, 217);
            this.txtNewLogin.Name = "txtNewLogin";
            this.txtNewLogin.Size = new System.Drawing.Size(100, 20);
            this.txtNewLogin.TabIndex = 10;
            // 
            // FrmConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtNewLogin);
            this.Controls.Add(this.txtNouveauMotDePasse);
            this.Controls.Add(this.txtAncienMotDePasse);
            this.Controls.Add(this.txtNewMotDePasse);
            this.Controls.Add(this.btnCreerCompte);
            this.Controls.Add(this.btnChangerMotDePasse);
            this.Controls.Add(this.txtMotDePasse);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.btnMotDeOublié);
            this.Controls.Add(this.btnInscription1);
            this.Controls.Add(this.btnConnexion1);
            this.Name = "FrmConnexion";
            this.Text = "Connexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnexion1;
        private System.Windows.Forms.Button btnInscription1;
        private System.Windows.Forms.Button btnMotDeOublié;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtMotDePasse;
        private System.Windows.Forms.Button btnChangerMotDePasse;
        private System.Windows.Forms.Button btnCreerCompte;
        private System.Windows.Forms.TextBox txtNewMotDePasse;
        private System.Windows.Forms.TextBox txtAncienMotDePasse;
        private System.Windows.Forms.TextBox txtNouveauMotDePasse;
        private System.Windows.Forms.TextBox txtNewLogin;
    }
}