namespace Photter.Core.Project.Domain

open System

type Photo = {
    Id : string;
    Name : string;
    Author : string;
 }

type PhotoCollection = {
    Id : string;
    PersistanceId : string;
    Photos : Photo list;
    Updated: DateTime;
 }

type Project = { Collections : PhotoCollection list }

module PhotoCollections =
    let equals (x: PhotoCollection) (y: PhotoCollection) = String.Equals(x.Id, y.Id)

    let add collection toCollections = collection :: List.filter (equals collection >> not) toCollections
    let remove collectionId fromCollections = List.filter (fun c -> c.Id <> collectionId) fromCollections


module Photos =
    let equals (x: Photo) (y: Photo) = String.Equals(x.Id, y.Id)
