using System;
using System.Collections.Generic;

namespace Photter.Synchronization.Models {
    public class PhotoCollection {
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime SyncedAt { get; set; }
        public bool IsSyncFailed { get; set; }

        public int TotalPhotos { get; set; }

        public IList<CachedPhoto> CachedPhotos { get; set; } = new List<CachedPhoto>();
    }
}