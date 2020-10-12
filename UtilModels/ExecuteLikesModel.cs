using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilModels
{
    public class ExecuteLikesModel : IJsonMessage
    {
        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 80;

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 16;

        [JsonProperty("body")]
        public BodyExecuteLikesModel[] Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;
        public ExecuteLikesModel()
        {
            Body = new BodyExecuteLikesModel[] { new BodyExecuteLikesModel() };
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
            Body.First().ServerEncountersVote.PersonId = s1;
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

    public class BodyExecuteLikesModel
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 80;

        [JsonProperty("server_encounters_vote")]
        public ServerEncountersVoteExecuteLikesModel ServerEncountersVote { get; set; }
        public BodyExecuteLikesModel()
        {
            ServerEncountersVote = new ServerEncountersVoteExecuteLikesModel();
        }
    }

    public class ServerEncountersVoteExecuteLikesModel
    {
        [JsonProperty("person_id")]
        public string PersonId { get; set; }

        [JsonProperty("vote")]
        public long Vote { get; set; } = 2;

        [JsonProperty("photo_id")]
        public string PhotoId { get; set; }

        [JsonProperty("vote_source")]
        public long VoteSource { get; set; } = 1;
    }
}
