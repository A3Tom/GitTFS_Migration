using System;

namespace GitTFS_Migration.Application
{
    static class GitTFS_Migration
    {
        [STAThread]
        static void Main()
        {
            CompositionRoot.Wire(new ApplicationModule());

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            System.Windows.Forms.Application.Run(CompositionRoot.Resolve<MainForm>());
        }
    }
}
