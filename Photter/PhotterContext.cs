using System;
using System.CommandLine;
using System.Net.Http;

using LightInject;

using Microsoft.EntityFrameworkCore;

using Phaber.Unsplash;
using Phaber.Unsplash.Clients;
using Phaber.Unsplash.Http;

using Photter.Configs;
using Photter.Datastore.Models;
using Photter.Datastore.Services;
using Photter.Unsplash;
using Photter.Handlers;
using Photter.Handlers.Sync;
using Photter.Handlers.Database;

namespace Photter {
    public class PhotterContext : Context {
        private readonly LaunchConfig _launchConfig;

        public PhotterContext(LaunchConfig launchConfig) : base() {
            _launchConfig = launchConfig;
        }

        protected override void ConfigureServices(ServiceContainer container) {
            // configs
            container.RegisterInstance<LaunchConfig>(_launchConfig);

            container.RegisterSingleton<IProjectProvider, JsonProjectProvider>();
            container.RegisterSingleton<ProjectConfig>(
                context => context.GetInstance<IProjectProvider>().Provide()
            );

            // db
            container.RegisterSingleton<DbContextOptionsProvider>();
            container.RegisterSingleton<DbContextOptions>(
                context => context.GetInstance<DbContextOptionsProvider>().Provide()
            );

            container.Register<ApplicationState>();

            container.Register<DbService>();

            // unsplash clients
            container.RegisterSingleton<ApiUris>();

            container.RegisterSingleton<CredentialsProvider>();
            container.RegisterSingleton<Credentials>(
                context => context.GetInstance<CredentialsProvider>().Provide()
            );

            container.RegisterSingleton<HttpClient>();
            container.RegisterInstance<IValidatableHttpResponse>(
                new ChainableValidationHandler(
                    new RateLimitValidationHandler()
                )
            );

            container.RegisterSingleton<Connection>();

            container.RegisterSingleton<IPhotoClient, PhotoClient>();
            container.RegisterSingleton<ICollectionClient, CollectionClient>();

            // handlers
            container.RegisterInstance<RootCommand>(
                new RootCommand("photter")
            );

            // sync handlers
            container.Register<ISyncCollectionService, SyncCollectionService>();
            container.RegisterSingleton<INestedHandler, SyncCollectionHandler>("SyncHandler");

            // db handlers
            container.Register<IDbInitService, DbInitService>();
            container.RegisterSingleton<IDbHandler, DbInitHandler>("DbInitHandler");

            container.Register<IDbClearService, DbClearService>();
            container.RegisterSingleton<IDbHandler, DbClearHandler>("DbClearHandler");

            container.RegisterSingleton<INestedHandler, DbHandler>("DbHandler");

            container.RegisterSingleton<RootHandler>();
        }
    }
}