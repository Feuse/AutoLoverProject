using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilModels
{
    public class UpdateUserSearchSettings: IJsonMessage
    {
        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 503;

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 16;

        [JsonProperty("body")]
        public BodyUpdateUserSearchSettings[] Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;

        public UpdateUserSearchSettings()
        {
            Body = new BodyUpdateUserSearchSettings[] { new BodyUpdateUserSearchSettings() };
        }
        public void SetProperties(string s1, string s2)
        {
            throw new NotImplementedException();
        }

        public void SetProperties(string s1, List<long> l1)
        {
            throw new NotImplementedException();
        }

        public void SetProperties(string s1, string s2, string s3)
        {
            throw new NotImplementedException();
        }

        public void SetProperty(List<long> l1)
        {
            throw new NotImplementedException();
        }

        public void SetProperty(string s1)
        {
            throw new NotImplementedException();
        }

        public void SetProperties(long s1, long s2, long s3, long[] s4)
        {
            Body.First().ServerSaveSearchSettings.Settings.Age.Start = s1;
            Body.First().ServerSaveSearchSettings.Settings.Age.End = s2;
            Body.First().ServerSaveSearchSettings.Settings.Distance.End = s3;
            Body.First().ServerSaveSearchSettings.Settings.Gender = s4;
        }
    }

    public class BodyUpdateUserSearchSettings
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 503;

        [JsonProperty("server_save_search_settings")]
        public ServerSaveSearchSettingsUpdateUserSearchSettings ServerSaveSearchSettings { get; set; }
        public BodyUpdateUserSearchSettings()
        {
            ServerSaveSearchSettings = new ServerSaveSearchSettingsUpdateUserSearchSettings();
        }
    }

    public class ServerSaveSearchSettingsUpdateUserSearchSettings
    {
        [JsonProperty("context_type")]
        public long ContextType { get; set; } = 1;

        [JsonProperty("settings")]
        public SettingsUpdateUserSearchSettings Settings { get; set; }
        public ServerSaveSearchSettingsUpdateUserSearchSettings()
        {
            Settings = new SettingsUpdateUserSearchSettings();
        }
    }

    public class SettingsUpdateUserSearchSettings
    {
        [JsonProperty("gender")]
        public long[] Gender { get; set; }

        [JsonProperty("age")]
        public AgeUpdateUserSearchSettings Age { get; set; }

        [JsonProperty("distance")]
        public DistanceUpdateUserSearchSettings Distance { get; set; }
        public SettingsUpdateUserSearchSettings()
        {
            Age = new AgeUpdateUserSearchSettings();
            Distance = new DistanceUpdateUserSearchSettings();
        }
    }

    public class AgeUpdateUserSearchSettings
    {
        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("end")]
        public long End { get; set; }
    }

    public class DistanceUpdateUserSearchSettings
    {
        [JsonProperty("end")]
        public long End { get; set; }
    }
}
