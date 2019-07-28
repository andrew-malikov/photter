namespace Photter.Core.Config.Credentials

open Phaber.Unsplash

type CredentialsDto = { ApplicationId : string }

module Project =
    let get provide byName =
        match provide byName with
        | Some dto -> Credentials(dto.ApplicationId, "") |> Some
        | _ -> None

module Environment =
    open Photter.Infrastructure.Persistence.SystemEnvironment

    let get byName =
        match get byName with
        | Some applicationId -> Credentials(applicationId, "") |> Some
        | _ -> None
