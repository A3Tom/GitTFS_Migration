using System.Collections.Generic;
using System.Threading.Tasks;
using GitTFS_Migration.Domain.DataModels;
using GitTFS_Migration.Domain.Interfaces;
using GitTFS_Migration.Service.Interfaces;

namespace GitTFS_Migration.Service.Classes
{
    public class App : IApp
    {
        private readonly IGitTFSCommandLibraryFactory _cmdFactory;

        public App(IGitTFSCommandLibraryFactory cmdFactory)
        {
            _cmdFactory = cmdFactory;
        }

        public async Task<bool> MigrateRepositories(IEnumerable<GitMigrationRow> migrationRows)
        {
            List<Task<bool>> repositoriesToMigrate = new List<Task<bool>>();

            foreach (GitMigrationRow row in migrationRows)
            {
                repositoriesToMigrate.Add(GenerateMigrationTask(row));
            }

            bool[] result = await Task.WhenAll(repositoriesToMigrate.ToArray());

            return true;
        }

        private Task<bool> GenerateMigrationTask(GitMigrationRow migrationRow)
        {
            return Task.Run(() =>
            {
                return true;
            });
        }
    }
}
