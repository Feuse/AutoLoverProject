using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class UsersResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("message_type")]
        public long MessageTypeUsersResponseModel { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        [JsonProperty("object_type")]
        public long ObjectType { get; set; }

        [JsonProperty("body")]
        public List<BodyUsersResponseModel> Body { get; set; }

        [JsonProperty("responses_count")]
        public long ResponsesCount { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; }

        [JsonProperty("vhost")]
        public string Vhost { get; set; }
    }
    [JsonObject(Title ="body")]
    public class BodyUsersResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("client_encounters")]
        public ClientEncountersResponseModel ClientEncounters { get; set; }

        [JsonProperty("message_type")]
        public long MessageType2UsersResponseModel { get; set; }
    }
    [JsonObject(Title = "client.encounters")]
    public class ClientEncountersResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }

        [JsonProperty("search_context")]
        public long SearchContext { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("quota")]
        public QuotaResponseModel Quota { get; set; }

        [JsonProperty("promo_banner")]
        public PromoBs PromoBanner { get; set; }
    }
    [JsonObject(Title = "promo.b")]
    public class PromoBs
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("mssg")]
        public string Mssg { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("ok_action")]
        public long OkAction { get; set; }

        [JsonProperty("other_text")]
        public string OtherText { get; set; }

        [JsonProperty("pictures")]
        public List<Picturese> Pictures { get; set; }

        [JsonProperty("promo_block_type")]
        public long PromoBlockType { get; set; }

        [JsonProperty("promo_block_position")]
        public long PromoBlockPosition { get; set; }

        [JsonProperty("credits_cost")]
        public string CreditsCost { get; set; }

        [JsonProperty("unique_id")]
        public string UniqueId { get; set; }

        [JsonProperty("stats_required")]
        public List<long> StatsRequired { get; set; }

        [JsonProperty("actions_changing_visibility", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> ActionsChangingVisibility { get; set; }

        [JsonProperty("redirect_page", NullValueHandling = NullValueHandling.Ignore)]
        public RedirectPagee RedirectPage { get; set; }
    }
    [JsonObject(Title = "picture")]
    public class Picturese
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("display_images")]
        public string DisplayImagesUsersResponseModel { get; set; }
    }
    [JsonObject(Title = "redirect.page")]
    public class RedirectPagee
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("redirect_page")]
        public long RedirectPageRedirectPage { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
    [JsonObject(Title = "quota")]
    public class QuotaResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("yes_votes_quota")]
        public long YesVotesQuota { get; set; }
    }
    [JsonObject(Title = "result")]
    public class Result
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("has_user_voted")]
        public bool HasUserVoted { get; set; }

        [JsonProperty("user")]
        public UserResponseModel User { get; set; }
    }
    [JsonObject(Title = "user")]
    public class UserResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("projection")]
        public List<long> Projection { get; set; }

        [JsonProperty("client_source")]
        public long ClientSource { get; set; }

        [JsonProperty("access_level")]
        public long AccessLevel { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("gender")]
        public long Gender { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("verification_status")]
        public long VerificationStatus { get; set; }

        [JsonProperty("has_spp")]
        public bool HasSpp { get; set; }

        [JsonProperty("has_riseup")]
        public bool HasRiseup { get; set; }

        [JsonProperty("video_count")]
        public long VideoCount { get; set; }

        [JsonProperty("online_status")]
        public long OnlineStatus { get; set; }

        [JsonProperty("online_status_text")]
        public string OnlineStatusText { get; set; }

        [JsonProperty("albums")]
        public List<UserResponseAlbum> Albums { get; set; }

        [JsonProperty("interests_in_common")]
        public long InterestsInCommon { get; set; }

        [JsonProperty("social_networks", NullValueHandling = NullValueHandling.Ignore)]
        public List<SocialNetworkResModel> SocialNetworks { get; set; }

        [JsonProperty("profile_fields")]
        public List<ProfileFieldResModel> ProfileFields { get; set; }

        [JsonProperty("their_vote")]
        public long TheirVote { get; set; }

        [JsonProperty("allow_chat_from_match_screen")]
        public bool AllowChatFromMatchScreen { get; set; }

        [JsonProperty("has_mobile_app")]
        public bool HasMobileApp { get; set; }

        [JsonProperty("allow_crush")]
        public bool AllowCrush { get; set; }

        [JsonProperty("allow_sharing")]
        public bool AllowSharing { get; set; }

        [JsonProperty("promo_block_after_last_photo")]
        public PromoBs PromoBlockAfterLastPhoto { get; set; }

        [JsonProperty("last_riseup_time_message", NullValueHandling = NullValueHandling.Ignore)]
        public string LastRiseupTimeMessage { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "album")]
    public class UserResponseAlbum
    {
        [JsonProperty("$gpb")]
        public string GpbUsersResponseModel { get; set; }

        [JsonProperty("uid")]
        public string UidUsersResponseModel { get; set; }

        [JsonProperty("name")]
        public string NameUsersResponseModel { get; set; }

        [JsonProperty("owner_id")]
        public string OwnerIdUsersResponseModel { get; set; }

        [JsonProperty("accessable")]
        public bool AccessableUsersResponseModel { get; set; }

        [JsonProperty("adult")]
        public bool AdultUsersResponseModel { get; set; }

        [JsonProperty("count_of_photos")]
        public long CountOfPhotosUsersResponseModel { get; set; }

        [JsonProperty("photos")]
        public List<Photo> PhotosUsersResponseModel { get; set; }

        [JsonProperty("album_type")]
        public long AlbumTypeUsersResponseModel { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "photo")]
    public class PhotoUserModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public string IdUsersResponseModel { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrlUsersResponseModel { get; set; }

        [JsonProperty("large_url")]
        public string LargeUrlUsersResponseModel { get; set; }

        [JsonProperty("large_photo_size")]
        public LargePhotoSizeAlbumResponseModel LargePhotoSizeUsersResponseModel { get; set; }

        [JsonProperty("face_top_left", NullValueHandling = NullValueHandling.Ignore)]
        public FaceResponseModel FaceTopLeftUsersResponseModel { get; set; }

        [JsonProperty("face_bottom_right", NullValueHandling = NullValueHandling.Ignore)]
        public FaceResponseModel FaceBottomRightUsersResponseModel { get; set; }

        [JsonProperty("preview_url_expiration_ts")]
        public long PreviewUrlExpirationTsUsersResponseModel { get; set; }

        [JsonProperty("large_url_expiration_ts")]
        public long LargeUrlExpirationTsUsersResponseModel { get; set; }

        [JsonProperty("video", NullValueHandling = NullValueHandling.Ignore)]
        public VideoResModel Video { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "face")]
    public class FaceResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "large.photo.size")]
    public class LargePhotoSizeResModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("width")]
        public long WidthUsersResponseModel { get; set; }

        [JsonProperty("height")]
        public long HeightUsersResponseModel { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "video")]
    public class VideoResModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("is_processing")]
        public bool IsProcessing { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "profile.field")]
    public class ProfileFieldResModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public string IdUsersResponseModel { get; set; }

        [JsonProperty("type")]
        public long TypeUsersResponseModel { get; set; }

        [JsonProperty("name")]
        public string NameUsersResponseModel { get; set; }

        [JsonProperty("display_value")]
        public string DisplayValueUsersResponseModel { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "social.network")]
    public class SocialNetworkResModel
    {
        [JsonProperty("$gpb")]
        public string Gpb3223 { get; set; }

        [JsonProperty("external_provider")]
        public ExternalProviderResModel ExternalProviderUsersResponseModel { get; set; }

        [JsonProperty("url")]
        public Uri UrlUsersResponseModel { get; set; }

        [JsonProperty("handle")]
        public string HandleUsersResponseModel { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "external.provider")]
    public class ExternalProviderResModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public long IdUsersResponseModel { get; set; }

        [JsonProperty("display_name")]
        public string DisplayNameUsersResponseModel { get; set; }

        [JsonProperty("type")]
        public long TypeUsersResponseModel { get; set; }
    }
}
