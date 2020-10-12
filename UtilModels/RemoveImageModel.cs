using Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace UtilModels
{
    public class RemoveImageModel: IJsonMessage
    {
        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 117;

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 20;

        [JsonProperty("body")]
        public BodyRemoveImageModel[] Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;
        public RemoveImageModel()
        {
            Body = new BodyRemoveImageModel[] { new BodyRemoveImageModel()};
        }

        public void SetProperties(string s1, string s2)
        {
            throw new System.NotImplementedException();
        }

        public void SetProperty(List<long> l1)
        {
            throw new System.NotImplementedException();
        }

        public void SetProperties(string s1, List<long> l1)
        {
            throw new System.NotImplementedException();
        }

        public void SetProperty(string s1)
        {
            Body.First().PString.Value = s1;
        }

        public void SetProperties(string s1, string s2, string s3)
        {
            throw new System.NotImplementedException();
        }

        public void SetProperties(long s1, long s2, long s3, long[] s4)
        {
            throw new System.NotImplementedException();
        }
    }

    public class BodyRemoveImageModel
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 117;

        [JsonProperty("p_string")]
        public PStringRemoveImageModel PString { get; set; }
        public BodyRemoveImageModel()
        {
            PString = new PStringRemoveImageModel();
        }
    }

    public class PStringRemoveImageModel
    {
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
