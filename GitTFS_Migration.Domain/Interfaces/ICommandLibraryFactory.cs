using GitTFS_Migration.Domain.DataModels;
using GitTFS_Migration.Domain.Enums;
using System.Collections.Generic;

namespace GitTFS_Migration.Domain.Interfaces
{
    public interface ICommandLibraryFactory
    {
        Dictionary<GitTFSCommandsEnum, string> GenerateGitTFSCommandDictionary(GitMigrationRow migrationRow);
    }
}
