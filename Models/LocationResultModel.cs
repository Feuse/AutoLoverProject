using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{

    public partial class LocationResultModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("message_type")]
        public long MessageTyper { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        [JsonProperty("object_type")]
        public long ObjectType { get; set; }

        [JsonProperty("body")]
        public List<BodyResultModel> BodyResultModel { get; set; }

        [JsonProperty("responses_count")]
        public long ResponsesCount { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; }

        [JsonProperty("vhost")]
        public string Vhost { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "ClientLocations")]
    public partial class ClientLocationsLocation
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("locations")]
        public List<Location2> Locations { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "Location")]
    public partial class Location2
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("country")]
        public Country2 Country { get; set; }

        [JsonProperty("region")]
        public City2 Region { get; set; }

        [JsonProperty("city")]
        public City2 City { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "City")]
    public partial class City2
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "Country")]
    public partial class Country2
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone_prefix")]
        public long PhonePrefix { get; set; }

        [JsonProperty("iso_code")]
        public string IsoCode { get; set; }

        [JsonProperty("flag_symbol")]
        public string FlagSymbol { get; set; }

        [JsonProperty("phone_length")]
        public PhoneLength2 PhoneLength { get; set; }
    }

    [Newtonsoft.Json.JsonObject(Title = "PhoneLength")]
    public partial class PhoneLength2
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("min_value")]
        public long MinValue { get; set; }

        [JsonProperty("max_value")]
        public long MaxValue { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "Body")]
    public partial class BodyResultModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("client_locations")]
        public ClientLocationsLocation ClientLocations { get; set; }

        [JsonProperty("message_type")]
        public long MessageTypesea { get; set; }
    }
  
  
}
