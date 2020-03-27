using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public partial class AlbumRequestModel
    {
        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("message_type")]
        public long MessageType { get; set; }

        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        [JsonProperty("body")]
        public List<BodyLogin> Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; }
    }
    public partial class BodyLogin
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; }

        [JsonProperty("server_get_album")]
        public ServerGetAlbum ServerGetAlbum { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "server_get_album")]
    public partial class ServerGetAlbum
    {
        [JsonProperty("person_id")]
        public long PersonId { get; set; }

        [JsonProperty("album_type")]
        public long AlbumType { get; set; }

        [JsonProperty("preview_size")]
        public PreviewSize PreviewSize { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "preview_size")]
    public partial class PreviewSize
    {
        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }
}
