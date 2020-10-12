namespace BotsImpl
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class LocationResultModel
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

    public class BodyResultModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("client_locations")]
        public ClientLocationsModel ClientLocations { get; set; }

        [JsonProperty("message_type")]
        public long MessageType { get; set; }
    }

    public class ClientLocationsModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("locations")]
        public LocationModel[] Locations { get; set; }
    }

    public class LocationModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("country")]
        public CountryModel Country { get; set; }

        [JsonProperty("region")]
        public CityModel Region { get; set; }

        [JsonProperty("city")]
        public CityModel City { get; set; }
    }

    public class CityModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class CountryModel
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
        public PhoneLengthModel PhoneLength { get; set; }
    }

    public class PhoneLengthModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("min_value")]
        public long MinValue { get; set; }

        [JsonProperty("max_value")]
        public long MaxValue { get; set; }
    }

    public enum GpbModel { BadooBmaCity, BadooBmaRegion };

    
}