module Photter.Infrastructure.Persistance.FilePersistance

open System.IO

    let load<'a> (deserialize: string -> 'a) id =
        try
            File.ReadAllText id |> deserialize |> Some
        with
            | IOException -> None

    let save serialize id data =
        try
            File.WriteAllText(id, data |> serialize)
            true
        with
            | IOException -> false

    let saveStream id (stream: Stream) =
        try use fileStream = File.OpenWrite id
            stream.CopyTo fileStream
            true
        with
            | IOException -> false
