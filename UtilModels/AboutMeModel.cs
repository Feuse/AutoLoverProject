using Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilModels
{
    public class AboutMeModel : IJsonMessage
    {
        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 405;

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 21;

        [JsonProperty("body")]
        public BodyAboutMeModel[] Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; }
        public AboutMeModel()
        {
            Body = new BodyAboutMeModel[] { new BodyAboutMeModel() };
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
            Body.FirstOrDefault().ServerSaveUser.User.ProfileFields.First().Value = s1;
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

    public class BodyAboutMeModel
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 405;

        [JsonProperty("server_save_user")]
        public ServerSaveUserAboutMeModel ServerSaveUser { get; set; }
        public BodyAboutMeModel()
        {
            ServerSaveUser = new ServerSaveUserAboutMeModel();
        }
    }

    public class ServerSaveUserAboutMeModel
    {
        [JsonProperty("user")]
        public UserAboutMeModel User { get; set; }

        [JsonProperty("save_field_filter")]
        public FieldFilterAboutMeModel SaveFieldFilter { get; set; }

        [JsonProperty("return_field_filter")]
        public FieldFilterAboutMeModel ReturnFieldFilter { get; set; }
        public ServerSaveUserAboutMeModel()
        {
            User = new UserAboutMeModel();
            SaveFieldFilter = new FieldFilterAboutMeModel() { Projection = new long[] { 490 } };
            ReturnFieldFilter = new FieldFilterAboutMeModel() { Projection = new long[] { 490, 50 } };
        }
    }

    public class FieldFilterAboutMeModel
    {
        [JsonProperty("projection")]
        public long[] Projection { get; set; }
    }

    public class UserAboutMeModel
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; } = "0767295743";

        [JsonProperty("profile_fields")]
        public ProfileFieldAboutMeModel[] ProfileFields { get; set; }
        public UserAboutMeModel()
        {
            ProfileFields = new ProfileFieldAboutMeModel[1];
            ProfileFields[0] = new ProfileFieldAboutMeModel { DisplayValue = "", Type = 2, Value = "" };
        }
       
    }

    public class ProfileFieldAboutMeModel
    {
        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("display_value")]
        public string DisplayValue { get; set; }
    }
}
