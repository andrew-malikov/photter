using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Photter.Handlers.Collections {
    public class CollectionsListHandler : ICollectionsHandler {
        public Command Command { get; private set; }

        private Lazy<ICollectionsListService> _service;

        public CollectionsListHandler(Lazy<ICollectionsListService> service) {
            _service = service;

            Command = new Command(
                name: "list",
                description: "list all collections",
                handler: CommandHandler.Create(
                    () => _service.Value.ShowAllCollections()
                )
            );
        }
    }
}