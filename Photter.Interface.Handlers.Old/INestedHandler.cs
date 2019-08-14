using System.CommandLine;

namespace Photter.Interface.Handlers.Old {
    public interface INestedHandler {
        Command Command { get; }
    }
}