using System;
using System.Linq;

using Phaber.Unsplash.Clients;

using Photter.Datastore.Models;
using Photter.Datastore.Contracts;

namespace Photter.Handlers.Collections {
    public class CollectionsAddService : ICollectionsAddService {
        private readonly ICollectionClient _client;
        private readonly ApplicationState _state;

        public CollectionsAddService(
            ICollectionClient client,
            ApplicationState state
        ) {
            _client = client;
            _state = state;
        }

        public void AddCollection(string id) {
            if (_state.PhotoCollections.Any(c => c.UnsplashId == id))
                return;

            try {
                _state
                    .PhotoCollections
                    .Add(
                        new PhotoCollectionFromUnsplash(
                            _client.GetAsync(id).Result
                        )
                    );

                _state.SaveChanges();
            }
            catch (Exception exception) {
                Console.WriteLine(
                    $"can't add collection with id '{id}' {exception.Message}"
                );
            }
        }

        public void AddCollections(params string[] id) {
            throw new NotImplementedException();
        }
    }
}