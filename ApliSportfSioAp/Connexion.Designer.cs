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
            this.btnConnexion = new System.Windows.Forms.Button();
            this.labelLogin = new System.Windows.Forms.Label();
            this.btnMdPOublie = new System.Windows.Forms.Button();
            this.labelMotDePasse = new System.Windows.Forms.Label();
            this.txtNouveauMotDePasse = new System.Windows.Forms.TextBox();
            this.txtConfirmerMotDePasse = new System.Windows.Forms.TextBox();
            this.lblNouveau = new System.Windows.Forms.Label();
            this.lblConfirmer = new System.Windows.Forms.Label();
            this.btnValiderMotDePasse = new System.Windows.Forms.Button();
            this.btnInscription = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(176, 138);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(100, 20);
            this.txtLogin.TabIndex = 3;
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.Location = new System.Drawing.Point(174, 239);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.Size = new System.Drawing.Size(119, 20);
            this.txtMotDePasse.TabIndex = 4;
            // 
            // btnConnexion
            // 
            this.btnConnexion.Location = new System.Drawing.Point(174, 279);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(136, 33);
            this.btnConnexion.TabIndex = 6;
            this.btnConnexion.Text = "Connexion";
            this.btnConnexion.UseVisualStyleBackColor = true;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogin.Location = new System.Drawing.Point(170, 111);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(62, 24);
            this.labelLogin.TabIndex = 11;
            this.labelLogin.Text = "Login";
            // 
            // btnMdPOublie
            // 
            this.btnMdPOublie.Location = new System.Drawing.Point(174, 213);
            this.btnMdPOublie.Name = "btnMdPOublie";
            this.btnMdPOublie.Size = new System.Drawing.Size(127, 20);
            this.btnMdPOublie.TabIndex = 12;
            this.btnMdPOublie.Text = "Mot de Passe Oublié";
            this.btnMdPOublie.UseVisualStyleBackColor = true;
            this.btnMdPOublie.Click += new System.EventHandler(this.btnMdPOublie_Click);
            // 
            // labelMotDePasse
            // 
            this.labelMotDePasse.AutoSize = true;
            this.labelMotDePasse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMotDePasse.Location = new System.Drawing.Point(173, 194);
            this.labelMotDePasse.Name = "labelMotDePasse";
            this.labelMotDePasse.Size = new System.Drawing.Size(101, 16);
            this.labelMotDePasse.TabIndex = 15;
            this.labelMotDePasse.Text = "Mot de passe";
            // 
            // txtNouveauMotDePasse
            // 
            this.txtNouveauMotDePasse.Location = new System.Drawing.Point(661, 82);
            this.txtNouveauMotDePasse.Name = "txtNouveauMotDePasse";
            this.txtNouveauMotDePasse.Size = new System.Drawing.Size(119, 20);
            this.txtNouveauMotDePasse.TabIndex = 16;
            this.txtNouveauMotDePasse.Visible = false;
            // 
            // txtConfirmerMotDePasse
            // 
            this.txtConfirmerMotDePasse.Location = new System.Drawing.Point(661, 149);
            this.txtConfirmerMotDePasse.Name = "txtConfirmerMotDePasse";
            this.txtConfirmerMotDePasse.Size = new System.Drawing.Size(119, 20);
            this.txtConfirmerMotDePasse.TabIndex = 17;
            this.txtConfirmerMotDePasse.Visible = false;
            // 
            // lblNouveau
            // 
            this.lblNouveau.AutoSize = true;
            this.lblNouveau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNouveau.Location = new System.Drawing.Point(459, 86);
            this.lblNouveau.Name = "lblNouveau";
            this.lblNouveau.Size = new System.Drawing.Size(171, 16);
            this.lblNouveau.TabIndex = 18;
            this.lblNouveau.Text = "Nouveau mot de passe ";
            this.lblNouveau.Visible = false;
            // 
            // lblConfirmer
            // 
            this.lblConfirmer.AutoSize = true;
            this.lblConfirmer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmer.Location = new System.Drawing.Point(459, 149);
            this.lblConfirmer.Name = "lblConfirmer";
            this.lblConfirmer.Size = new System.Drawing.Size(188, 16);
            this.lblConfirmer.TabIndex = 19;
            this.lblConfirmer.Text = "Confirmer le mot de passe";
            this.lblConfirmer.Visible = false;
            // 
            // btnValiderMotDePasse
            // 
            this.btnValiderMotDePasse.Location = new System.Drawing.Point(647, 388);
            this.btnValiderMotDePasse.Name = "btnValiderMotDePasse";
            this.btnValiderMotDePasse.Size = new System.Drawing.Size(110, 30);
            this.btnValiderMotDePasse.TabIndex = 20;
            this.btnValiderMotDePasse.Text = "Valider";
            this.btnValiderMotDePasse.UseVisualStyleBackColor = true;
            this.btnValiderMotDePasse.Visible = false;
            this.btnValiderMotDePasse.Click += new System.EventHandler(this.btnValiderMotDePasse_Click);
            // 
            // btnInscription
            // 
            this.btnInscription.Location = new System.Drawing.Point(174, 12);
            this.btnInscription.Name = "btnInscription";
            this.btnInscription.Size = new System.Drawing.Size(194, 70);
            this.btnInscription.TabIndex = 21;
            this.btnInscription.Text = "S\'inscrire";
            this.btnInscription.UseVisualStyleBackColor = true;
            this.btnInscription.Click += new System.EventHandler(this.btnInscription_Click);
            // 
            // FrmConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnInscription);
            this.Controls.Add(this.btnValiderMotDePasse);
            this.Controls.Add(this.lblConfirmer);
            this.Controls.Add(this.lblNouveau);
            this.Controls.Add(this.txtConfirmerMotDePasse);
            this.Controls.Add(this.txtNouveauMotDePasse);
            this.Controls.Add(this.labelMotDePasse);
            this.Controls.Add(this.btnMdPOublie);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.btnConnexion);
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
        private System.Windows.Forms.Button btnConnexion;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Button btnMdPOublie;
        private System.Windows.Forms.Label labelMotDePasse;
        private System.Windows.Forms.TextBox txtNouveauMotDePasse;
        private System.Windows.Forms.TextBox txtConfirmerMotDePasse;
        private System.Windows.Forms.Label lblNouveau;
        private System.Windows.Forms.Label lblConfirmer;
        private System.Windows.Forms.Button btnValiderMotDePasse;
        private System.Windows.Forms.Button btnInscription;
    }
}