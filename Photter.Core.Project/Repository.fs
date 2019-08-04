namespace Photter.Core.Project.Repository

open Photter.Core.Project.Domain

module Project =
    type ProjectKey = string

    let get provide (name: ProjectKey): Project option = provide name
    let save persist (name: ProjectKey) (project: Project): bool = persist name project 
