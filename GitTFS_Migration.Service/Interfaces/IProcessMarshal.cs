using GitTFS_Migration.Domain.DataModels;
using System.Threading.Tasks;

namespace GitTFS_Migration.Service.Interfaces
{
    public interface IProcessMarshal
    {
        Task GenerateMigrationTaskAsync(GitMigrationRow row);
    }
}
