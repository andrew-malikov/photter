namespace Photter.Handlers.Collections {
    public interface ICollectionsAddService {
        void AddCollection(string id);
        void AddCollections(params string[] id);
    }
}