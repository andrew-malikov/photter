module Photter.Core.Project.Domain

open System

type PhotoCollection = {
    Id : string;
    PersistanceId : string;
    Added : DateTime;
    Updated : DateTime;
 }

type Project = { Collections : PhotoCollection list }
