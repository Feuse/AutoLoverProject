using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UtilModels
{
    public class InstagramMediaModel
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("id")]
        [Key]
        public string Id { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("media_url")]
        public string MediaUrl { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}
