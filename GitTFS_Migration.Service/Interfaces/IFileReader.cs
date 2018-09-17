using GitTFS_Migration.Domain.DataModels;
using System.Collections.Generic;

namespace GitTFS_Migration.Service.Interfaces
{
    public interface IFileReader
    {
        List<GitMigrationRow> ParseCSVToList(string filePath);
    }
}
