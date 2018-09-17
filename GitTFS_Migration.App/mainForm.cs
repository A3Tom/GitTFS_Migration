using GitTFS_Migration.Service.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GitTFS_Migration.Application
{
    public partial class MainForm : Form
    {
        private readonly IFileSelector _fileSelector;
        private readonly IFileReader _fileReader;

        private DataColumn[] _dataColumns = null;
        private string _csvFileLocation;

        public MainForm(IFileSelector fileSelector,
            IFileReader fileReader)
        {
            _fileSelector = fileSelector;
            _fileReader = fileReader;
            InitializeComponent();

            _dataColumns = dgv_Repos.Columns
                .Cast<DataGridViewColumn>()
                .Select(x => new DataColumn(x.Name))
                .ToArray();
        }

        private void btn_SelectCSV_Click(object sender, EventArgs e)
        {
            _csvFileLocation = _fileSelector.SelectFile(ofd_Migrations);
            txt_CSVLocation.Text = _csvFileLocation;

            var dt = _fileReader.ParseCSVToDataTable(_csvFileLocation, _dataColumns);
            dgv_Repos.DataSource = dt;
        }
    }
}
