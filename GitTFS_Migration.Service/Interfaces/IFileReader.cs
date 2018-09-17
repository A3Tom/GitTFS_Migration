using System.Data;

namespace GitTFS_Migration.Service.Interfaces
{
    public interface IFileReader
    {
        DataTable ParseCSVToDataTable(string filePath, DataColumn[] dataColumns = null);
    }
}
