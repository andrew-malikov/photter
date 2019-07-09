using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace Photter.Handlers.Database {
    public class DbClearHandler : IDbHandler {
        public Command Command { get; private set; }

        private Lazy<IDbClearService> _service;

        public DbClearHandler(Lazy<IDbClearService> service) {
            _service = service;

            Command = new Command(
                "clear",
                 handler: CommandHandler.Create(() => {
                     _service.Value.ClearDb();
                 })
            );
        }
    }
}