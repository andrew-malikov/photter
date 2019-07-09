namespace Photter.Handlers.Collections {
    public interface ICollectionsSyncService {
        void SyncAllCollections();
        void SyncCollections(params string[] id);
        void SyncCollection(string id);
    }
}