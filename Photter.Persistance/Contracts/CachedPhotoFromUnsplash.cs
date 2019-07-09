using Phaber.Unsplash.Models;

using Photter.Datastore.Models;

namespace Photter.Datastore.Contracts {
    public class CachedPhotoFromUnsplash : CachedPhoto {
        public CachedPhotoFromUnsplash(Photo photo, bool isCached = false) {
            UnsplashId = photo.Id;
            Description = photo.Description;
            IsCached = isCached;
        }
    }
}