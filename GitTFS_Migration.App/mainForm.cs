using GitTFS_Migration.Domain.DataModels;
using GitTFS_Migration.Domain.Interfaces;
using GitTFS_Migration.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GitTFS_Migration.Application
{
    public partial class MainForm : Form
    {
        private readonly IApp _app;
        private readonly IFileSelector _fileSelector;
        private readonly IFileReader _fileReader;
        private readonly IMigrationDGVFactory _migrationDGVFactory;

        private string _csvFileLocation;
        private DataTable _dataTable = null;
        private List<GitMigrationRow> _dataSet = null;

        public MainForm(IApp app,
            IFileSelector fileSelector,
            IFileReader fileReader,
            IMigrationDGVFactory migrationDGVFactory)
        {
            _app = app;
            _fileSelector = fileSelector;
            _fileReader = fileReader;
            _migrationDGVFactory = migrationDGVFactory;

            InitializeComponent();
        }

        private void btn_SelectCSV_Click(object sender, EventArgs e)
        {
            _csvFileLocation = _fileSelector.SelectFile(ofd_Migrations);
            txt_CSVLocation.Text = _csvFileLocation;

            _dataSet = _fileReader.ParseCSVToList(_csvFileLocation);
            _dataTable = _migrationDGVFactory.GenerateMigrationDataTableFromList(_dataSet, _dataTable);

            dgv_Repos.DataSource = _dataTable;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            dgv_Repos.DataSource = null;
        }

        private void btn_Migrate_Click(object sender, EventArgs e)
        {
            bool result = _app.MigrateRepositories(_dataSet).Result;
        }
    }
}
