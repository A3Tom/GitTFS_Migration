using GitTFS_Migration.Domain.Interfaces;
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

        private DataTable _dataTable = null;
        
        private string _csvFileLocation;

        public MainForm(IFileSelector fileSelector,
            IFileReader fileReader)
        {
            _fileSelector = fileSelector;
            _fileReader = fileReader;

            InitializeComponent();
        }

        private void btn_SelectCSV_Click(object sender, EventArgs e)
        {
            _csvFileLocation = _fileSelector.SelectFile(ofd_Migrations);
            txt_CSVLocation.Text = _csvFileLocation;

            _dataTable = _fileReader.ParseCSVToDataTable(_csvFileLocation, _dataTable);
            dgv_Repos.DataSource = _dataTable;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            dgv_Repos.DataSource = null;
        }
    }
}
