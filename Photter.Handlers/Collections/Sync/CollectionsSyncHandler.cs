using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Photter.Handlers.Collections {
    public class CollectionsSyncHandler : ICollectionsHandler {
        public Command Command { get; private set; }

        private Lazy<ICollectionsSyncService> _service;

        public CollectionsSyncHandler(Lazy<ICollectionsSyncService> service) {
            _service = service;

            Command = new Command(
                name: "sync",
                description: "sync all collections",
                handler: CommandHandler.Create(
                    () => _service.Value.SyncAllCollections()
                )
            );
        }
    }
}