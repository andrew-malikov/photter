namespace Photter.Handlers.Collections {
    public interface ICollectionsListService {
        void ShowAllCollections();
        void ShowCollection(string id);
        void ShowCollections(params string[] id);
        void ShowCollectionPhotos(string id);
    }
}