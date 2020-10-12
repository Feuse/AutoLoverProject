using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilModels
{
    public class GetExternalProviderPhotos : IJsonMessage
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; } = "badoo.bma.BadooMessage";

        [JsonProperty("body")]
        public BodyGetExternalProviderPhotosGetExternalProviderPhotos[] Body { get; set; }

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 26;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 366;

        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;
        public GetExternalProviderPhotos()
        {
            Body = new BodyGetExternalProviderPhotosGetExternalProviderPhotos[] { new BodyGetExternalProviderPhotosGetExternalProviderPhotos() };
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
            Body.First().ServerCheckExternalProviderImportProgress.ImportId = s1;
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

    public class BodyGetExternalProviderPhotosGetExternalProviderPhotos
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 366;

        [JsonProperty("server_check_external_provider_import_progress")]
        public ServerCheckExternalProviderImportProgressGetExternalProviderPhotos ServerCheckExternalProviderImportProgress { get; set; }
        public BodyGetExternalProviderPhotosGetExternalProviderPhotos()
        {
            ServerCheckExternalProviderImportProgress = new ServerCheckExternalProviderImportProgressGetExternalProviderPhotos();
        }
    }

    public class ServerCheckExternalProviderImportProgressGetExternalProviderPhotos
    {
        [JsonProperty("import_id")]
        public string ImportId { get; set; }
    }
}
