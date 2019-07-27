module Photter.Infrastructure.Persistence.FileRepository

open System
open System.IO

let get<'a> (deserialize : string -> 'a) (id : Uri) =
    try
        File.ReadAllText id.AbsolutePath
        |> deserialize
        |> Some
    with :? IOException -> None

let save serialize (id : Uri) data =
    try
        File.WriteAllText(id.AbsolutePath, data |> serialize)
        true
    with :? IOException -> false

let saveStream (id : Uri) (stream : Stream) =
    try
        use fileStream = File.OpenWrite id.AbsolutePath
        stream.CopyTo fileStream
        true
    with :? IOException -> false

let delete (id : Uri) =
    try
        File.Delete id.AbsolutePath
        true
    with :? IOException -> false
