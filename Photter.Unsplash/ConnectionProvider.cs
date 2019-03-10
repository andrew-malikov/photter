using System;
using System.Net.Http;

using Phaber.Unsplash;
using Phaber.Unsplash.Http;

namespace Photter.Unsplash {
    public class ConnectionProvider {
        private Lazy<Credentials> _credentials;
        private HttpClient _httpClient;
        private IValidatableHttpResponse _responseHandler;

        public ConnectionProvider(
            CredentialsProvider credentialsProvider,
            HttpClient httpClient,
            IValidatableHttpResponse responseHandler
        ) {
            _credentials = new Lazy<Credentials>(
                () => credentialsProvider.Provide()
            );

            _httpClient = httpClient;
            _responseHandler = responseHandler;
        }

        public Connection Provide() {
            return new Connection(
                _httpClient,
                _credentials.Value,
                _responseHandler
            );
        }
    }
}