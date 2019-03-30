using System;
using System.Threading.Tasks;

using Phaber.Unsplash.Clients;
using Phaber.Unsplash.Models;

using Photter.Unsplash;

namespace Photter.Handlers.Sync {
    public class SyncCollectionService : ISyncCollectionService {
        private ICollectionClient _client;

        public SyncCollectionService(ICollectionClient client) {
            _client = client;
        }

        public void SyncCollectionAsync(string collectionId) {
            if (String.IsNullOrEmpty(collectionId))
                throw new ArgumentException("collectionId can't be empty");

            Collection collection = _client.GetAsync(collectionId).Result;

            Console.WriteLine(
                $"{collection.Id} - {collection.Title} - {collection.TotalPhotos}"
            );
        }
    }
}