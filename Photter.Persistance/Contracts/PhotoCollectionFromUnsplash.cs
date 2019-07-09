using System;
using Phaber.Unsplash.Models;

using Photter.Datastore.Models;

namespace Photter.Datastore.Contracts {
    public class PhotoCollectionFromUnsplash : PhotoCollection {
        public PhotoCollectionFromUnsplash(Collection collection) {
            UnsplashId = collection.Id;
            Title = collection.Title;
            SyncedAt = DateTime.Now;
            IsSyncFailed = false;
            TotalPhotos = collection.TotalPhotos;
        }
    }
}