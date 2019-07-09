namespace Photter.Datastore.Models {
    public class CachedPhoto {
        public int Id { get; set; }

        public string UnsplashId { get; set; }
        public string Description { get; set; }

        public bool IsCached { get; set; }

        public PhotoCollection PhotoCollection { get; set; }

        public SetupCachedPhoto Setup() {
            return new SetupCachedPhoto(this);
        }
    }

    public class SetupCachedPhoto {
        private CachedPhoto _cachedPhoto;

        public SetupCachedPhoto(CachedPhoto cachedPhoto) {
            _cachedPhoto = cachedPhoto;
        }

        public SetupCachedPhoto LinkToCollection(PhotoCollection collection) {
            _cachedPhoto.PhotoCollection = collection;

            return this;
        }

        public CachedPhoto Done() {
            return _cachedPhoto;
        }
    }
}