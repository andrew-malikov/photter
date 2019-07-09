using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Photter.Handlers.Sync {
    public class SyncCollectionHandler : INestedHandler {
        public Command Command { get; private set; }

        private Lazy<ISyncCollectionService> _service;

        public SyncCollectionHandler(Lazy<ISyncCollectionService> service) {
            _service = service;

            Command = new Command(
                name: "sync-collection",
                description: "sync collection by id",
                argument: new Argument<string>() {
                    Name = "id",
                    Description = "collection id to sync",
                    Arity = ArgumentArity.ExactlyOne
                }
            );

            Command.Handler = CommandHandler.Create<string>(
                id => _service.Value.SyncCollectionAsync(id)
            );
        }
    }
}