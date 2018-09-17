using GitTFS_Migration.Domain.Interfaces;
using GitTFS_Migration.Domain.Classes;
using Ninject.Modules;
using NLog;
using GitTFS_Migration.Service.Interfaces;
using GitTFS_Migration.Service.Classes;

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

            #endregion
        }
    }
}
