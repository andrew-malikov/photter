using Phaber.Unsplash;

namespace Photter.Core.Configs {
    public class AppConfig {
        public readonly Credentials Credentials;

        public AppConfig(Credentials credentials) {
            Credentials = credentials;
        }
    }
}