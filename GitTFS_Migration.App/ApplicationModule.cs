using GitTFS_Migration.Domain.Classes;
using GitTFS_Migration.Domain.Interfaces;
using GitTFS_Migration.Service.Classes;
using GitTFS_Migration.Service.Interfaces;
using Ninject.Modules;
using NLog;

namespace GitTFS_Migration.Application
{
    class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().ToMethod(x =>
            {
                var scope = x.Request.ParentRequest.Service.FullName;
                var log = (ILog)LogManager.GetLogger(scope, typeof(Log));
                return log;
            });

            #region Service Bindings

            Bind(typeof(IApp)).To(typeof(App))
                .InSingletonScope();

            Bind(typeof(IFileSelector)).To(typeof(FileSelector))
                .InTransientScope();

            Bind(typeof(IFileReader)).To(typeof(FileReader))
                .InTransientScope();

            Bind(typeof(IRepositoryValidator)).To(typeof(RepositoryValidator))
                .InTransientScope();

            Bind(typeof(ICommandLibraryFactory)).To(typeof(CommandLibraryFactory))
                .InTransientScope();

            Bind(typeof(IMigrationDGVFactory)).To(typeof(MigrationDGVFactory))
                .InTransientScope();

            #endregion
        }
    }
}
