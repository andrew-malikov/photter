using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

using LightInject;

using Photter.Configs;
using Photter.Handlers;
using Photter.Interface;

namespace Photter {
    public class Application : ConsoleRunnable {
        public Application(string[] args) : base(new LaunchConfig(args)) { }

        public override Task<int> Run() {
            return Root.InvokeAsync(Configuration.Args);
        }

        protected override RootCommand ProvideInternalRootCommand() {
            return new PhotterContext(Configuration)
                .Prepare()
                .GetInstance<RootHandler>()
                .Root;
        }
    }
}