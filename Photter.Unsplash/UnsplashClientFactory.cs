using System;

using Phaber.Unsplash;
using Phaber.Unsplash.Clients;
using Phaber.Unsplash.Http;

namespace Photter.Unsplash {
    public class UnsplashClientFactory {
        private Lazy<Connection> _connection;

        private ApiUrls _apiUrls;

        public UnsplashClientFactory(ApiUrls apiUrls, ConnectionProvider connectionProvider) {
            _connection = new Lazy<Connection>(
                () => connectionProvider.Provide()
            );

            _apiUrls = apiUrls;
        }

        public PhotoClient PhotoClient =>
            new PhotoClient(_apiUrls, _connection.Value);

        public CollectionClient CollectionClient =>
            new CollectionClient(_apiUrls, _connection.Value);
    }
}