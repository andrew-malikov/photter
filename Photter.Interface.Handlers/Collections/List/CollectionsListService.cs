using System;
using System.Linq;

using Photter.Datastore.Models;

namespace Photter.Handlers.Collections {
    public class CollectionsListService : ICollectionsListService {
        private readonly ApplicationState _state;

        public CollectionsListService(ApplicationState state) {
            _state = state;
        }

        public void ShowCollection(string id) {
            throw new NotImplementedException();
        }

        public void ShowAllCollections() {
            foreach (var collection in _state.PhotoCollections) {
                Console.WriteLine(
                    $"\n\tid: {collection.UnsplashId}\n\t\ttitle: {collection.Title}"
                );
            }
        }

        public void ShowCollections(params string[] id) {
            throw new NotImplementedException();
        }

        public void ShowCollectionPhotos(string id) {
            throw new NotImplementedException();
        }
    }
}