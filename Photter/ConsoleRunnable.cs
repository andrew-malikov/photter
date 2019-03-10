using System.CommandLine;
using System.Threading.Tasks;

using LightInject;

using Photter.Configs;

namespace Photter {
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