using System.Data;

namespace GitTFS_Migration.Domain.DataModels
{
    public class GitMigrationRow
    {
        public GitMigrationRow(string[] fields)
        {
            if (fields.Length > 2)
            {
                BranchName = fields[0];
                OldTFSRepository = fields[1];
                NewGitRepository = fields[2];

                OldTFSRepositoryValid = false;
                NewGitRepositoryValid = false;
            }
        }
        public string BranchName { get; set; }

        public string OldTFSRepository { get; set; }

        public bool OldTFSRepositoryValid { get; set; }

        public string NewGitRepository { get; set; }

        public bool NewGitRepositoryValid { get; set; }

        public bool EligableForMigration => OldTFSRepositoryValid && NewGitRepositoryValid;
    }
}
