namespace GitTFS_Migration.Application
{
    partial class MainForm
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
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Migrate = new System.Windows.Forms.Button();
            this.ofd_Migrations = new System.Windows.Forms.OpenFileDialog();
            this.dgv_Repos = new System.Windows.Forms.DataGridView();
            this.col_BranchName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_OldTFSRepo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_chkOldRepoReady = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_NewGitRepo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_chkNewRepoReady = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txt_CSVLocation = new System.Windows.Forms.TextBox();
            this.btn_SelectCSV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Repos)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(12, 248);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(64, 23);
            this.btn_Clear.TabIndex = 0;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            // 
            // btn_Migrate
            // 
            this.btn_Migrate.Location = new System.Drawing.Point(677, 248);
            this.btn_Migrate.Name = "btn_Migrate";
            this.btn_Migrate.Size = new System.Drawing.Size(188, 23);
            this.btn_Migrate.TabIndex = 1;
            this.btn_Migrate.Text = "Migrate";
            this.btn_Migrate.UseVisualStyleBackColor = true;
            // 
            // ofd_Migrations
            // 
            this.ofd_Migrations.FileName = "openFileDialog1";
            // 
            // dgv_Repos
            // 
            this.dgv_Repos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Repos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_BranchName,
            this.col_OldTFSRepo,
            this.col_chkOldRepoReady,
            this.col_NewGitRepo,
            this.col_chkNewRepoReady});
            this.dgv_Repos.Location = new System.Drawing.Point(12, 92);
            this.dgv_Repos.Name = "dgv_Repos";
            this.dgv_Repos.RowHeadersVisible = false;
            this.dgv_Repos.Size = new System.Drawing.Size(853, 150);
            this.dgv_Repos.TabIndex = 2;
            // 
            // col_BranchName
            // 
            this.col_BranchName.FillWeight = 30F;
            this.col_BranchName.HeaderText = "Branch name";
            this.col_BranchName.Name = "col_BranchName";
            this.col_BranchName.ReadOnly = true;
            this.col_BranchName.Width = 150;
            // 
            // col_OldTFSRepo
            // 
            this.col_OldTFSRepo.FillWeight = 30F;
            this.col_OldTFSRepo.HeaderText = "Old TFS Repo";
            this.col_OldTFSRepo.Name = "col_OldTFSRepo";
            this.col_OldTFSRepo.ReadOnly = true;
            this.col_OldTFSRepo.Width = 300;
            // 
            // col_chkOldRepoReady
            // 
            this.col_chkOldRepoReady.FillWeight = 5F;
            this.col_chkOldRepoReady.HeaderText = "Ready";
            this.col_chkOldRepoReady.Name = "col_chkOldRepoReady";
            this.col_chkOldRepoReady.ReadOnly = true;
            this.col_chkOldRepoReady.Width = 50;
            // 
            // col_NewGitRepo
            // 
            this.col_NewGitRepo.FillWeight = 30F;
            this.col_NewGitRepo.HeaderText = "New Git Repo";
            this.col_NewGitRepo.Name = "col_NewGitRepo";
            this.col_NewGitRepo.ReadOnly = true;
            this.col_NewGitRepo.Width = 300;
            // 
            // col_chkNewRepoReady
            // 
            this.col_chkNewRepoReady.FillWeight = 5F;
            this.col_chkNewRepoReady.HeaderText = "Ready";
            this.col_chkNewRepoReady.Name = "col_chkNewRepoReady";
            this.col_chkNewRepoReady.ReadOnly = true;
            this.col_chkNewRepoReady.Width = 50;
            // 
            // txt_CSVLocation
            // 
            this.txt_CSVLocation.Location = new System.Drawing.Point(12, 65);
            this.txt_CSVLocation.Name = "txt_CSVLocation";
            this.txt_CSVLocation.Size = new System.Drawing.Size(751, 20);
            this.txt_CSVLocation.TabIndex = 3;
            // 
            // btn_SelectCSV
            // 
            this.btn_SelectCSV.Location = new System.Drawing.Point(769, 63);
            this.btn_SelectCSV.Name = "btn_SelectCSV";
            this.btn_SelectCSV.Size = new System.Drawing.Size(96, 23);
            this.btn_SelectCSV.TabIndex = 4;
            this.btn_SelectCSV.Text = "Select CSV";
            this.btn_SelectCSV.UseVisualStyleBackColor = true;
            this.btn_SelectCSV.Click += new System.EventHandler(this.btn_SelectCSV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Git TFS Migration Tool";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 278);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_SelectCSV);
            this.Controls.Add(this.txt_CSVLocation);
            this.Controls.Add(this.dgv_Repos);
            this.Controls.Add(this.btn_Migrate);
            this.Controls.Add(this.btn_Clear);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Repos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Migrate;
        private System.Windows.Forms.OpenFileDialog ofd_Migrations;
        private System.Windows.Forms.DataGridView dgv_Repos;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_BranchName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_OldTFSRepo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_chkOldRepoReady;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NewGitRepo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_chkNewRepoReady;
        private System.Windows.Forms.TextBox txt_CSVLocation;
        private System.Windows.Forms.Button btn_SelectCSV;
        private System.Windows.Forms.Label label1;
    }
}

