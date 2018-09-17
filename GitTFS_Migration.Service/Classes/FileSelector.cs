using GitTFS_Migration.Service.Interfaces;
using System.IO;
using System.Windows.Forms;

namespace GitTFS_Migration.Service.Classes
{
    public class FileSelector : IFileSelector
    {
        public string SelectFile(OpenFileDialog openFileDialog)
        {
            Stream fileStream = null;
            string fileName = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK && 
                (fileStream = openFileDialog.OpenFile()) != null)
            {
                fileName = openFileDialog.FileName;
            }
            else
            {
                fileName = "Error selecting file";
            }

            fileStream.Close();
            fileStream.Dispose();

            return fileName;
        }
    }
}
