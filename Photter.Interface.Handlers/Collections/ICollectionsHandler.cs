using System.CommandLine;

namespace Photter.Handlers.Collections {
    public interface ICollectionsHandler {
        Command Command { get; }
    }
}