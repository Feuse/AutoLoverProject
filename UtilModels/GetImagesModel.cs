using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UtilModels
{
    public class GetImagesModel : IJsonMessage
    {
        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 86;

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 56;

        [JsonProperty("body")]
        public BodyGetImagesModel[] Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;
        public GetImagesModel()
        {
            Body = new BodyGetImagesModel[] { new BodyGetImagesModel() };
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

        public void SetProperties(string proffesion, string companyName, string school)
        {
            throw new NotImplementedException();
        }

        public void SetProperties(long s1, long s2, long s3, long[] s4)
        {
            throw new NotImplementedException();
        }
    }

    public class BodyGetImagesModel
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 86;

        [JsonProperty("server_get_album")]
        public ServerGetAlbumGetImagesModel ServerGetAlbum { get; set; }
        public BodyGetImagesModel()
        {
            ServerGetAlbum = new ServerGetAlbumGetImagesModel();
        }
    }

    public class ServerGetAlbumGetImagesModel
    {
        [JsonProperty("person_id")]
        public string PersonId { get; set; } = "0";

        [JsonProperty("album_type")]
        public long AlbumType { get; set; } = 2;

        [JsonProperty("preview_size")]
        public PreviewSizeGetImagesModel PreviewSize { get; set; }
        public ServerGetAlbumGetImagesModel()
        {
            PreviewSize = new PreviewSizeGetImagesModel();
        }
    }

    public class PreviewSizeGetImagesModel
    {
        [JsonProperty("width")]
        public long Width { get; set; } = 180;

        [JsonProperty("height")]
        public long Height { get; set; } = 180;
    }
}
