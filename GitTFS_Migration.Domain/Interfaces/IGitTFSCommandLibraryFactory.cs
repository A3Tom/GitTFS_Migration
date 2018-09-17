﻿using GitTFS_Migration.Domain.Enums;
using System.Collections.Generic;

namespace GitTFS_Migration.Domain.Interfaces
{
    public interface IGitTFSCommandLibraryFactory
    {
        Dictionary<GitTFSCommandsEnum, string> GenerateGitTFSCommandDictionary(string tfsRepositoryPath, string gitRepositoryPath);
    }
}
