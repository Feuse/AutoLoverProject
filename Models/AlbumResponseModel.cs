using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public partial class AlbumResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpbff { get; set; }

        [JsonProperty("message_type")]
        public long MessageTypeResponse { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        [JsonProperty("object_type")]
        public long ObjectType { get; set; }

        [JsonProperty("body")]
        public List<BodyRespo> Body { get; set; }

        [JsonProperty("responses_count")]
        public long ResponsesCount { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; }

        [JsonProperty("vhost")]
        public string Vhost { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "body")]
    public partial class BodyRespo
    {
        [JsonProperty("$gpb")]
        public string Gpbgg { get; set; }

        [JsonProperty("album")]
        public Album Album { get; set; }

        [JsonProperty("message_type")]
        public long MessageTypeRespons { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "album")]
    public partial class Album
    {
        [JsonProperty("$gpb")]
        public string Gpbs32 { get; set; }

        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("access_type")]
        public long AccessType { get; set; }

        [JsonProperty("accessable")]
        public bool Accessable { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("requires_moderation")]
        public bool RequiresModeration { get; set; }

        [JsonProperty("count_of_photos")]
        public long CountOfPhotos { get; set; }

        [JsonProperty("instruction")]
        public string Instruction { get; set; }

        [JsonProperty("is_upload_forbidden")]
        public bool IsUploadForbidden { get; set; }

        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }

        [JsonProperty("album_type")]
        public long AlbumType { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "photo")]
    public partial class Photo
    {
        [JsonProperty("$gpb")]
        public string Gpb4234 { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("large_url")]
        public string LargeUrl { get; set; }

        [JsonProperty("large_photo_size")]
        public LargePhotoSize LargePhotoSize { get; set; }

        [JsonProperty("face_top_left", NullValueHandling = NullValueHandling.Ignore)]
        public Face55 FaceTopLeft { get; set; }

        [JsonProperty("face_bottom_right", NullValueHandling = NullValueHandling.Ignore)]
        public Face55 FaceBottomRight { get; set; }

        [JsonProperty("can_set_as_profile_photo")]
        public bool CanSetAsProfilePhoto { get; set; }

        [JsonProperty("is_photo_of_me")]
        public bool IsPhotoOfMe { get; set; }

        [JsonProperty("is_profile_photo")]
        public bool IsProfilePhoto { get; set; }

        [JsonProperty("external_provider_source")]
        public long ExternalProviderSource { get; set; }

        [JsonProperty("is_pending_moderation")]
        public bool IsPendingModeration { get; set; }

        [JsonProperty("preview_url_expiration_ts")]
        public long PreviewUrlExpirationTs { get; set; }

        [JsonProperty("large_url_expiration_ts")]
        public long LargeUrlExpirationTs { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "face")]
    public partial class Face55
    {
        [JsonProperty("$gpb")]
        public string Gpb00 { get; set; }

        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "large_photo_size")]
    public partial class LargePhotoSize
    {
        [JsonProperty("$gpb")]
        public string Gpb4343 { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }
}
