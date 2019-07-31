module Photter.Core.Project.Domain

open System

type Photo = {
    Id : string;
    Name : string;
    Author : string;
 }

type PhotoCollection = {
    Id : string;
    PersistanceId : string;
    Photos : Photo list;
    Updated: DateTime;
 }

type Project = { Collections : PhotoCollection list }
