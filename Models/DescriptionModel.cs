using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class DescriptionModel
    {
        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("message_type")]
        public long MessageType { get; set; }

        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        [JsonProperty("body")]
        public BodyDescription[] Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; }
    }

    public class BodyDescription
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; }

        [JsonProperty("server_save_user")]
        public ServerSaveUserDescription ServerSaveUser { get; set; }
    }

    public class ServerSaveUserDescription
    {
        [JsonProperty("user")]
        public UserDescription User { get; set; }

        [JsonProperty("save_field_filter")]
        public FieldFilterDescription SaveFieldFilter { get; set; }

        [JsonProperty("return_field_filter")]
        public FieldFilterDescription ReturnFieldFilter { get; set; }
    }

    public class FieldFilterDescription
    {
        [JsonProperty("projection")]
        public long[] Projection { get; set; }
    }

    public class UserDescription
    {
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("profile_fields")]
        public ProfileFieldDescription[] ProfileFields { get; set; }
    }

    public class ProfileFieldDescription
    {
        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("display_value")]
        public string DisplayValue { get; set; }
    }
}
