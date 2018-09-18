using GitTFS_Migration.Domain.DataModels;
using System.Collections.Generic;

namespace GitTFS_Migration.Service.Interfaces
{
    public interface IApp
    {
        bool MigrateRepositories(IEnumerable<GitMigrationRow> migrationRows);
    }
}
