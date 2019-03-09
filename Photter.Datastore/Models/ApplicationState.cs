using Microsoft.EntityFrameworkCore;

namespace Photter.Datastore.Models {
    public class ApplicationState : DbContext {
        public DbSet<PhotoCollection> PhotoCollections { get; set; }
        public DbSet<CachedPhoto> CachedPhotos { get; set; }

        public ApplicationState(DbContextOptions<ApplicationState> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<CachedPhoto>(entity => {
                entity
                    .HasOne(p => p.Collection)
                    .WithMany(c => c.CachedPhotos)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}