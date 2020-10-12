using Newtonsoft.Json;

namespace UtilModels
{
    public partial class ServerGetSearchSettingsGetSearchSettingModel
    {
        [JsonProperty("context_type")]
        public long ContextType { get; set; }
    }
}
