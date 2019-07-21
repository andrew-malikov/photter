module Photter.Infrastructure.Serialization.JsonSerialization

open Newtonsoft.Json

let serialize data = JsonConvert.SerializeObject data
let deserialize<'a> serialized = JsonConvert.DeserializeObject<'a> serialized
