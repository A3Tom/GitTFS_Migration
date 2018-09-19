using GitTFS_Migration.Domain.DataModels;
using GitTFS_Migration.Domain.Enums;
using GitTFS_Migration.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GitTFS_Migration.Domain.Classes
{
    public class ProcessFactory : IProcessFactory
    {
        private const string WORKING_DIRECTORY = @"C:\Migrations\";

        private readonly ICommandLibraryFactory _cmdFactory;

        private Dictionary<GitTFSCommandsEnum, string> _cmdDictionary;

        public ProcessFactory(ICommandLibraryFactory cmdFactory)
        {
            _cmdFactory = cmdFactory;
        }

        public Dictionary<GitTFSCommandsEnum, Process> GenerateProcessDictionary(GitMigrationRow migrationRow)
        {
            var processDictionary = new Dictionary<GitTFSCommandsEnum, Process>();
            _cmdDictionary = _cmdFactory.GenerateGitTFSCommandDictionary(migrationRow);

            foreach (GitTFSCommandsEnum cmd in Enum.GetValues(typeof(GitTFSCommandsEnum)))
            {
                var cmdProcess = GenerateProcess(cmd, migrationRow);
                processDictionary.Add(cmd, cmdProcess);
            }

            return processDictionary;
        }

        private Process GenerateProcess(GitTFSCommandsEnum cmd, GitMigrationRow migrationRow)
        {
            var argument = "/C " + _cmdDictionary[cmd];
            var workingDir = cmd == GitTFSCommandsEnum.CloneFromTFS ?
                WORKING_DIRECTORY : $"{WORKING_DIRECTORY}{migrationRow.BranchName}\\";

            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = workingDir;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = argument;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;

            process.StartInfo = startInfo;

            return process;
        }
    }
}
