using Microsoft.EntityFrameworkCore;
using Photter.Configs;
using Photter.Datastore.Models;

namespace Photter.Datastore.Services {
    public class DbContextOptionsProvider {
        private readonly string _dbConnection;

        public DbContextOptionsProvider(ProjectConfig config) {
            _dbConnection = config.DbConnetion;
        }

        public DbContextOptions Provide() {
            return new DbContextOptionsBuilder()
                .UseSqlite(_dbConnection)
                .Options;
        }
    }
}