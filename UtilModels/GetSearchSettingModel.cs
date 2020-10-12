using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UtilModels
{
    public class GetSearchSettingModel : IJsonMessage
    {
        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 502;

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 8;

        [JsonProperty("body")]
        public BodyGetSearchSettingModel[] Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;
        public GetSearchSettingModel()
        {
            Body = new BodyGetSearchSettingModel[] { new BodyGetSearchSettingModel() };
        }

        public void SetProperties(string s1, string s2)
        {
            throw new NotImplementedException();
        }

        public void SetProperty(List<long> l1)
        {
            throw new NotImplementedException();
        }

        public void SetProperties(string s1, List<long> l1)
        {
            throw new NotImplementedException();
        }

        public void SetProperty(string s1)
        {
            throw new NotImplementedException();
        }

        public void SetProperties(string s1, string s2, string s3)
        {
            throw new NotImplementedException();
        }

        public void SetProperties(long s1, long s2, long s3, long[] s4)
        {
            throw new NotImplementedException();
        }
    }

    public class BodyGetSearchSettingModel
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 502;

        [JsonProperty("server_get_search_settings")]
        public ServerGetSearchSettings ServerGetSearchSettings { get; set; }
        public BodyGetSearchSettingModel()
        {
            ServerGetSearchSettings = new ServerGetSearchSettings();
        }
    }

    public class ServerGetSearchSettings
    {
        [JsonProperty("context_type")]
        public long ContextType { get; set; } = 1;
    }
}
