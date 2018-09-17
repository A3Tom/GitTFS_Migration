using GitTFS_Migration.Domain.Enums;

namespace GitTFS_Migration.Service.Interfaces
{
    public interface IRepositoryValidator
    {
        bool ValidateRepository(RepositoryTypeEnum repositoryType, string repositoryLocation);
    }
}
