using GitTFS_Migration.Domain.DataModels;
using GitTFS_Migration.Domain.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace GitTFS_Migration.Domain.Classes
{
    public class MigrationDGVFactory : IMigrationDGVFactory
    {
        private DataColumn[] _dataColumns = null;

        public DataTable GenerateMigrationDataTableFromList(List<GitMigrationRow> dataSet, DataTable dataTable = null)
        {
            if (dataTable == null)
            {
                dataTable = new DataTable();

                _dataColumns = GenerateMigrationHeaderRow();
                dataTable.Columns.AddRange(_dataColumns);
            }

            dataTable.Clear();

            foreach (GitMigrationRow row in dataSet)
            {
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

        private DataColumn[] GenerateMigrationHeaderRow()
        {
            return new List<DataColumn>
            {
                new DataColumn("Branch Name"),
                new DataColumn("Old TFS Repository"),
                new DataColumn("TFS Valid", typeof(bool)),
                new DataColumn("New Git Repository"),
                new DataColumn("Git Valid", typeof(bool))
            }
            .ToArray();
        }
    }
}
