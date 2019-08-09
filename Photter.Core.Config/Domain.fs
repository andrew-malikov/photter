namespace Photter.Core.Config.Domain

type CertainResources = {
    files : string Set;
    folders : string Set;
 }

type Config = {
    CertainResources : CertainResources
 }

