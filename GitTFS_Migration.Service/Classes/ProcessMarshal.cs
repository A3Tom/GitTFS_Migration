using GitTFS_Migration.Domain.DataModels;
using GitTFS_Migration.Domain.Extensions;
using GitTFS_Migration.Domain.Interfaces;
using GitTFS_Migration.Service.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GitTFS_Migration.Service.Classes
{
    public class ProcessMarshal : IProcessMarshal
    {
        private readonly ILog _logger;
        private readonly IProcessFactory _processFactory;

        public ProcessMarshal(ILog logger,
            IProcessFactory processFactory)
        {
            _logger = logger;
            _processFactory = processFactory;
        }

        public async Task GenerateMigrationTaskAsync(GitMigrationRow row)
        {
            var processDictionaryResult = _processFactory.GenerateProcessDictionary(row);
            row.ProcessDictionary = processDictionaryResult;

            foreach (var proc in row.ProcessDictionary.OrderBy(r => (int)r.Key))
            {
                _logger.Debug($"Beltin out command for {row.BranchName} at Stage: {proc.Key}");
                _logger.Debug($"Slather ma timbers am runnin: {proc.Value.StartInfo.Arguments}");
                Thread.Sleep(50);
                await BeginChildJob(proc.Value);
            }
        }

        private Task BeginChildJob(Process childProcess)
        {
            return Task.Run(async () =>
            {
                childProcess.OutputDataReceived += (sender, args) => _logger.Debug($"{args.Data}");
                childProcess.ErrorDataReceived += (sender, args) => _logger.Error($"{args.Data}");
                childProcess.Start();
                childProcess.BeginOutputReadLine();
                childProcess.BeginErrorReadLine();

                await childProcess.WaitForExitAsync();
            });
        }
    }
}
