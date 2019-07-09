using System;
using Phaber.Unsplash.Clients;
using Phaber.Unsplash.Models;

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

            foreach (var page in _client.GetPhotos(collectionId)) {
                foreach (var photo in page.Body)
                    Console.WriteLine(
                        $"{photo.Id} - {photo.Downloads} - {photo.Width}/{photo.Height}"
                    );
            }
        }
    }
}