namespace BotsImpl
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class LocationResultModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("message_type")]
        public long MessageType { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        [JsonProperty("object_type")]
        public long ObjectType { get; set; }

        [JsonProperty("body")]
        public BodyResultModel[] BodyResultModel { get; set; }

        [JsonProperty("responses_count")]
        public long ResponsesCount { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; }

        [JsonProperty("vhost")]
        public string Vhost { get; set; }
    }

    public partial class BodyResultModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("client_locations")]
        public ClientLocations ClientLocations { get; set; }

        [JsonProperty("message_type")]
        public long MessageType { get; set; }
    }

    public partial class ClientLocations
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("locations")]
        public Location[] Locations { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("region")]
        public City Region { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }

    public partial class City
    {
        [JsonProperty("$gpb")]
        public Gpb Gpb { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Country
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
        public PhoneLength PhoneLength { get; set; }
    }

    public partial class PhoneLength
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("min_value")]
        public long MinValue { get; set; }

        [JsonProperty("max_value")]
        public long MaxValue { get; set; }
    }

    public enum Gpb { BadooBmaCity, BadooBmaRegion };

    
}