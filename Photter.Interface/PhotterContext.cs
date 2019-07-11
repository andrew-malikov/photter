using System.CommandLine;
using System.Net.Http;
using LightInject;
using Microsoft.EntityFrameworkCore;
using Phaber.Unsplash;
using Phaber.Unsplash.Clients;
using Photter.Core.Configs;
using Photter.Infrastructure.Unsplash;
using Photter.Interface.Handlers;

namespace Photter.Interface {
    public class PhotterContext : Context {
        private readonly LaunchConfig _launchConfig;

        public PhotterContext(LaunchConfig launchConfig) {
            _launchConfig = launchConfig;
        }

        protected override void ConfigureServices(ServiceContainer container) {
            container.RegisterInstance(_launchConfig);

            container.RegisterSingleton<IProjectProvider, JsonProjectProvider>();
            container.RegisterSingleton(
                context => context.GetInstance<IProjectProvider>().Provide()
            );

            container.RegisterSingleton<ApiUris>();

            container.RegisterSingleton<CredentialsProvider>();
            container.RegisterSingleton(
                context => context.GetInstance<CredentialsProvider>().Provide()
            );

            container.RegisterSingleton<HttpClient>();

            container.RegisterSingleton<DbLoggerCategory.Database.Connection>();

            container.RegisterSingleton<IPhotoClient, PhotoClient>();
            container.RegisterSingleton<ICollectionClient, CollectionClient>();

            container.RegisterInstance(
                new RootCommand("photter")
            );

            container.RegisterSingleton<RootHandler>();
        }
    }
}