using GitTFS_Migration.Domain.Enums;
using GitTFS_Migration.Service.Interfaces;

namespace GitTFS_Migration.Service.Classes
{
    public class RepositoryValidator : IRepositoryValidator
    {
        private const string TFS_SERVER = @"http://i-t-v-tf01.amorgroup.local:8080/tfs";

        public bool ValidateRepository(RepositoryTypeEnum repositoryType, string repositoryLocation)
        {
            bool result = false;

            if (repositoryType == RepositoryTypeEnum.Git)
                result = ValidateGitRepository(repositoryLocation);
            else
                result = ValidateTFSRepository(repositoryLocation);

            return result;
        }

        private bool ValidateGitRepository(string repositoryLocation)
        {
            return true;
        }

        private bool ValidateTFSRepository(string repositoryLocation)
        {
            return true;
        }
    }
}
