using GitTFS_Migration.Domain.DataModels;
using GitTFS_Migration.Domain.Enums;
using GitTFS_Migration.Service.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace GitTFS_Migration.Service.Classes
{
    public class FileReader : IFileReader
    {
        private readonly IRepositoryValidator _repositoryValidator;

        public FileReader(IRepositoryValidator repositoryValidator)
        {
            _repositoryValidator = repositoryValidator;
        }

        public List<GitMigrationRow> ParseCSVToList(string filePath)
        {
            List<GitMigrationRow> rows = File.ReadAllLines(filePath)
                .Select(x => new GitMigrationRow(x.Split(',')))
                .ToList();

            foreach (GitMigrationRow row in rows)
            {
                //Make Async calls & run in parallel
                row.OldTFSRepositoryValid = _repositoryValidator.ValidateRepository(RepositoryTypeEnum.TFS, row.OldTFSRepository);
                row.NewGitRepositoryValid = _repositoryValidator.ValidateRepository(RepositoryTypeEnum.Git, row.NewGitRepository);
            }

            return rows;
        }
    }
}
