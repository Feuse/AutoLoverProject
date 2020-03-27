using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public partial class SaveLocationModel
    {
        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("message_type")]
        public long MessageTypeKk { get; set; }

        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        [JsonProperty("body")]
        public List<BodySaveLocation> Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "body")]
    public partial class BodySaveLocation
    {
        [JsonProperty("message_type")]
        public long MessageTypeee { get; set; }

        [JsonProperty("p_integer")]
        public PInteger PInteger { get; set; }
    }

    public partial class PInteger
    {
        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
