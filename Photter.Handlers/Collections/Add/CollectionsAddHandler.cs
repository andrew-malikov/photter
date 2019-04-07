using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Photter.Handlers.Collections {
    public class CollectionsAddHandler : ICollectionsHandler {
        public Command Command { get; private set; }

        private Lazy<ICollectionsAddService> _service;

        public CollectionsAddHandler(Lazy<ICollectionsAddService> service) {
            _service = service;

            Command = new Command(
                name: "add",
                description: "add collection by id",
                argument: new Argument<string>() {
                    Name = "id",
                    Description = "id of collection to add",
                    Arity = ArgumentArity.ExactlyOne
                }
            );

            Command.Handler = CommandHandler.Create<string>(
                id => _service.Value.AddCollection(id)
            );
        }
    }
}