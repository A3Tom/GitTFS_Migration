using Ninject;
using Ninject.Modules;

namespace GitTFS_Migration.Application
{
    public class CompositionRoot
    {
        public static IKernel _ninjectKernel;

        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
    }
}
