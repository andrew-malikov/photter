using System.CommandLine;
using System.Net.Http;
using LightInject;
using Microsoft.EntityFrameworkCore;
using Phaber.Unsplash;
using Phaber.Unsplash.Clients;
using Photter.Configs;
using Photter.Datastore.Models;
using Photter.Datastore.Services;
using Photter.Handlers;
using Photter.Handlers.Collections;
using Photter.Handlers.Database;
using Photter.Handlers.Sync;
using Photter.Infrastructure.Unsplash;

namespace Photter.Interface {
    public class PhotterContext : Context {
        private readonly LaunchConfig _launchConfig;

        public PhotterContext(LaunchConfig launchConfig) {
            _launchConfig = launchConfig;
        }

        protected override void ConfigureServices(ServiceContainer container) {
            // configs
            container.RegisterInstance(_launchConfig);

            container.RegisterSingleton<IProjectProvider, JsonProjectProvider>();
            container.RegisterSingleton(
                context => context.GetInstance<IProjectProvider>().Provide()
            );

            // db
            container.RegisterSingleton<DbContextOptionsProvider>();
            container.RegisterSingleton(
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

            container.RegisterSingleton<DbLoggerCategory.Database.Connection>();

            container.RegisterSingleton<IPhotoClient, PhotoClient>();
            container.RegisterSingleton<ICollectionClient, CollectionClient>();

            // handlers
            container.RegisterInstance<RootCommand>(
                new RootCommand("photter")
            );

            // sync handlers [deprecated]
            container.Register<ISyncCollectionService, SyncCollectionService>();
            container.RegisterSingleton<INestedHandler, SyncCollectionHandler>(
                "SyncHandler"
            );

            // db handlers
            container.Register<IDbInitService, DbInitService>();
            container.RegisterSingleton<IDbHandler, DbInitHandler>(
                "DbInitHandler"
            );

            container.Register<IDbClearService, DbClearService>();
            container.RegisterSingleton<IDbHandler, DbClearHandler>(
                "DbClearHandler"
            );

            container.RegisterSingleton<INestedHandler, DbHandler>(
                "DbHandler"
            );

            // collections handlers
            container.Register<ICollectionsAddService, CollectionsAddService>();
            container.RegisterSingleton<ICollectionsHandler, CollectionsAddHandler>(
                "CollectionsAddHandler"
            );

            container.Register<ICollectionsListService, CollectionsListService>();
            container.RegisterSingleton<ICollectionsHandler, CollectionsListHandler>(
                "CollectionsListHandler"
            );

            container.Register<ICollectionsSyncService, CollectionsSyncService>();
            container.RegisterSingleton<ICollectionsHandler, CollectionsSyncHandler>(
                "CollectionsSyncHandler"
            );

            container.RegisterSingleton<INestedHandler, CollectionsHandler>(
                "CollectionsHandler"
            );

            container.RegisterSingleton<RootHandler>();
        }
    }
}