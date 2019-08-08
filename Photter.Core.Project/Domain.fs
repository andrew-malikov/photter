namespace Photter.Core.Project.Domain

open System

[<CustomEquality; CustomComparison>]
type Photo =
    { Id : string; Name : string; Author : string; }

    override photo.Equals(other) =
        match other with
        | :? Photo as another -> (photo.Id = another.Id)
        | _ -> false

    override photo.GetHashCode() = hash photo.Id

    interface IComparable with
      member photo.CompareTo other =
          match other with
          | :? Photo as another -> compare photo.Id another.Id
          | _ -> invalidArg "other" "cannot compare values of different types"

[<CustomEquality; CustomComparison>]
type PhotoCollection =
    { Id : string;
      PersistanceId : string;
      Photos : Photo Set;
      Updated : DateTime; }

    override photo.Equals(other) =
        match other with
        | :? PhotoCollection as another -> (photo.Id = another.Id)
        | _ -> false

    override photo.GetHashCode() = hash photo.Id

    interface IComparable with
      member photo.CompareTo other =
          match other with
          | :? Photo as another -> compare photo.Id another.Id
          | _ -> invalidArg "other" "cannot compare values of different types"

type Project = { Collections : PhotoCollection Set }
