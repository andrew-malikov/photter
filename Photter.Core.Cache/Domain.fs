module Photter.Core.Cache.Domain

type CachedPhoto = {
    Id: string;
    Width: int;
    Height: int;
    Author: string;
 }

type CachedCollection = {
    Id: string;
    CachedPhotos: CachedPhoto list
 }
