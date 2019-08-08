namespace Photter.Core.Project.Service

open System

open Photter.Core.Project.Domain

module Photos =
    type CollectionDifference = {
        Additions : Photo Set;
        Removal : Photo Set
    }

    /// <param name="x">pivot collection</param>
    /// <param name="y">collection to check the diff</param>
    let difference x y = {
        Additions = Set.difference x y;
        Removal = Set.difference y x
    }

    let update collection byDifference =
        Set.union collection byDifference.Additions |>
        Set.difference <| byDifference.Removal

module PhotoCollections =
    let add collections collection =
        Set.remove collection collections |>
        Set.add { collection with Updated = DateTime.UtcNow }
