using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class GetSearchSettingResponseModel
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
        public BodyGetSearchSettingResponseModel[] Body { get; set; }

        [JsonProperty("responses_count")]
        public long ResponsesCount { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; }

        [JsonProperty("vhost")]
        public string Vhost { get; set; }
    }

    public class BodyGetSearchSettingResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("client_search_settings")]
        public ClientSearchSettingsGetSearchSettingResponseModel ClientSearchSettings { get; set; }

        [JsonProperty("message_type")]
        public long MessageType { get; set; }
    }

    public class ClientSearchSettingsGetSearchSettingResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("context_type")]
        public long ContextType { get; set; }

        [JsonProperty("current_settings")]
        public CurrentSettingsGetSearchSettingResponseModel CurrentSettings { get; set; }

        [JsonProperty("settings_form")]
        public SettingsFormGetSearchSettingResponseModel SettingsForm { get; set; }
    }

    public class CurrentSettingsGetSearchSettingResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("gender")]
        public long[] Gender { get; set; }

        [JsonProperty("age")]
        public AgeGetSearchSettingResponseModel Age { get; set; }

        [JsonProperty("distance")]
        public DistanceGetSearchSettingResponseModel Distance { get; set; }

        [JsonProperty("location_id")]
        public long LocationId { get; set; }

        [JsonProperty("tiw_phrase_id")]
        public long TiwPhraseId { get; set; }
    }

    public class AgeGetSearchSettingResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("end")]
        public long End { get; set; }
    }

    public class DistanceGetSearchSettingResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("end")]
        public long End { get; set; }
    }

    public class SettingsFormGetSearchSettingResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("tiw_ideas")]
        public TiwIdeaGetSearchSettingResponseModel[] TiwIdeas { get; set; }

        [JsonProperty("age_slider_settings")]
        public AgeSliderSettings AgeSliderSettings { get; set; }

        [JsonProperty("distance_slider_settings")]
        public DistanceSilderSettings DistanceSliderSettings { get; set; }

        [JsonProperty("location_name")]
        public string LocationName { get; set; }

        [JsonProperty("is_gender_hidden")]
        public bool IsGenderHidden { get; set; }

        [JsonProperty("enable_location_settings")]
        public bool EnableLocationSettings { get; set; }
    }

    [JsonObject(Title = "age_slider_settings")]
    public class AgeSliderSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("min_value")]
        public long MinValue { get; set; }

        [JsonProperty("max_value")]
        public long MaxValue { get; set; }

        [JsonProperty("step")]
        public long Step { get; set; }

        [JsonProperty("min_range")]
        public long MinRange { get; set; }

        [JsonProperty("is_left_adjustable")]
        public bool IsLeftAdjustable { get; set; }

        [JsonProperty("unit_type")]
        public long UnitType { get; set; }
    }
    [JsonObject(Title = "distance_slider_settings")]
    public class DistanceSilderSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("min_value")]
        public long MinValue { get; set; }

        [JsonProperty("max_value")]
        public long MaxValue { get; set; }

        [JsonProperty("step")]
        public long Step { get; set; }

        [JsonProperty("min_range")]
        public long MinRange { get; set; }

        [JsonProperty("is_left_adjustable")]
        public bool IsLeftAdjustable { get; set; }

        [JsonProperty("unit_type")]
        public long UnitType { get; set; }
    }

    public class TiwIdeaGetSearchSettingResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("tiw_phrase_id")]
        public long TiwPhraseId { get; set; }

        [JsonProperty("tiw_phrase")]
        public string TiwPhrase { get; set; }

        [JsonProperty("show_interested_in")]
        public bool ShowInterestedIn { get; set; }
    }
}
