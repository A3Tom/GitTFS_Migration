using GitTFS_Migration.Domain.DataModels;
using GitTFS_Migration.Domain.Interfaces;
using GitTFS_Migration.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
            dgv_Repos.ReadOnly = true;
        }

        private void btn_SelectCSV_Click(object sender, EventArgs e)
        {
            _csvFileLocation = _fileSelector.SelectFile(ofd_Migrations);
            txt_CSVLocation.Text = _csvFileLocation;

            _dataSet = _fileReader.ParseCSVToList(_csvFileLocation);
            _dataTable = _migrationDGVFactory.GenerateMigrationDataTableFromList(_dataSet, _dataTable);

            dgv_Repos.DataSource = _dataTable;
            dgv_Repos.AutoResizeColumns();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            dgv_Repos.DataSource = null;
        }

        private async void btn_Migrate_Click(object sender, EventArgs e)
        {
            var result = false;

            try
            {
                await _app.MigrateRepositoriesParallelAsync(_dataSet);
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show($"Hath one went baws oot? {result}");
            }
        }
    }
}
