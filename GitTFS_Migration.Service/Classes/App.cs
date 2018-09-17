using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using GitTFS_Migration.Domain.DataModels;
using GitTFS_Migration.Domain.Enums;
using GitTFS_Migration.Domain.Interfaces;
using GitTFS_Migration.Service.Interfaces;

namespace GitTFS_Migration.Service.Classes
{
    public class App : IApp
    {
        private readonly ICommandLibraryFactory _cmdFactory;

        private const string WORKING_DIRECTORY = @"C:\Migrations\";

        public App(ICommandLibraryFactory cmdFactory)
        {
            _cmdFactory = cmdFactory;
        }

        public async Task<bool> MigrateRepositories(IEnumerable<GitMigrationRow> migrationRows)
        {
            List<Task<int>> repositoriesToMigrate = new List<Task<int>>();

            if (!Directory.Exists(WORKING_DIRECTORY))
                Directory.CreateDirectory(WORKING_DIRECTORY);

            foreach (GitMigrationRow row in migrationRows)
            {
                repositoriesToMigrate.Add(GenerateMigrationTask(row));
            }

            int[] result = await Task.WhenAll(repositoriesToMigrate.ToArray());

            return true;
        }

        private Task<int> GenerateMigrationTask(GitMigrationRow migrationRow)
        {
            var tcs = new TaskCompletionSource<int>();
            var cmdDictionary = _cmdFactory.GenerateGitTFSCommandDictionary(migrationRow);
            var argument = "/C ";
            argument += cmdDictionary[GitTFSCommandsEnum.CloneFromTFS] + "&";
            argument += cmdDictionary[GitTFSCommandsEnum.ChangeDirectory] + "&";
            argument += cmdDictionary[GitTFSCommandsEnum.AddOriginRemote] + "&";
            argument += cmdDictionary[GitTFSCommandsEnum.GenerateDevelopBranch] + "&";
            argument += cmdDictionary[GitTFSCommandsEnum.PushOriginRemote];

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = WORKING_DIRECTORY;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = argument;
            process.StartInfo = startInfo;
            process.Exited += (sender, args) =>
            {
                tcs.SetResult(process.ExitCode);
                process.Dispose();
            };

            process.Start();

            return tcs.Task;
        }
    }
}
