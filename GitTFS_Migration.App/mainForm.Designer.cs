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
            this.txt_CSVLocation = new System.Windows.Forms.TextBox();
            this.btn_SelectCSV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Repos)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(12, 438);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(64, 23);
            this.btn_Clear.TabIndex = 0;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Migrate
            // 
            this.btn_Migrate.Location = new System.Drawing.Point(677, 438);
            this.btn_Migrate.Name = "btn_Migrate";
            this.btn_Migrate.Size = new System.Drawing.Size(188, 23);
            this.btn_Migrate.TabIndex = 1;
            this.btn_Migrate.Text = "Migrate";
            this.btn_Migrate.UseVisualStyleBackColor = true;
            this.btn_Migrate.Click += new System.EventHandler(this.btn_Migrate_Click);
            // 
            // ofd_Migrations
            // 
            this.ofd_Migrations.FileName = "openFileDialog1";
            // 
            // dgv_Repos
            // 
            this.dgv_Repos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Repos.Location = new System.Drawing.Point(12, 92);
            this.dgv_Repos.Name = "dgv_Repos";
            this.dgv_Repos.RowHeadersVisible = false;
            this.dgv_Repos.Size = new System.Drawing.Size(853, 340);
            this.dgv_Repos.TabIndex = 2;
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
            this.ClientSize = new System.Drawing.Size(882, 473);
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
        private System.Windows.Forms.TextBox txt_CSVLocation;
        private System.Windows.Forms.Button btn_SelectCSV;
        private System.Windows.Forms.Label label1;
    }
}

