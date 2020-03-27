using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public partial class LoginResponse
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("message_type")]
        public long DifferentName { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        [JsonProperty("body")]
        public List<BodyLogin> Body { get; set; }

        [JsonProperty("responses_count")]
        public long ResponsesCount { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "body")]
    public partial class BodyLogin
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("client_login_success", NullValueHandling = NullValueHandling.Ignore)]
        public ClientLoginSuccess ClientLoginSuccess { get; set; }

        [JsonProperty("message_type")]
        public long RandomName { get; set; }

        [JsonProperty("client_common_settings", NullValueHandling = NullValueHandling.Ignore)]
        public ClientCommonSettings ClientCommonSettings { get; set; }

        [JsonProperty("app_settings", NullValueHandling = NullValueHandling.Ignore)]
        public AppSettings AppSettings { get; set; }

        [JsonProperty("comet_configuration", NullValueHandling = NullValueHandling.Ignore)]
        public CometConfiguration CometConfiguration { get; set; }
    }

    public partial class AppSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("interface_language")]
        public long InterfaceLanguage { get; set; }

        [JsonProperty("interface_sound")]
        public bool InterfaceSound { get; set; }

        [JsonProperty("interface_metric")]
        public bool InterfaceMetric { get; set; }

        [JsonProperty("notify_messages")]
        public bool NotifyMessages { get; set; }

        [JsonProperty("notify_visitors")]
        public bool NotifyVisitors { get; set; }

        [JsonProperty("notify_want_you")]
        public bool NotifyWantYou { get; set; }

        [JsonProperty("notify_mutual")]
        public bool NotifyMutual { get; set; }

        [JsonProperty("privacy_show_distance")]
        public bool PrivacyShowDistance { get; set; }

        [JsonProperty("notify_alerts")]
        public bool NotifyAlerts { get; set; }

        [JsonProperty("privacy_show_online_status")]
        public bool PrivacyShowOnlineStatus { get; set; }

        [JsonProperty("email_messages")]
        public bool EmailMessages { get; set; }

        [JsonProperty("email_gifts")]
        public bool EmailGifts { get; set; }

        [JsonProperty("email_alerts")]
        public bool EmailAlerts { get; set; }

        [JsonProperty("email_news")]
        public bool EmailNews { get; set; }

        [JsonProperty("email_matches")]
        public bool EmailMatches { get; set; }

        [JsonProperty("email_visitors")]
        public bool EmailVisitors { get; set; }

        [JsonProperty("notify_photoratings")]
        public bool NotifyPhotoratings { get; set; }

        [JsonProperty("email_photoratings")]
        public bool EmailPhotoratings { get; set; }

        [JsonProperty("notify_favorites")]
        public bool NotifyFavorites { get; set; }

        [JsonProperty("email_favorites")]
        public bool EmailFavorites { get; set; }

        [JsonProperty("verification_hide_details")]
        public bool VerificationHideDetails { get; set; }

        [JsonProperty("confirmation_text_for_reset_nt")]
        public string ConfirmationTextForResetNt { get; set; }

        [JsonProperty("privacy_show_in_public_search")]
        public bool PrivacyShowInPublicSearch { get; set; }

        [JsonProperty("hide_account")]
        public bool HideAccount { get; set; }

        [JsonProperty("let_other_users_share_my_profile")]
        public bool LetOtherUsersShareMyProfile { get; set; }

        [JsonProperty("privacy_show_only_to_people_i_like_or_visit")]
        public bool PrivacyShowOnlyToPeopleILikeOrVisit { get; set; }

        [JsonProperty("skip_non_moderated_alert")]
        public bool SkipNonModeratedAlert { get; set; }

        [JsonProperty("notify_gifts")]
        public bool NotifyGifts { get; set; }

        [JsonProperty("email_bumped_into")]
        public bool EmailBumpedInto { get; set; }

        [JsonProperty("email_want_you")]
        public bool EmailWantYou { get; set; }

        [JsonProperty("privacy_conceal_my_presence")]
        public bool PrivacyConcealMyPresence { get; set; }

        [JsonProperty("privacy_dont_list_me")]
        public bool PrivacyDontListMe { get; set; }

        [JsonProperty("privacy_dont_show_spp")]
        public bool PrivacyDontShowSpp { get; set; }

        [JsonProperty("contact_not_interest_action")]
        public long ContactNotInterestAction { get; set; }

        [JsonProperty("privacy_allow_search_by_email")]
        public bool PrivacyAllowSearchByEmail { get; set; }

        [JsonProperty("menu")]
        public Menu Menu { get; set; }

        [JsonProperty("privacy_enable_targeted_ads")]
        public bool PrivacyEnableTargetedAds { get; set; }

        [JsonProperty("privacy_show_me_in_lookalikes")]
        public bool PrivacyShowMeInLookalikes { get; set; }

        [JsonProperty("privacy_ads_state")]
        public long PrivacyAdsState { get; set; }

        [JsonProperty("context")]
        public long Context { get; set; }
    }

    public partial class Menu
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("sections")]
        public List<Section> Sections { get; set; }
    }

    public partial class Section
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("$gpb")]
        public ItemGpb Gpb { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class ClientCommonSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("partner_id")]
        public long PartnerId { get; set; }

        [JsonProperty("change_host")]
        public ChangeHost ChangeHost { get; set; }

        [JsonProperty("language_id")]
        public long LanguageId { get; set; }

        [JsonProperty("application_features")]
        public List<ApplicationFeature> ApplicationFeatures { get; set; }

        [JsonProperty("allow_review")]
        public bool AllowReview { get; set; }

        [JsonProperty("a_b_testing_settings")]
        public ClientCommonSettingsABTestingSettings ABTestingSettings { get; set; }

        [JsonProperty("external_endpoints")]
        public List<ExternalEndpoint> ExternalEndpoints { get; set; }

        [JsonProperty("dev_features")]
        public List<DevFeature> DevFeatures { get; set; }

        [JsonProperty("user_country")]
        public UserCountry UserCountry { get; set; }

        [JsonProperty("web_specific_options")]
        public WebSpecificOptions WebSpecificOptions { get; set; }

        [JsonProperty("phone_verification_force_pin")]
        public bool PhoneVerificationForcePin { get; set; }

        [JsonProperty("server_get_social_friends_connections_period")]
        public long ServerGetSocialFriendsConnectionsPeriod { get; set; }

        [JsonProperty("allow_facebook_like_on_review")]
        public bool AllowFacebookLikeOnReview { get; set; }

        [JsonProperty("default_unit_type")]
        public long DefaultUnitType { get; set; }

        [JsonProperty("language_iso_code")]
        public string LanguageIsoCode { get; set; }

        [JsonProperty("max_requested_users_count")]
        public long MaxRequestedUsersCount { get; set; }

        [JsonProperty("required_checks")]
        public List<long> RequiredChecks { get; set; }

        [JsonProperty("report_long_profile_view_milliseconds")]
        public List<long> ReportLongProfileViewMilliseconds { get; set; }

        [JsonProperty("encounters_queue_settings")]
        public EncountersQueueSettings EncountersQueueSettings { get; set; }

        [JsonProperty("show_client_whats_new")]
        public bool ShowClientWhatsNew { get; set; }

        [JsonProperty("show_server_whats_new")]
        public bool ShowServerWhatsNew { get; set; }

        [JsonProperty("freeze_connections_enabled")]
        public bool FreezeConnectionsEnabled { get; set; }

        [JsonProperty("allow_fullscreen_photos_in_other_profiles")]
        public bool AllowFullscreenPhotosInOtherProfiles { get; set; }

        [JsonProperty("signin_providers")]
        public List<long> SigninProviders { get; set; }

        [JsonProperty("photo_upload_settings")]
        public PhotoUploadSettings PhotoUploadSettings { get; set; }

        [JsonProperty("web_push_init_params")]
        public WebPushInitParams WebPushInitParams { get; set; }

        [JsonProperty("sdk_integrations")]
        public List<SdkIntegration> SdkIntegrations { get; set; }

        [JsonProperty("video_upload_settings")]
        public VideoUploadSettings VideoUploadSettings { get; set; }

        [JsonProperty("chat_settings")]
        public ChatSettings ChatSettings { get; set; }

        [JsonProperty("livestream_settings")]
        public LivestreamSettings LivestreamSettings { get; set; }

        [JsonProperty("preload_animations")]
        public List<PreloadAnimation> PreloadAnimations { get; set; }

        [JsonProperty("push_offer_id")]
        public string PushOfferId { get; set; }

        [JsonProperty("email_domains")]
        public List<string> EmailDomains { get; set; }

        [JsonProperty("group_chats_settings")]
        public GroupChatsSettings GroupChatsSettings { get; set; }

        [JsonProperty("experimental_welcome_data")]
        public ExperimentalWelcomeData ExperimentalWelcomeData { get; set; }

        [JsonProperty("experimental_show_external_ads")]
        public bool ExperimentalShowExternalAds { get; set; }
    }

    public partial class ClientCommonSettingsABTestingSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("tests")]
        public List<Test> Tests { get; set; }

        [JsonProperty("lexeme_tests")]
        public List<Test> LexemeTests { get; set; }
    }

    public partial class Test
    {
        [JsonProperty("$gpb")]
        public LexemeTestGpb Gpb { get; set; }

        [JsonProperty("test_id")]
        public string TestId { get; set; }

        [JsonProperty("variation_id")]
        public string VariationId { get; set; }

        [JsonProperty("settings_id")]
        public long SettingsId { get; set; }
    }

    public partial class ApplicationFeature
    {
        [JsonProperty("$gpb")]
        public ApplicationFeatureGpb Gpb { get; set; }

        [JsonProperty("feature")]
        public long Feature { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("required_action", NullValueHandling = NullValueHandling.Ignore)]
        public long? RequiredAction { get; set; }

        [JsonProperty("display_message", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayMessage { get; set; }

        [JsonProperty("display_title", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayTitle { get; set; }

        [JsonProperty("display_action", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayAction { get; set; }

        [JsonProperty("goal_progress", NullValueHandling = NullValueHandling.Ignore)]
        public GoalProgress GoalProgress { get; set; }

        [JsonProperty("product_type", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProductType { get; set; }

        [JsonProperty("payment_amount", NullValueHandling = NullValueHandling.Ignore)]
        public long? PaymentAmount { get; set; }

        [JsonProperty("allow_webrtc_call_config", NullValueHandling = NullValueHandling.Ignore)]
        public AllowWebrtcCallConfig AllowWebrtcCallConfig { get; set; }
    }

    public partial class AllowWebrtcCallConfig
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("dialing_timeout")]
        public long DialingTimeout { get; set; }

        [JsonProperty("busy_tone_length")]
        public long BusyToneLength { get; set; }

        [JsonProperty("allow_turn_off_camera")]
        public bool AllowTurnOffCamera { get; set; }

        [JsonProperty("allow_mute_mic")]
        public bool AllowMuteMic { get; set; }

        [JsonProperty("max_non_fatal_retries")]
        public long MaxNonFatalRetries { get; set; }

        [JsonProperty("state_polling_period_sec")]
        public long StatePollingPeriodSec { get; set; }
    }

    public partial class GoalProgress
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("goal")]
        public long Goal { get; set; }

        [JsonProperty("progress")]
        public long Progress { get; set; }
    }

    public partial class ChangeHost
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("secure_hosts")]
        public List<string> SecureHosts { get; set; }

        [JsonProperty("must_reconnect")]
        public bool MustReconnect { get; set; }

        [JsonProperty("fallback_endpoint")]
        public Uri FallbackEndpoint { get; set; }
    }

    public partial class ChatSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("max_characters_in_message")]
        public long MaxCharactersInMessage { get; set; }

        [JsonProperty("delay_before_warn_bad_blocker_ms")]
        public long DelayBeforeWarnBadBlockerMs { get; set; }

        [JsonProperty("delay_before_show_good_opener_ms")]
        public long DelayBeforeShowGoodOpenerMs { get; set; }

        [JsonProperty("audio_recording_settings")]
        public AudioRecordingSettings AudioRecordingSettings { get; set; }
    }

    public partial class AudioRecordingSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("start_recording_delay_ms")]
        public long StartRecordingDelayMs { get; set; }

        [JsonProperty("max_recording_length_ms")]
        public long MaxRecordingLengthMs { get; set; }

        [JsonProperty("audio_format")]
        public AudioFormat AudioFormat { get; set; }

        [JsonProperty("waveform_length")]
        public long WaveformLength { get; set; }
    }

    public partial class AudioFormat
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("sample_rate_hz")]
        public long SampleRateHz { get; set; }

        [JsonProperty("bit_rate_kbps")]
        public long BitRateKbps { get; set; }

        [JsonProperty("audio_stereo")]
        public bool AudioStereo { get; set; }

        [JsonProperty("vbr_enable")]
        public bool VbrEnable { get; set; }
    }

    public partial class DevFeature
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }

    public partial class EncountersQueueSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("show_voting_buttons_for_number_of_votes")]
        public long ShowVotingButtonsForNumberOfVotes { get; set; }

        [JsonProperty("num_of_completed_votes_to_report")]
        public long NumOfCompletedVotesToReport { get; set; }
    }

    public partial class ExperimentalWelcomeData
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("total_registered_counter")]
        public long TotalRegisteredCounter { get; set; }

        [JsonProperty("total_online_counter")]
        public long TotalOnlineCounter { get; set; }
    }

    public partial class ExternalEndpoint
    {
        [JsonProperty("$gpb")]
        public ExternalEndpointGpb Gpb { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class GroupChatsSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("conversations_polling_period_sec")]
        public long ConversationsPollingPeriodSec { get; set; }

        [JsonProperty("max_num_of_participants")]
        public long MaxNumOfParticipants { get; set; }

        [JsonProperty("max_group_name_length")]
        public long MaxGroupNameLength { get; set; }
    }

    public partial class LivestreamSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("max_allowed_message_age")]
        public long MaxAllowedMessageAge { get; set; }

        [JsonProperty("connection_timeout_sec")]
        public long ConnectionTimeoutSec { get; set; }

        [JsonProperty("max_message_size")]
        public long MaxMessageSize { get; set; }

        [JsonProperty("suppress_events")]
        public List<long> SuppressEvents { get; set; }
    }

    public partial class PhotoUploadSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("min_photo_size")]
        public MaxSizeFast MinPhotoSize { get; set; }

        [JsonProperty("max_size_fast")]
        public MaxSizeFast MaxSizeFast { get; set; }

        [JsonProperty("max_size_slow")]
        public MaxSizeFast MaxSizeSlow { get; set; }
    }

    public partial class MaxSizeFast
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public partial class PreloadAnimation
    {
        [JsonProperty("$gpb")]
        public PreloadAnimationGpb Gpb { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("format")]
        public long Format { get; set; }

        [JsonProperty("area")]
        public long Area { get; set; }

        [JsonProperty("lottie_params")]
        public LottieParams LottieParams { get; set; }
    }

    public partial class LottieParams
    {
        [JsonProperty("$gpb")]
        public LottieParamsGpb Gpb { get; set; }

        [JsonProperty("base_url")]
        public Uri BaseUrl { get; set; }

        [JsonProperty("json_url")]
        public string JsonUrl { get; set; }

        [JsonProperty("image_urls")]
        public List<string> ImageUrls { get; set; }
    }

    public partial class SdkIntegration
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("app_key")]
        public string AppKey { get; set; }
    }

    public partial class UserCountry
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone_prefix")]
        public long PhonePrefix { get; set; }

        [JsonProperty("iso_code")]
        public string IsoCode { get; set; }

        [JsonProperty("flag_symbol")]
        public string FlagSymbol { get; set; }

        [JsonProperty("phone_length")]
        public PhoneLength PhoneLength { get; set; }
    }

    public partial class PhoneLength
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("min_value")]
        public long MinValue { get; set; }

        [JsonProperty("max_value")]
        public long MaxValue { get; set; }
    }

    public partial class VideoUploadSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("min_duration")]
        public long MinDuration { get; set; }

        [JsonProperty("max_duration")]
        public long MaxDuration { get; set; }

        [JsonProperty("max_size_bytes")]
        public long MaxSizeBytes { get; set; }

        [JsonProperty("format")]
        public Format Format { get; set; }

        [JsonProperty("max_recording_duration_sec")]
        public long MaxRecordingDurationSec { get; set; }

        [JsonProperty("audio_format")]
        public AudioFormat AudioFormat { get; set; }
    }

    public partial class Format
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("encoding")]
        public long Encoding { get; set; }

        [JsonProperty("max_bit_rate_kbps")]
        public long MaxBitRateKbps { get; set; }

        [JsonProperty("max_resolution")]
        public MaxSizeFast MaxResolution { get; set; }
    }

    public partial class WebPushInitParams
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("application_server_key")]
        public string ApplicationServerKey { get; set; }

        [JsonProperty("web_service_url")]
        public Uri WebServiceUrl { get; set; }

        [JsonProperty("web_site_push_id")]
        public string WebSitePushId { get; set; }

        [JsonProperty("params")]
        public List<Param> Params { get; set; }
    }

    public partial class Param
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class WebSpecificOptions
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("open_search_filter")]
        public bool OpenSearchFilter { get; set; }

        [JsonProperty("highlight_lexemes")]
        public bool HighlightLexemes { get; set; }
    }

    public partial class ClientLoginSuccess
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("deprecated_new_people")]
        public long DeprecatedNewPeople { get; set; }

        [JsonProperty("deprecated_new_messages")]
        public long DeprecatedNewMessages { get; set; }

        [JsonProperty("language_id")]
        public long LanguageId { get; set; }

        [JsonProperty("is_first_login")]
        public bool IsFirstLogin { get; set; }

        [JsonProperty("host")]
        public List<string> Host { get; set; }

        [JsonProperty("change_host")]
        public ChangeHost ChangeHost { get; set; }

        [JsonProperty("allow_review")]
        public bool AllowReview { get; set; }

        [JsonProperty("a_b_testing_settings")]
        public ClientLoginSuccessABTestingSettings ABTestingSettings { get; set; }

        [JsonProperty("encrypted_user_id")]
        public string EncryptedUserId { get; set; }

        [JsonProperty("external_provider_token_refresh")]
        public long ExternalProviderTokenRefresh { get; set; }
    }

    public partial class ClientLoginSuccessABTestingSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("tests")]
        public List<Test> Tests { get; set; }
    }

    public partial class User
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("uid")]
        public long Uid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gender")]
        public long Gender { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("dob")]
        public DateTimeOffset Dob { get; set; }

        [JsonProperty("wish")]
        public string Wish { get; set; }

        [JsonProperty("location")]
        public long Location { get; set; }

        [JsonProperty("preview_image_id")]
        public string PreviewImageId { get; set; }

        [JsonProperty("number_of_photos")]
        public long NumberOfPhotos { get; set; }

        [JsonProperty("personal_album_id")]
        public string PersonalAlbumId { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("pending")]
        public bool Pending { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }

        [JsonProperty("friend")]
        public bool Friend { get; set; }

        [JsonProperty("favourite")]
        public bool Favourite { get; set; }

        [JsonProperty("blocked")]
        public bool Blocked { get; set; }

        [JsonProperty("profile_visited")]
        public bool ProfileVisited { get; set; }

        [JsonProperty("verified_user")]
        public bool VerifiedUser { get; set; }

        [JsonProperty("has_mobile_app")]
        public bool HasMobileApp { get; set; }

        [JsonProperty("popularity_level")]
        public long PopularityLevel { get; set; }

        [JsonProperty("available_credits")]
        public long AvailableCredits { get; set; }

        [JsonProperty("has_spp")]
        public bool HasSpp { get; set; }

        [JsonProperty("has_riseup")]
        public bool HasRiseup { get; set; }

        [JsonProperty("popularity_pnb_place")]
        public long PopularityPnbPlace { get; set; }

        [JsonProperty("popularity_visitors_today")]
        public long PopularityVisitorsToday { get; set; }

        [JsonProperty("popularity_visitors_month")]
        public long PopularityVisitorsMonth { get; set; }
    }

    public partial class CometConfiguration
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("sequence")]
        public string Sequence { get; set; }
    }

    public enum ItemGpb { BadooBmaAppSettingsMenuItem };

    public enum LexemeTestGpb { BadooBmaAbTest };

    public enum ApplicationFeatureGpb { BadooBmaApplicationFeature };

    public enum ExternalEndpointGpb { BadooBmaExternalEndpoint };

    public enum PreloadAnimationGpb { BadooBmaAnimation };

    public enum LottieParamsGpb { BadooBmaLottieAnimationParams };
}
