using System;

using Phaber.Unsplash;

using Photter;
using Photter.Configs;

namespace Photter.Unsplash {
    public class CredentialsProvider {
        private Lazy<string> _appId;

        public CredentialsProvider(IProjectProvider projectProvider) {
            _appId = new Lazy<string>(
                () => projectProvider.Provide().AppId
            );
        }

        public Credentials Provide() {
            return new Credentials(_appId.Value, "NOT_NEEDED");
        }
    }
}