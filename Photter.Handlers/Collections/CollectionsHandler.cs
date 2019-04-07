using System.Collections.Generic;
using System.CommandLine;

namespace Photter.Handlers.Collections {
    public class CollectionsHandler : INestedHandler {
        public Command Command { get; private set; }

        public CollectionsHandler(IEnumerable<ICollectionsHandler> handlers) {
            Command = new Command("db");

            foreach (var handler in handlers)
                Command.AddCommand(handler.Command);
        }
    }
}