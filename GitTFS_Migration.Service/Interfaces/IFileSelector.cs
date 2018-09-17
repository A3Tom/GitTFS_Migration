using System.Windows.Forms;

namespace GitTFS_Migration.Service.Interfaces
{
    public interface IFileSelector
    {
        string SelectFile(OpenFileDialog openFileDialog);
    }
}
