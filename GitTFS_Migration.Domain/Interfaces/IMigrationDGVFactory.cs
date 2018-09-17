using GitTFS_Migration.Domain.DataModels;
using System.Collections.Generic;
using System.Data;

namespace GitTFS_Migration.Domain.Interfaces
{
    public interface IMigrationDGVFactory
    {
        DataTable GenerateMigrationDataTableFromList(List<GitMigrationRow> dataSet, DataTable dataTable = null);
    }
}
