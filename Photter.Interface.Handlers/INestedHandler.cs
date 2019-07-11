using System.CommandLine;

namespace Photter.Interface.Handlers {
    public interface INestedHandler {
        Command Command { get; }
    }
}