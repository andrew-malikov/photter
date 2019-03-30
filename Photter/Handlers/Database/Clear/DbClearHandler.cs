using System;
using System.CommandLine;
using System.CommandLine.Invocation;

using Photter.Handlers.Db;

namespace Photter.Handlers.Database.Clear {
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