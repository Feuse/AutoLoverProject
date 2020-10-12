using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilModels
{
    public class GetEncountersModel : IJsonMessage
    {
        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 81;

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 14;

        [JsonProperty("body")]
        public BodyGetEncountersModel[] Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;
        public GetEncountersModel()
        {
            Body = new BodyGetEncountersModel[] { new BodyGetEncountersModel()};
        }

        public void SetProperties(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void SetProperty(List<long> l1)
        {
            Body.First().ServerGetEncounters.UserFieldFilter.Projection = l1;
        }

        public void SetProperties(string s1, List<long> l1)
        {
            throw new NotImplementedException();
        }

        public void SetProperty(string query)
        {
            throw new NotImplementedException();
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

    public class BodyGetEncountersModel
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 81;

        [JsonProperty("server_get_encounters")]
        public ServerGetEncountersGetEncountersModel ServerGetEncounters { get; set; }
        public BodyGetEncountersModel()
        {
            ServerGetEncounters = new ServerGetEncountersGetEncountersModel();
        }
    }

    public class ServerGetEncountersGetEncountersModel
    {
        [JsonProperty("number")]
        public long Number { get; set; } = 20;

        [JsonProperty("context")]
        public long Context { get; set; } = 1;

        [JsonProperty("user_field_filter")]
        public UserFieldFilterGetEncountersModel UserFieldFilter { get; set; }
        public ServerGetEncountersGetEncountersModel()
        {
            UserFieldFilter = new UserFieldFilterGetEncountersModel();
        }
    }

    public class UserFieldFilterGetEncountersModel
    {
        [JsonProperty("projection")]
        public List<long> Projection { get; set; }

        [JsonProperty("request_albums")]
        public RequestAlbumGetEncountersModel[] RequestAlbums { get; set; }

        [JsonProperty("united_friends_filter")]
        public UnitedFriendsFilterGetEncountersModel[] UnitedFriendsFilter { get; set; }
        public UserFieldFilterGetEncountersModel()
        {
            RequestAlbums = new RequestAlbumGetEncountersModel[] { new RequestAlbumGetEncountersModel() };
            UnitedFriendsFilter = new UnitedFriendsFilterGetEncountersModel[] { new UnitedFriendsFilterGetEncountersModel { Count = 5, SectionType = 3 }, new UnitedFriendsFilterGetEncountersModel { Count = 5, SectionType = 1 }, new UnitedFriendsFilterGetEncountersModel { Count = 5, SectionType = 2 } };
        }
    }

    public class RequestAlbumGetEncountersModel
    {
        [JsonProperty("album_type")]
        public long AlbumType { get; set; } = 7;
    }

    public class UnitedFriendsFilterGetEncountersModel
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("section_type")]
        public long SectionType { get; set; }
    }
}
