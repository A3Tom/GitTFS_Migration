using GitTFS_Migration.Domain.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GitTFS_Migration.Service.Interfaces
{
    public interface IApp
    {
        Task MigrateRepositoriesParallelAsync(IEnumerable<GitMigrationRow> migrationRows);
    }
}
