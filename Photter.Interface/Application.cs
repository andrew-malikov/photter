using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;
using LightInject;
using Photter.Interface.Handlers;

namespace Photter.Interface {
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