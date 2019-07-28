namespace Photter.Infrastructure.Persistence.FileService

open System

module Files =
    let get provideFile pathToFile = provideFile pathToFile

module ProjectCache =
    open Photter.Infrastructure.Persistence.WorkDirectory

    let get provideFile (pathToFile : string) = provideFile (Uri(workDirectory, pathToFile))

    let save saveFile (pathToFile : string) data =
        saveFile (Uri(workDirectory, pathToFile)) data

    let saveStream persistStream (pathToFile : string) stream =
        persistStream (Uri(workDirectory, pathToFile)) stream

    let delete deleteFile (pathToFile : string) = deleteFile (Uri(workDirectory, pathToFile))

module Project =
    open Photter.Infrastructure.Persistence.WorkDirectory

    let get provideFile (fileName : string) = provideFile (Uri(workDirectory, fileName))

    let save saveFile (fileName : string) data =
        saveFile (Uri(workDirectory, fileName)) data

    let delete deleteFile (fileName : string) = deleteFile (Uri(workDirectory, fileName))
