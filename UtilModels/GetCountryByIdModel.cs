using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilModels
{
    public class GetCountryByIdModel : IJsonMessage
    {
        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 29;

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 92;

        [JsonProperty("body")]
        public BodyGetCountryByIdModel[] Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;
        public GetCountryByIdModel()
        {
            Body = new BodyGetCountryByIdModel[] { new BodyGetCountryByIdModel() };
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
            Body.First().ServerSearchLocations.Query = s1;
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

    public class BodyGetCountryByIdModel
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 29;

        [JsonProperty("server_search_locations")]
        public ServerSearchLocationsGetCountryByIdModel ServerSearchLocations { get; set; }
        public BodyGetCountryByIdModel()
        {
            ServerSearchLocations = new ServerSearchLocationsGetCountryByIdModel();
        }
    }

    public class ServerSearchLocationsGetCountryByIdModel
    {
        [JsonProperty("with_countries")]
        public bool WithCountries { get; set; } = false;

        [JsonProperty("query")]
        public string Query { get; set; }
    }
}
