namespace Photter.Datastore.Models {
    public class CachedPhoto {
        public int Id { get; set; }

        public string UnsplashId { get; set; }
        public string Description { get; set; }

        public bool IsCached { get; set; }

        public PhotoCollection PhotoCollection { get; set; }
    }
}