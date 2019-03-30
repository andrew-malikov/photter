using System.CommandLine;

namespace Photter.Handlers.Db {
    public interface IDbHandler {
        Command Command { get; }
    }
}