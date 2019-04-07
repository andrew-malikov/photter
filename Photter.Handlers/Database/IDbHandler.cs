using System.CommandLine;

namespace Photter.Handlers.Database {
    public interface IDbHandler {
        Command Command { get; }
    }
}