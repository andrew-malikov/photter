using Photter.Configs;
using Photter.Datastore.Models;

namespace Photter.Datastore.Services {
    public class DbService {
        private readonly ApplicationState _state;

        public DbService(ApplicationState state) {
            _state = state;
        }

        public void InitializeDb() {
            _state.Database.EnsureCreated();
        }

        public void ClearDb() {
            if (_state.Database.EnsureDeleted()) _state.Database.EnsureCreated();
        }
    }
}