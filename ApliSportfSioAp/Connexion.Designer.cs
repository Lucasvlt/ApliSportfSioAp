namespace ApliSportfSioAp
{
    partial class FrmConnexion
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblMotDePasse;
        private System.Windows.Forms.TextBox txtMotDePasse;
        private System.Windows.Forms.Button btnConnexion;
        private System.Windows.Forms.Button btnInscription;
        private System.Windows.Forms.Button btnMdPOublie;
        private System.Windows.Forms.Panel panelMotDePasseOublie;
        private System.Windows.Forms.Label lblNouveau;
        private System.Windows.Forms.TextBox txtNouveauMotDePasse;
        private System.Windows.Forms.Label lblConfirmer;
        private System.Windows.Forms.TextBox txtConfirmerMotDePasse;
        private System.Windows.Forms.Button btnValiderMotDePasse;

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
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblMotDePasse = new System.Windows.Forms.Label();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.btnInscription = new System.Windows.Forms.Button();
            this.btnMdPOublie = new System.Windows.Forms.Button();
            this.panelMotDePasseOublie = new System.Windows.Forms.Panel();
            this.lblNouveau = new System.Windows.Forms.Label();
            this.txtNouveauMotDePasse = new System.Windows.Forms.TextBox();
            this.lblConfirmer = new System.Windows.Forms.Label();
            this.txtConfirmerMotDePasse = new System.Windows.Forms.TextBox();
            this.btnValiderMotDePasse = new System.Windows.Forms.Button();
            this.panelMotDePasseOublie.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitre.Location = new System.Drawing.Point(12, 9);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(360, 25);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Connexion";
            this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(20, 50);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(33, 13);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Login";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(120, 47);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(240, 20);
            this.txtLogin.TabIndex = 2;
            this.txtLogin.TextChanged += new System.EventHandler(this.txtLogin_TextChanged);
            // 
            // lblMotDePasse
            // 
            this.lblMotDePasse.AutoSize = true;
            this.lblMotDePasse.Location = new System.Drawing.Point(20, 85);
            this.lblMotDePasse.Name = "lblMotDePasse";
            this.lblMotDePasse.Size = new System.Drawing.Size(71, 13);
            this.lblMotDePasse.TabIndex = 3;
            this.lblMotDePasse.Text = "Mot de passe";
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.Location = new System.Drawing.Point(120, 82);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.PasswordChar = '*';
            this.txtMotDePasse.Size = new System.Drawing.Size(240, 20);
            this.txtMotDePasse.TabIndex = 4;
            // 
            // btnConnexion
            // 
            this.btnConnexion.Location = new System.Drawing.Point(151, 115);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(90, 28);
            this.btnConnexion.TabIndex = 5;
            this.btnConnexion.Text = "Se connecter";
            this.btnConnexion.UseVisualStyleBackColor = true;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // btnInscription
            // 
            this.btnInscription.Location = new System.Drawing.Point(270, 115);
            this.btnInscription.Name = "btnInscription";
            this.btnInscription.Size = new System.Drawing.Size(90, 28);
            this.btnInscription.TabIndex = 6;
            this.btnInscription.Text = "S\'inscrire";
            this.btnInscription.UseVisualStyleBackColor = true;
            this.btnInscription.Click += new System.EventHandler(this.btnInscription_Click);
            // 
            // btnMdPOublie
            // 
            this.btnMdPOublie.Location = new System.Drawing.Point(12, 115);
            this.btnMdPOublie.Name = "btnMdPOublie";
            this.btnMdPOublie.Size = new System.Drawing.Size(128, 28);
            this.btnMdPOublie.TabIndex = 7;
            this.btnMdPOublie.Text = "Oublie du mot de passe";
            this.btnMdPOublie.UseVisualStyleBackColor = true;
            this.btnMdPOublie.Click += new System.EventHandler(this.btnMdPOublie_Click);
            // 
            // panelMotDePasseOublie
            // 
            this.panelMotDePasseOublie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMotDePasseOublie.Controls.Add(this.lblNouveau);
            this.panelMotDePasseOublie.Controls.Add(this.txtNouveauMotDePasse);
            this.panelMotDePasseOublie.Controls.Add(this.lblConfirmer);
            this.panelMotDePasseOublie.Controls.Add(this.txtConfirmerMotDePasse);
            this.panelMotDePasseOublie.Controls.Add(this.btnValiderMotDePasse);
            this.panelMotDePasseOublie.Location = new System.Drawing.Point(20, 155);
            this.panelMotDePasseOublie.Name = "panelMotDePasseOublie";
            this.panelMotDePasseOublie.Size = new System.Drawing.Size(340, 120);
            this.panelMotDePasseOublie.TabIndex = 8;
            this.panelMotDePasseOublie.Visible = false;
            // 
            // lblNouveau
            // 
            this.lblNouveau.AutoSize = true;
            this.lblNouveau.Location = new System.Drawing.Point(10, 10);
            this.lblNouveau.Name = "lblNouveau";
            this.lblNouveau.Size = new System.Drawing.Size(117, 13);
            this.lblNouveau.TabIndex = 0;
            this.lblNouveau.Text = "Nouveau mot de passe";
            // 
            // txtNouveauMotDePasse
            // 
            this.txtNouveauMotDePasse.Location = new System.Drawing.Point(130, 7);
            this.txtNouveauMotDePasse.Name = "txtNouveauMotDePasse";
            this.txtNouveauMotDePasse.PasswordChar = '*';
            this.txtNouveauMotDePasse.Size = new System.Drawing.Size(190, 20);
            this.txtNouveauMotDePasse.TabIndex = 1;
            // 
            // lblConfirmer
            // 
            this.lblConfirmer.AutoSize = true;
            this.lblConfirmer.Location = new System.Drawing.Point(10, 45);
            this.lblConfirmer.Name = "lblConfirmer";
            this.lblConfirmer.Size = new System.Drawing.Size(51, 13);
            this.lblConfirmer.TabIndex = 2;
            this.lblConfirmer.Text = "Confirmer";
            // 
            // txtConfirmerMotDePasse
            // 
            this.txtConfirmerMotDePasse.Location = new System.Drawing.Point(130, 42);
            this.txtConfirmerMotDePasse.Name = "txtConfirmerMotDePasse";
            this.txtConfirmerMotDePasse.PasswordChar = '*';
            this.txtConfirmerMotDePasse.Size = new System.Drawing.Size(190, 20);
            this.txtConfirmerMotDePasse.TabIndex = 3;
            // 
            // btnValiderMotDePasse
            // 
            this.btnValiderMotDePasse.Location = new System.Drawing.Point(220, 75);
            this.btnValiderMotDePasse.Name = "btnValiderMotDePasse";
            this.btnValiderMotDePasse.Size = new System.Drawing.Size(100, 28);
            this.btnValiderMotDePasse.TabIndex = 4;
            this.btnValiderMotDePasse.Text = "Valider";
            this.btnValiderMotDePasse.UseVisualStyleBackColor = true;
            this.btnValiderMotDePasse.Click += new System.EventHandler(this.btnValiderMotDePasse_Click);
            // 
            // FrmConnexion
            // 
            this.ClientSize = new System.Drawing.Size(443, 293);
            this.Controls.Add(this.panelMotDePasseOublie);
            this.Controls.Add(this.btnMdPOublie);
            this.Controls.Add(this.btnInscription);
            this.Controls.Add(this.btnConnexion);
            this.Controls.Add(this.txtMotDePasse);
            this.Controls.Add(this.lblMotDePasse);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblTitre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmConnexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connexion";
            this.panelMotDePasseOublie.ResumeLayout(false);
            this.panelMotDePasseOublie.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}