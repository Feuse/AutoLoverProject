using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilModels
{
    public class GetLastEncountersModel : IJsonMessage
    {
        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 81;

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 4;

        [JsonProperty("body")]
        public BodyGetLastEncountersModel[] Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;

        public GetLastEncountersModel()
        {
            Body = new BodyGetLastEncountersModel[] { new BodyGetLastEncountersModel() };
        }

        public void SetProperty(string s1)
        {
            throw new NotImplementedException();
        }
        public void SetProperties(string s1, string s2)
        {
            throw new NotImplementedException();
        }
        public void SetProperties(string s1, List<long> l1)
        {
            Body.First().ServerGetEncounters.LastPersonId = s1;
            Body.First().ServerGetEncounters.UserFieldFilter.Projection = l1;
        }
        public void SetProperties(string s1, string s2, string s3)
        {
            throw new NotImplementedException();
        }
        public void SetProperty(List<long> l1)
        {
            throw new NotImplementedException();
        }

        public void SetProperties(long s1, long s2, long s3, long[] s4)
        {
            throw new NotImplementedException();
        }
    }

    public class BodyGetLastEncountersModel
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 81;

        [JsonProperty("server_get_encounters")]
        public ServerGetEncountersGetLastEncountersModel ServerGetEncounters { get; set; }
        public BodyGetLastEncountersModel()
        {
            ServerGetEncounters = new ServerGetEncountersGetLastEncountersModel();
        }
    }

    public class ServerGetEncountersGetLastEncountersModel
    {
        [JsonProperty("number")]
        public long Number { get; set; } = 20;

        [JsonProperty("context")]
        public long Context { get; set; } = 1;

        [JsonProperty("last_person_id")]
        public string LastPersonId { get; set; }

        [JsonProperty("user_field_filter")]
        public UserFieldFilterGetLastEncountersModel UserFieldFilter { get; set; }
        public ServerGetEncountersGetLastEncountersModel()
        {
            UserFieldFilter = new UserFieldFilterGetLastEncountersModel();
        }
    }

    public class UserFieldFilterGetLastEncountersModel
    {
        [JsonProperty("projection")]
        public List<long> Projection { get; set; }

        [JsonProperty("request_albums")]
        public RequestAlbumGetLastEncountersModel[] RequestAlbums { get; set; }

        [JsonProperty("united_friends_filter")]
        public UnitedFriendsFilterGetLastEncountersModel[] UnitedFriendsFilter { get; set; }
        public UserFieldFilterGetLastEncountersModel()
        {
            RequestAlbums = new RequestAlbumGetLastEncountersModel[] { new RequestAlbumGetLastEncountersModel() };
            UnitedFriendsFilter = new UnitedFriendsFilterGetLastEncountersModel[] { new UnitedFriendsFilterGetLastEncountersModel { Count = 5, SectionType = 3  }, new UnitedFriendsFilterGetLastEncountersModel { Count = 5, SectionType = 1 }, new UnitedFriendsFilterGetLastEncountersModel { Count = 5, SectionType = 2 } };
        }
    }

    public class RequestAlbumGetLastEncountersModel
    {
        [JsonProperty("album_type")]
        public long AlbumType { get; set; } = 7;
    }

    public class UnitedFriendsFilterGetLastEncountersModel
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("section_type")]
        public long SectionType { get; set; }
    }
}
