module Photter.Infrastructure.Persistance.SystemEnvironment

open System

let get byName =
    match Environment.GetEnvironmentVariable byName with
    | variable when not (isNull variable) -> Some variable
    | _ -> None


let parse<'a> (deserialize : string -> 'a) byName =
    match get byName with
    | Some variable -> variable |> deserialize |> Some
    | None -> None
