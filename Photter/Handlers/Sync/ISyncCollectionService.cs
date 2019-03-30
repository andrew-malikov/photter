using System.Threading.Tasks;

namespace Photter.Handlers.Sync {
    public interface ISyncCollectionService {
        void SyncCollectionAsync(string collectionId);
    }
}