namespace Photter.Core.Config.Credentials

open Phaber.Unsplash

type CredentialsDto = { ApplicationId : string }
type CredentialsKey = string

module Project =

    let get provide (byName: CredentialsKey) =
        match provide byName with
        | Some dto -> Credentials(dto.ApplicationId, "") |> Some
        | _ -> None

module Environment =
    open Photter.Infrastructure.Persistence.SystemEnvironment

    let get (byName: CredentialsKey) =
        match get byName with
        | Some applicationId -> Credentials(applicationId, "") |> Some
        | _ -> None
