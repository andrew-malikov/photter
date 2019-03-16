using System;
using System.Net.Http;

using LightInject;

using Phaber.Unsplash;
using Phaber.Unsplash.Http;

using Photter.Configs;
using Photter.Unsplash;

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

            // unsplash clients
            container.RegisterSingleton<ApiUrls>();
            container.RegisterSingleton<CredentialsProvider>();
            container.RegisterSingleton<HttpClient>();
            container.RegisterInstance<IValidatableHttpResponse>(
                new ChainableValidationHandler(new RateLimitValidationHandler()));
            container.RegisterSingleton<ConnectionProvider>();
            container.RegisterSingleton<UnsplashClientFactory>();

            // database
        }
    }
}