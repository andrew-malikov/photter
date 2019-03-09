using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photter.Datastore.Models {
    public class PhotoCollection {
        [Key]
        public string Id { get; set; }

        public string Title { get; set; }

        public DateTime SyncedAt { get; set; }
        public bool IsSyncFailed { get; set; }

        public int TotalPhotos { get; set; }

        public IList<CachedPhoto> CachedPhotos = new List<CachedPhoto>();
    }
}