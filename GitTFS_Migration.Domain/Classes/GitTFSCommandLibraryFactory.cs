using GitTFS_Migration.Domain.Enums;
using GitTFS_Migration.Domain.Interfaces;
using System.Collections.Generic;

namespace GitTFS_Migration.Domain.Classes
{
    public class GitTFSCommandLibraryFactory : IGitTFSCommandLibraryFactory
    {
        private const string TFS_SERVER = @"http://i-t-v-tf01.amorgroup.local:8080/tfs";

        private Dictionary<GitTFSCommandsEnum, string> _gitTFSCommandKVP;

        public Dictionary<GitTFSCommandsEnum, string> GenerateGitTFSCommandDictionary(string tfsRepositoryPath, string gitRepositoryPath)
        {
            _gitTFSCommandKVP = new Dictionary<GitTFSCommandsEnum, string>();

            _gitTFSCommandKVP.Add(
                GitTFSCommandsEnum.CloneFromTFS,
                $"git tfs clone {TFS_SERVER} \"{tfsRepositoryPath}\" --branches=none"
            );
            _gitTFSCommandKVP.Add(
                GitTFSCommandsEnum.AddOriginRemote,
                $"git remote add origin {gitRepositoryPath}"
            );

            _gitTFSCommandKVP.Add(
                GitTFSCommandsEnum.GenerateDevelopBranch, 
                $"git checkout -b develop"
            );

            _gitTFSCommandKVP.Add(
                GitTFSCommandsEnum.PushOriginRemote, 
                $"git push -u origin --all"
            );

            return _gitTFSCommandKVP;
        }
    }
}
