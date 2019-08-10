module Photter.Core.Cache.Domain

open System

[<CustomEquality; CustomComparison>]
type CachedPhoto =
    { Id : string; }

    override photo.Equals(other) =
        match other with
        | :? CachedPhoto as another -> (photo.Id = another.Id)
        | _ -> false

    override photo.GetHashCode() = hash photo.Id

    interface IComparable with
      member photo.CompareTo other =
          match other with
          | :? CachedPhoto as another -> compare photo.Id another.Id
          | _ -> invalidArg "other" "cannot compare values of different types"

[<CustomEquality; CustomComparison>]
type CachedCollection =
    { Id : string;
      PersistanceId : string;
      CachedPhotos : CachedPhoto Set }

    override photo.Equals(other) =
        match other with
        | :? CachedCollection as another -> (photo.Id = another.Id)
        | _ -> false

    override photo.GetHashCode() = hash photo.Id

    interface IComparable with
      member photo.CompareTo other =
          match other with
          | :? CachedCollection as another -> compare photo.Id another.Id
          | _ -> invalidArg "other" "cannot compare values of different types"

type Cache = { CachedCollection : CachedCollection Set }
