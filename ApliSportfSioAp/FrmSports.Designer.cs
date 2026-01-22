namespace ApliSportfSioAp
{
    partial class FrmSports
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvSports;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnRafraichir;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvSports = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnRafraichir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSports)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSports
            // 
            this.dgvSports.AllowUserToAddRows = false;
            this.dgvSports.AllowUserToDeleteRows = false;
            this.dgvSports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNom});
            this.dgvSports.Location = new System.Drawing.Point(12, 12);
            this.dgvSports.MultiSelect = false;
            this.dgvSports.Name = "dgvSports";
            this.dgvSports.ReadOnly = true;
            this.dgvSports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSports.Size = new System.Drawing.Size(460, 300);
            this.dgvSports.TabIndex = 4;
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colNom
            // 
            this.colNom.HeaderText = "Nom";
            this.colNom.Name = "colNom";
            this.colNom.ReadOnly = true;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(12, 320);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(90, 30);
            this.btnAjouter.TabIndex = 3;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(108, 320);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(90, 30);
            this.btnModifier.TabIndex = 2;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(204, 320);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(90, 30);
            this.btnSupprimer.TabIndex = 1;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnRafraichir
            // 
            this.btnRafraichir.Location = new System.Drawing.Point(382, 320);
            this.btnRafraichir.Name = "btnRafraichir";
            this.btnRafraichir.Size = new System.Drawing.Size(90, 30);
            this.btnRafraichir.TabIndex = 0;
            this.btnRafraichir.Text = "Rafraîchir";
            this.btnRafraichir.Click += new System.EventHandler(this.btnRafraichir_Click);
            // 
            // FrmSports
            // 
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.btnRafraichir);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.dgvSports);
            this.Name = "FrmSports";
            this.Text = "Gestion des sports";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSports)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
