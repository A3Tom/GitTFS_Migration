using GitTFS_Migration.Domain.Interfaces;
using System.Diagnostics;

namespace GitTFS_Migration.Domain.Classes
{
    public class ProcessFactory : IProcessFactory
    {
        public Process GenerateProcess()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            process.StartInfo = startInfo;

            return process;
        }
    }
}
