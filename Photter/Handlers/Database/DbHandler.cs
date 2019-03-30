using System.Collections.Generic;
using System.CommandLine;

namespace Photter.Handlers.Db {
    public class DbHandler : INestedHandler {
        public Command Command { get; private set; }

        public DbHandler(IEnumerable<IDbHandler> dbHandlers) {
            Command = new Command("db");

            foreach (var handler in dbHandlers)
                Command.AddCommand(handler.Command);
        }
    }
}