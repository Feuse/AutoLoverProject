using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilModels
{
    public class ChangeDescriptionModel : IJsonMessage
    {
        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 616;

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 18;

        [JsonProperty("body")]
        public BodyChangeDescriptionModel[] Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;
        public ChangeDescriptionModel()
        {
            Body = new BodyChangeDescriptionModel[] { new BodyChangeDescriptionModel() };
        }

        public void SetProperties(string username, string password)
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

        public void SetProperty(string query)
        {
            throw new NotImplementedException();
        }

        public void SetProperties(string s1, string s2, string s3)
        {
            Body.First().ServerExperienceAction.Experiences[0].Name = s1;
            Body.First().ServerExperienceAction.Experiences[0].OrganizationName = s2;
            Body.First().ServerExperienceAction.Experiences[1].OrganizationName = s3;
        }

        public void SetProperties(long s1, long s2, long s3, long[] s4)
        {
            throw new NotImplementedException();
        }
    }

    public class BodyChangeDescriptionModel
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 616;

        [JsonProperty("server_experience_action")]
        public ServerExperienceActionChangeDescriptionModel ServerExperienceAction { get; set; }
        public BodyChangeDescriptionModel()
        {
            ServerExperienceAction = new ServerExperienceActionChangeDescriptionModel();
        }
    }

    public class ServerExperienceActionChangeDescriptionModel
    {
        [JsonProperty("context")]
        public long Context { get; set; } = 130;

        [JsonProperty("action")]
        public long Action { get; set; } = 2;

        [JsonProperty("experiences")]
        public ExperienceChangeDescriptionModel[] Experiences { get; set; }
        public ServerExperienceActionChangeDescriptionModel()
        {
            Experiences = new ExperienceChangeDescriptionModel[] { 
                new ExperienceChangeDescriptionModel { Gpb ="badoo.bma.Experience",Id="keep_only_one",Type=1,Name="",OrganizationName="",Selected=true,Source=1,ModerationFailed=false,NameLengthLimit=250,OrganizationNameLengthLimit=30}
               ,new ExperienceChangeDescriptionModel { Gpb ="badoo.bma.Experience",Id="keep_only_one",Type=2,Name="",OrganizationName="",Selected=true,Source=1,ModerationFailed=false,NameLengthLimit=0,OrganizationNameLengthLimit=250} 
            };
        }
    }

    public class ExperienceChangeDescriptionModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("organization_name")]
        public string OrganizationName { get; set; }

        [JsonProperty("selected")]
        public bool Selected { get; set; }

        [JsonProperty("source")]
        public long Source { get; set; }

        [JsonProperty("moderation_failed")]
        public bool ModerationFailed { get; set; }

        [JsonProperty("name_length_limit")]
        public long NameLengthLimit { get; set; }

        [JsonProperty("organization_name_length_limit")]
        public long OrganizationNameLengthLimit { get; set; }
    }
}
