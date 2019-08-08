namespace Photter.Core.Project.Service

open Photter.Core.Project.Domain

module Photos =
    type CollectionDifference = {
        Additions : Photo Set;
        Removal : Photo Set
    }

    /// <param name="x">pivot collection</param>
    /// <param name="y">collection to check the diff</param>
    let difference (x : Photo Set) (y : Photo Set) = { 
        Additions = Set.difference x y;
        Removal = Set.difference y x
    }
