using System.Data;

namespace GitTFS_Migration.Domain.Interfaces
{
    public interface IMigrationDGVFactory
    {
        DataColumn[] GenerateMigrationHeaderRow();
    }
}
