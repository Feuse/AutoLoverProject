using Newtonsoft.Json;

namespace UtilModels
{
    public class BodyExternalProviderImportResponse
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("external_provider_import_progress")]
        public ExternalProviderImportProgress ExternalProviderImportProgress { get; set; }

        [JsonProperty("message_type")]
        public long MessageType { get; set; }
    }
}
