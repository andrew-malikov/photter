using Microsoft.EntityFrameworkCore;

namespace Photter.Datastore.Models {
    public class ApplicationState : DbContext {
        public DbSet<PhotoCollection> PhotoCollections { get; set; }
        public DbSet<CachedPhoto> CachedPhotos { get; set; }

        public ApplicationState(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<CachedPhoto>(entity => {
                entity
                    .HasOne(p => p.PhotoCollection)
                    .WithMany(c => c.CachedPhotos)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}