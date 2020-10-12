using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class BadooLoginAPIModel
    {
        public class TemperaturesBadooLoginAPIModel
        {
            [JsonProperty("version")]
            public long Version { get; set; }

            [JsonProperty("message_type")]
            public long MessageType { get; set; }

            [JsonProperty("message_id")]
            public long MessageId { get; set; }

            [JsonProperty("body")]
            public BodyBadooLoginAPIModel[] Body { get; set; }

            [JsonProperty("is_background")]
            public bool IsBackground { get; set; }
        }

        public class BodyBadooLoginAPIModel
        {
            [JsonProperty("message_type")]
            public long MessageType { get; set; }

            [JsonProperty("server_login_by_password")]
            public ServerLoginByPasswordBadooLoginAPIModel ServerLoginByPassword { get; set; }
        }

        public class ServerLoginByPasswordBadooLoginAPIModel
        {
            [JsonProperty("remember_me")]
            public bool RememberMe { get; set; }

            [JsonProperty("user")]
            public string User { get; set; }

            [JsonProperty("password")]
            public string Password { get; set; }

            [JsonProperty("stats_data")]
            public string StatsData { get; set; }
        }
    }
}
