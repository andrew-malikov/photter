using System.Collections.Generic;
using System.CommandLine;

namespace Photter.Handlers.Database {
    public class DbHandler : INestedHandler {
        public Command Command { get; private set; }

        public DbHandler(IEnumerable<IDbHandler> handlers) {
            Command = new Command("db");

            foreach (var handler in handlers)
                Command.AddCommand(handler.Command);
        }
    }
}