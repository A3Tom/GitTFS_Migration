using GitTFS_Migration.Domain.DataModels;
using GitTFS_Migration.Domain.Enums;
using GitTFS_Migration.Domain.Interfaces;
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
        private readonly IMigrationDGVFactory _migrationDGVFactory;

        private DataColumn[] _dataColumns = null;

        public FileReader(IRepositoryValidator repositoryValidator,
            IMigrationDGVFactory migrationDGVFactory)
        {
            _repositoryValidator = repositoryValidator;
            _migrationDGVFactory = migrationDGVFactory;
        }

        public DataTable ParseCSVToDataTable(string filePath, DataTable dataTable = null)
        {
            List<GitMigrationRow> rows = File.ReadAllLines(filePath)
                .Select(x => new GitMigrationRow(x.Split(',')))
                .ToList();

            if (dataTable == null)
            {
                dataTable = new DataTable();

                _dataColumns = _migrationDGVFactory.GenerateMigrationHeaderRow();
                dataTable.Columns.AddRange(_dataColumns);
            }
            else
            {
                dataTable.Clear();
            }

            foreach (GitMigrationRow row in rows)
            {
                //Make Async calls & run in parallel
                row.OldTFSRepositoryValid = _repositoryValidator.ValidateRepository(RepositoryTypeEnum.TFS, row.OldTFSRepository);
                row.NewGitRepositoryValid = _repositoryValidator.ValidateRepository(RepositoryTypeEnum.Git, row.NewGitRepository);

                dataTable.Rows.Add(
                    row.BranchName,
                    row.OldTFSRepository,
                    row.OldTFSRepositoryValid,
                    row.NewGitRepository,
                    row.NewGitRepositoryValid
                    );
            }

            return dataTable;
        }
    }
}
