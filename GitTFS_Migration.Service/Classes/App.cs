using GitTFS_Migration.Domain.DataModels;
using GitTFS_Migration.Domain.Enums;
using GitTFS_Migration.Domain.Interfaces;
using GitTFS_Migration.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GitTFS_Migration.Service.Classes
{
    public class App : IApp
    {
        private readonly IProcessFactory _processFactory;

        public App(IProcessFactory processFactory)
        {
            _processFactory = processFactory;
        }

        public bool MigrateRepositories(IEnumerable<GitMigrationRow> migrationRows)
        {
            var result = new List<Dictionary<GitTFSCommandsEnum, bool>>();
            var procs = new List<Process>(); 

            foreach (GitMigrationRow row in migrationRows.Where(x => x.EligableForMigration))
            {
                var procDict = new Dictionary<GitTFSCommandsEnum, bool>();

                var processDictionaryResult = _processFactory.GenerateProcessDictionary(row);
                row.ProcessDictionary = processDictionaryResult;

                foreach (var proc in row.ProcessDictionary)
                {
                    proc.Value.Start();

                    Console.WriteLine(proc.Value.StandardOutput.ReadToEnd());

                    procDict.Add(proc.Key, true);
                }

                result.Add(procDict);
            }

            return result.All(x => x.All(d => d.Value == true));
        }

        private async Task<int> RunProcessTask(Process process)
        {
            return await Task.Run(() => {
                var tcs = new TaskCompletionSource<int>();

                process.Exited += (sender, args) =>
                {
                    tcs.SetResult(process.ExitCode);
                    process.Dispose();
                };

                if (!Directory.Exists(process.StartInfo.WorkingDirectory))
                    process.Kill();

                return tcs.Task;
            });
        }
    }
}
