namespace Photter.Infrastructure.Persistance.JsonFileService

open System
open Photter.Infrastructure.Persistance.FileRepository
open Photter.Infrastructure.Serialization.JsonSerialization

module Files =
    let get<'a> pathToFile = get deserialize<'a> pathToFile

module ProjectCache =
    open Photter.Infrastructure.Persistance.WorkDirectory

    let get<'a> (pathToFile : string) =
        get deserialize<'a> (Uri(workDirectory, pathToFile))

    let save (pathToFile : string) data =
        save serialize (Uri(workDirectory, pathToFile)) data
    
    let saveStream (pathToFile : string) stream =
        saveStream (Uri(workDirectory, pathToFile)) stream
    
    let delete (pathToFile : string) = delete (Uri(workDirectory, pathToFile))

module Project =
    open Photter.Infrastructure.Persistance.WorkDirectory

    let get<'a> (fileName : string) =
        get deserialize<'a> (Uri(workDirectory, fileName))
    
    let save (fileName : string) data =
        save serialize (Uri(workDirectory, fileName)) data
    
    let delete (fileName : string) = delete (Uri(workDirectory, fileName))
