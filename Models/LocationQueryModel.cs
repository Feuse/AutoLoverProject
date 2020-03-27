using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public partial class LocationQueryModel
    {
        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("message_type")]
        public long MessageTypes { get; set; }

        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        [JsonProperty("body")]
        public List<Bodys> Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "body")]
    public partial class Bodys
    {
        [JsonProperty("message_type")]
        public long MessageTypee { get; set; }

        [JsonProperty("server_search_locations")]
        public ServerSearchLocations ServerSearchLocations { get; set; }
    }

    public partial class ServerSearchLocations
    {
        [JsonProperty("with_countries")]
        public bool WithCountries { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }
    }
}
