using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Photter.Handlers.Database {
    public class DbInitHandler : IDbHandler {
        public Command Command { get; }

        private Lazy<IDbInitService> _service;

        public DbInitHandler(Lazy<IDbInitService> service) {
            _service = service;

            Command = new Command(
                "init",
                handler: CommandHandler.Create(() => {
                    _service.Value.InitializeDb();
                })
            );
        }
    }
}