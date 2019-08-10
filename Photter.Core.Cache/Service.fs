namespace Photter.Core.Cache.Service

open Photter.Core.Cache.Domain

module CachedCollection =
    let update download persist photos collection =
        let persistPhoto (photo : CachedPhoto) =
            download photo.Id |>
            persist collection.PersistanceId photo.Id

        let downloadPhotos =
            Set.difference photos collection.CachedPhotos |>
            Set.filter persistPhoto

        { collection with CachedPhotos = Set.union downloadPhotos collection.CachedPhotos }

    let persistedIn photo collections =
        collections |>
        Set.filter (fun collection -> Set.contains photo collection.CachedPhotos)

    let persistedInShared photo persistanceId collections =
        persistedIn photo collections |>
        Set.filter (fun collection -> collection.PersistanceId = persistanceId)

    let clear delete found collection collections =
        let deletePhoto (photo : CachedPhoto) = 
            delete collection.PersistanceId photo.Id
        
        let isShared photo = 
            persistedInShared photo collection.PersistanceId collections |>
            Set.count > 1

        Set.difference found collection.CachedPhotos |>
        Set.filter (isShared >> not) |>
        Set.filter deletePhoto
