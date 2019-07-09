using Photter.Datastore.Services;

namespace Photter.Handlers.Database {
    public class DbClearService : IDbClearService {
        private DbService _dbService;

        public DbClearService(DbService dbService) {
            _dbService = dbService;
        }

        public void ClearDb() {
            _dbService.ClearDb();
        }
    }
}