namespace Photter.Interface.Handlers

open System.CommandLine

module Domain =
    type Handler = {
        Root : Command;
        Related : Handler list;
    }

    let rec compose (composable: Handler): Command =
        let rec append handlers (command: Command) =
            match handlers with
            | handler :: rest ->
                let composed = compose handler
                
                command.AddCommand(composed)
                append rest command
            | [] -> command

        composable.Root |> 
        List.fold (fun _ handler -> append [handler] composable.Root) 
        <| composable.Related
