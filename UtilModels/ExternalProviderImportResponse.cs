using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UtilModels
{
    public class ExternalProviderImportResponse
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("message_type")]
        public long MessageType { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        [JsonProperty("object_type")]
        public long ObjectType { get; set; }

        [JsonProperty("body")]
        public BodyExternalProviderImportResponse[] Body { get; set; }

        [JsonProperty("responses_count")]
        public long ResponsesCount { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; }

        [JsonProperty("vhost")]
        public string Vhost { get; set; }
    }

    public partial class ExternalProviderImportProgress
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("import_id")]
        public string ImportId { get; set; }

        [JsonProperty("complete")]
        public bool Complete { get; set; }
    }
}
