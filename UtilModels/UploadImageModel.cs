using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilModels
{
    public class UploadImageModel : IJsonMessage
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; } = "badoo.bma.BadooMessage";
        [JsonProperty("body")]
        public BodyUploadImageModel[] Body { get; set; }
        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 28;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 495;

        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;
        public UploadImageModel()
        {
            Body = new BodyUploadImageModel[] { new BodyUploadImageModel() };
        }

        public void SetProperties(string s1, string s2)
        {
            Body.First().ServerMultiUploadPhoto.Photos.Add(new PhotoUploadImageModel { PhotoId = s1, ExternalAlbumId = "-2:" + s2 });

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
            throw new NotImplementedException();
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

    public class BodyUploadImageModel
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 495;

        [JsonProperty("server_multi_upload_photo")]
        public ServerMultiUploadPhotoUploadImageModel ServerMultiUploadPhoto { get; set; }
        public BodyUploadImageModel()
        {
            ServerMultiUploadPhoto = new ServerMultiUploadPhotoUploadImageModel();
        }
    }

    public class ServerMultiUploadPhotoUploadImageModel
    {
        [JsonProperty("album_type")]
        public long AlbumType { get; set; } = 2;

        [JsonProperty("context")]
        public long Context { get; set; } = 8;

        [JsonProperty("photos")]
        public List<PhotoUploadImageModel> Photos { get; set; }
        public ServerMultiUploadPhotoUploadImageModel()
        {
            Photos = new List<PhotoUploadImageModel>();
        }
    }

    public class PhotoUploadImageModel
    {
        [JsonProperty("photo_id")]
        public string PhotoId { get; set; }

        [JsonProperty("photo_source")]
        public long PhotoSource { get; set; } = 3;

        [JsonProperty("external_provider_id")]
        public string ExternalProviderId { get; set; } = "117";

        [JsonProperty("external_album_id")]
        public string ExternalAlbumId { get; set; }
    }
}
