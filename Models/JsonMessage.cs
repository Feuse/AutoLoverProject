using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;

    using System.Globalization;


    public partial class JsonMessage
    {
        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("message_type")]
        public long MessageTypeJsonMessage { get; set; } = 616;

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 19;

        [JsonProperty("body")]
        public List<BodyMessageModel> Body { get; set; } 
        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;  
    }
    [Newtonsoft.Json.JsonObject(Title = "body")]
    public partial class BodyMessageModel
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; }

        [JsonProperty("server_experience_action")]
        public ServerExperienceAction ServerExperienceAction { get; set; }
    }

    public partial class ServerExperienceAction
    {
        [JsonProperty("context")]
        public long Context { get; set; }

        [JsonProperty("action")]
        public long Action { get; set; }

        [JsonProperty("experiences")]
        public List<Experience>Experiences { get; set; }
    }

    public partial class Experience
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("name_length_limit")]
        public long NameLengthLimit { get; set; }

        [JsonProperty("organization_name_length_limit")]
        public long OrganizationNameLengthLimit { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("organization_name")]
        public string OrganizationName { get; set; }
    }

}
