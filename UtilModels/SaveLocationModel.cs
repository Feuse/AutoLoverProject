using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilModels
{
    public class SaveLocationModel : IJsonMessage
    {
        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 32;

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 23;

        [JsonProperty("body")]
        public BodySaveLocationModel[] Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;
        public SaveLocationModel()
        {
            Body = new BodySaveLocationModel[] { new BodySaveLocationModel() };
        }

        public void SetProperties(string s1, string s2)
        {
            throw new NotImplementedException();
        }

        public void SetProperty(List<long> projections)
        {
            throw new NotImplementedException();
        }

        public void SetProperties(string s1, List<long> l1)
        {
            throw new NotImplementedException();
        }

        public void SetProperty(string s1)
        {
            Body.First().PInteger.Value = Convert.ToInt32(s1);
        }

        public void SetProperties(string proffesion, string companyName, string school)
        {
            throw new NotImplementedException();
        }

        public void SetProperties(long s1, long s2, long s3, long[] s4)
        {
            throw new NotImplementedException();
        }
    }

    public class BodySaveLocationModel
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 32;

        [JsonProperty("p_integer")]
        public PIntegerSaveLocationModel PInteger { get; set; }
        public BodySaveLocationModel()
        {
            PInteger = new PIntegerSaveLocationModel();
        }
    }

    public class PIntegerSaveLocationModel
    {
        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
