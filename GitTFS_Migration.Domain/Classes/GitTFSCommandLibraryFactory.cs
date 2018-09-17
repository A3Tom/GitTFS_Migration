using GitTFS_Migration.Domain.DataModels;
using GitTFS_Migration.Domain.Enums;
using GitTFS_Migration.Domain.Interfaces;
using System.Collections.Generic;

namespace GitTFS_Migration.Domain.Classes
{
    public class GitTFSCommandLibraryFactory : IGitTFSCommandLibraryFactory
    {
        private const string TFS_SERVER = @"http://i-t-v-tf01.amorgroup.local:8080/tfs";

        private Dictionary<GitTFSCommandsEnum, string> _gitTFSCommandKVP;

        public Dictionary<GitTFSCommandsEnum, string> GenerateGitTFSCommandDictionary(GitMigrationRow migrationRow)
        {
            _gitTFSCommandKVP = new Dictionary<GitTFSCommandsEnum, string>
            {
                {
                    GitTFSCommandsEnum.CloneFromTFS,
                    $"git tfs clone {TFS_SERVER} \"{migrationRow.OldTFSRepository}\" {migrationRow.BranchName} --branches=none"
                },

                {
                    GitTFSCommandsEnum.AddOriginRemote,
                    $"git remote add origin {migrationRow.NewGitRepository}"
                },

                {
                    GitTFSCommandsEnum.ChangeDirectory,
                    $"cd {migrationRow.BranchName}"
                },

                {
                    GitTFSCommandsEnum.GenerateDevelopBranch,
                    $"git checkout -b develop"
                },

                {
                    GitTFSCommandsEnum.PushOriginRemote,
                    $"git push -u origin --all"
                }
            };

            return _gitTFSCommandKVP;
        }
    }
}
