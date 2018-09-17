using System.Diagnostics;

namespace GitTFS_Migration.Domain.Interfaces
{
    public interface IProcessFactory
    {
        Process GenerateProcess();
    }
}
