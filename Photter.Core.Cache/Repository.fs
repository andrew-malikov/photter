namespace Photter.Core.Cache.Repository

open Photter.Core.Cache.Domain

module Cache =
    type CacheKey = string

    let get provide (name : CacheKey) : Cache option = provide name
    let save persist (name : CacheKey) (cache : Cache) : bool = persist name cache
