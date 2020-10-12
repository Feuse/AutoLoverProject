using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UtilModels
{
    public class StartExternalProviderImport : IJsonMessage
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; } = "badoo.bma.BadooMessage";

        [JsonProperty("body")]
        public BodyStartExternalProviderImport[] Body { get; set; }

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 23;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 364;

        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;

        public StartExternalProviderImport()
        {
            Body = new BodyStartExternalProviderImport[] { new BodyStartExternalProviderImport() };
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

        public void SetProperties(long s1, long s2, long s3, long[] s4)
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
    }

    public class BodyStartExternalProviderImport
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 364;

        [JsonProperty("server_start_external_provider_import")]
        public ServerStartExternalProviderImportStartExternalProviderImport ServerStartExternalProviderImport { get; set; }
        public BodyStartExternalProviderImport()
        {
            ServerStartExternalProviderImport = new ServerStartExternalProviderImportStartExternalProviderImport();
        }
    }

    public class ServerStartExternalProviderImportStartExternalProviderImport
    {
        [JsonProperty("auth_credentials")]
        public AuthCredentialsStartExternalProviderImport AuthCredentials { get; set; }

        [JsonProperty("start_photo_import_data")]
        public StartPhotoImportDataStartExternalProviderImport StartPhotoImportData { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; } = 20;

        [JsonProperty("allow_cache")]
        public bool AllowCache { get; set; } = false;

        [JsonProperty("context")]
        public long Context { get; set; } = 8;
        public ServerStartExternalProviderImportStartExternalProviderImport()
        {
            AuthCredentials = new AuthCredentialsStartExternalProviderImport();
            StartPhotoImportData = new StartPhotoImportDataStartExternalProviderImport();
        }
    }

    public class AuthCredentialsStartExternalProviderImport
    {
        [JsonProperty("provider_id")]
        public string ProviderId { get; set; } = "117";

        [JsonProperty("context")]
        public long Context { get; set; } = 2;
    }

    public class StartPhotoImportDataStartExternalProviderImport
    {
        [JsonProperty("album_type")]
        public long AlbumType { get; set; } = 2;

        [JsonProperty("all_albums")]
        public bool AllAlbums { get; set; } = true;
    }
}
