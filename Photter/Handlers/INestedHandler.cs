using System.CommandLine;

namespace Photter.Handlers {
    public interface INestedHandler {
        Command Command { get; }
    }
}