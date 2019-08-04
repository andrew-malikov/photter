namespace Photter.Core.Project.Service

open Photter.Core.Project.Domain

module Photos =
    open Photter.Core.Project.Domain.Photos

    type CollectionDifference = {
        Additions : Photo list;
        Removal : Photo list
    }

    /// <param name="x">pivot collection</param>
    /// <param name="y">collection to check the diff</param>
    let difference (x : Photo list) (y : Photo list) =
        let isNotExists inCollection photo =
            List.exists (equals photo) inCollection |>
            not
        let difference x y = List.filter (isNotExists y) x

        { Additions = difference x y; Removal = difference y x }
