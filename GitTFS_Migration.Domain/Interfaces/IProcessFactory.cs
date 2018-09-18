using GitTFS_Migration.Domain.DataModels;
using GitTFS_Migration.Domain.Enums;
using System.Collections.Generic;
using System.Diagnostics;

namespace GitTFS_Migration.Domain.Interfaces
{
    public interface IProcessFactory
    {
        Dictionary<GitTFSCommandsEnum, Process> GenerateProcessDictionary(GitMigrationRow migrationRow);
    }
}
