using GitTFS_Migration.Domain.DataModels;
using GitTFS_Migration.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitTFS_Migration.Service.Classes
{
    public class App : IApp
    {
        private readonly IProcessMarshal _processMarshal;

        public App(IProcessMarshal processMarshal)
        {
            _processMarshal = processMarshal;
        }

        public async Task MigrateRepositoriesParallelAsync(IEnumerable<GitMigrationRow> migrationRows)
        {
            var tasks = new List<Task>();
            
            foreach (GitMigrationRow row in migrationRows.Where(x => x.EligableForMigration))
            {
                tasks.Add(_processMarshal.GenerateMigrationTaskAsync(row));
            }

            await Task.WhenAll(tasks);
        }
    }
}
