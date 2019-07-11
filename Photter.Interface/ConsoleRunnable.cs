using System.CommandLine;
using System.Threading.Tasks;
using Photter.Core.Configs;

namespace Photter.Interface {
    public abstract class ConsoleRunnable {
        protected readonly LaunchConfig Configuration;
        protected readonly RootCommand Root;

        protected ConsoleRunnable(LaunchConfig configuration) {
            Configuration = configuration;
            Root = ProvideInternalRootCommand();
        }

        protected abstract RootCommand ProvideInternalRootCommand();

        public abstract Task<int> Run();
    }
}