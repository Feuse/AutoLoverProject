    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
namespace Models
{

    public class LoginResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb1 { get; set; }

        [JsonProperty("message_type")]
        public long MessageTypeLoginResponseMOdel { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        [JsonProperty("body")]
        public List<BodyLoginResponseMOdel> Body33 { get; set; }

        [JsonProperty("responses_count")]
        public long ResponsesCount { get; set; }
    }
    [JsonObject(Title ="body")]
    public class BodyLoginResponseMOdel
    {
        [JsonProperty("$gpb")]
        public string Gpb2 { get; set; }

        [JsonProperty("client_login_success", NullValueHandling = NullValueHandling.Ignore)]
        public ClientLoginSuccess ClientLoginSuccess { get; set; }

        [JsonProperty("message_type")]
        public long MessageTypeLoginResponseMOdel2 { get; set; }

        [JsonProperty("client_common_settings", NullValueHandling = NullValueHandling.Ignore)]
        public ClientCommonSettings ClientCommonSettings { get; set; }

        [JsonProperty("app_settings", NullValueHandling = NullValueHandling.Ignore)]
        public AppSettings AppSettings { get; set; }

        [JsonProperty("comet_configuration", NullValueHandling = NullValueHandling.Ignore)]
        public CometConfiguration CometConfiguration { get; set; }

        [JsonProperty("client_spotlight_meta_data", NullValueHandling = NullValueHandling.Ignore)]
        public ClientSpotlightMetaData ClientSpotlightMetaData { get; set; }
    }

    public class AppSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb3 { get; set; }

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

    public class Menu
    {
        [JsonProperty("$gpb")]
        public string Gpb4 { get; set; }

        [JsonProperty("sections")]
        public List<Section> Sections { get; set; }
    }

    public class Section
    {
        [JsonProperty("$gpb")]
        public string Gpb5 { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        [JsonProperty("$gpb")]
        public string Gpb6 { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ClientCommonSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb7 { get; set; }

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
        public Country UserCountry { get; set; }

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

        [JsonProperty("tooltip_configs")]
        public List<TooltipConfig> TooltipConfigs { get; set; }

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
    }

    public class ClientCommonSettingsABTestingSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb8 { get; set; }

        [JsonProperty("tests")]
        public List<Test> Tests { get; set; }

        [JsonProperty("lexeme_tests")]
        public List<Test> LexemeTests { get; set; }
    }

    public class Test
    {
        [JsonProperty("$gpb")]
        public string Gpb9{ get; set; }

        [JsonProperty("test_id")]
        public string TestId { get; set; }

        [JsonProperty("variation_id")]
        public string VariationId { get; set; }

        [JsonProperty("settings_id")]

        public long SettingsId { get; set; }
    }

    public class ApplicationFeature
    {
        [JsonProperty("$gpb")]
        public string Gpb10 { get; set; }

        [JsonProperty("feature")]
        public long Feature { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("required_action", NullValueHandling = NullValueHandling.Ignore)]
        public long? RequiredAction { get; set; }

        [JsonProperty("display_title", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayTitle { get; set; }

        [JsonProperty("display_action", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayAction { get; set; }

        [JsonProperty("product_type", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProductType { get; set; }

        [JsonProperty("display_message", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayMessage { get; set; }

        [JsonProperty("payment_amount", NullValueHandling = NullValueHandling.Ignore)]
        public long? PaymentAmount { get; set; }

        [JsonProperty("goal_progress", NullValueHandling = NullValueHandling.Ignore)]
        public GoalProgress GoalProgress { get; set; }

        [JsonProperty("allow_webrtc_call_config", NullValueHandling = NullValueHandling.Ignore)]
        public AllowWebrtcCallConfig AllowWebrtcCallConfig { get; set; }
    }

    public class AllowWebrtcCallConfig
    {
        [JsonProperty("$gpb")]
        public string Gpb11 { get; set; }

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

    public class GoalProgress
    {
        [JsonProperty("$gpb")]
        public string Gpb12 { get; set; }

        [JsonProperty("goal")]
        public long Goal { get; set; }

        [JsonProperty("progress")]
        public long Progress { get; set; }
    }

    public class ChangeHost
    {
        [JsonProperty("$gpb")]
        public string Gpb13 { get; set; }

        [JsonProperty("secure_hosts")]
        public List<string> SecureHosts { get; set; }

        [JsonProperty("must_reconnect")]
        public bool MustReconnect { get; set; }

        [JsonProperty("fallback_endpoint")]
        public Uri FallbackEndpoint { get; set; }
    }

    public class ChatSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb14 { get; set; }

        [JsonProperty("max_characters_in_message")]
        public long MaxCharactersInMessage { get; set; }

        [JsonProperty("delay_before_warn_bad_blocker_ms")]
        public long DelayBeforeWarnBadBlockerMs { get; set; }

        [JsonProperty("delay_before_show_good_opener_ms")]
        public long DelayBeforeShowGoodOpenerMs { get; set; }

        [JsonProperty("audio_recording_settings")]
        public AudioRecordingSettings AudioRecordingSettings { get; set; }
    }

    public class AudioRecordingSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb15 { get; set; }

        [JsonProperty("start_recording_delay_ms")]
        public long StartRecordingDelayMs { get; set; }

        [JsonProperty("max_recording_length_ms")]
        public long MaxRecordingLengthMs { get; set; }

        [JsonProperty("audio_format")]
        public AudioFormat AudioFormat { get; set; }

        [JsonProperty("waveform_length")]
        public long WaveformLength { get; set; }
    }

    public class AudioFormat
    {
        [JsonProperty("$gpb")]
        public string Gpb16 { get; set; }

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

    public class DevFeature
    {
        [JsonProperty("$gpb")]
        public string Gpb17 { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }

    public class EncountersQueueSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb18 { get; set; }

        [JsonProperty("show_voting_buttons_for_number_of_votes")]
        public long ShowVotingButtonsForNumberOfVotes { get; set; }

        [JsonProperty("num_of_completed_votes_to_report")]
        public long NumOfCompletedVotesToReport { get; set; }
    }

    public class ExperimentalWelcomeData
    {
        [JsonProperty("$gpb")]
        public string Gpb19 { get; set; }

        [JsonProperty("total_registered_counter")]
        public long TotalRegisteredCounter { get; set; }

        [JsonProperty("total_online_counter")]
        public long TotalOnlineCounter { get; set; }
    }

    public class ExternalEndpoint
    {
        [JsonProperty("$gpb")]
        public string Gpb20 { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class GroupChatsSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb21 { get; set; }

        [JsonProperty("conversations_polling_period_sec")]
        public long ConversationsPollingPeriodSec { get; set; }

        [JsonProperty("max_num_of_participants")]
        public long MaxNumOfParticipants { get; set; }

        [JsonProperty("max_group_name_length")]
        public long MaxGroupNameLength { get; set; }
    }

    public class LivestreamSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb22 { get; set; }

        [JsonProperty("max_allowed_message_age")]
        public long MaxAllowedMessageAge { get; set; }

        [JsonProperty("connection_timeout_sec")]
        public long ConnectionTimeoutSec { get; set; }

        [JsonProperty("max_message_size")]
        public long MaxMessageSize { get; set; }

        [JsonProperty("suppress_events")]
        public List<long> SuppressEvents { get; set; }
    }

    public class PhotoUploadSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb23 { get; set; }

        [JsonProperty("min_photo_size")]
        public MaxSizeFast MinPhotoSize { get; set; }

        [JsonProperty("max_size_fast")]
        public MaxSizeFast MaxSizeFast { get; set; }

        [JsonProperty("max_size_slow")]
        public MaxSizeFast MaxSizeSlow { get; set; }
    }

    public class MaxSizeFast
    {
        [JsonProperty("$gpb")]
        public string Gpb24 { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public class PreloadAnimation
    {
        [JsonProperty("$gpb")]
        public string Gpb25 { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("format")]
        public long Format { get; set; }

        [JsonProperty("area")]
        public long Area { get; set; }

        [JsonProperty("lottie_params")]
        public LottieParams LottieParams { get; set; }
    }

    public class LottieParams
    {
        [JsonProperty("$gpb")]
        public string Gpb26 { get; set; }

        [JsonProperty("base_url")]
        public Uri BaseUrl { get; set; }

        [JsonProperty("json_url")]
        public string JsonUrl { get; set; }

        [JsonProperty("image_urls")]
        public List<string> ImageUrls { get; set; }
    }

    public class SdkIntegration
    {
        [JsonProperty("$gpb")]
        public string Gpb27 { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("app_key")]
        public string AppKey { get; set; }
    }

    public class TooltipConfig
    {
        [JsonProperty("$gpb")]
        public string Gpb28 { get; set; }

        [JsonProperty("context")]
        public long Context { get; set; }

        [JsonProperty("tooltips")]
        public List<Tooltip> Tooltips { get; set; }
    }

    public class Tooltip
    {
        [JsonProperty("$gpb")]
        public string Gpb29 { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("buttons")]
        public List<Button> Buttons { get; set; }
    }

    public class Button
    {
        [JsonProperty("$gpb")]
        public string Gpb30 { get; set; }

        [JsonProperty("action")]
        public long Action { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
    }

    public class Country
    {
        [JsonProperty("$gpb")]
        public string Gpb31 { get; set; }

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

        [JsonProperty("phone_length", NullValueHandling = NullValueHandling.Ignore)]
        public PhoneLength PhoneLength { get; set; }

        [JsonProperty("phone_prefix_length", NullValueHandling = NullValueHandling.Ignore)]
        public long? PhonePrefixLength { get; set; }

        [JsonProperty("phone_number_length", NullValueHandling = NullValueHandling.Ignore)]
        public long? PhoneNumberLength { get; set; }
    }

    public class PhoneLength
    {
        [JsonProperty("$gpb")]
        public string Gpb32 { get; set; }

        [JsonProperty("min_value")]
        public long MinValue { get; set; }

        [JsonProperty("max_value")]
        public long MaxValue { get; set; }
    }

    public class VideoUploadSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb33 { get; set; }

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

    public class Format
    {
        [JsonProperty("$gpb")]
        public string Gpb34 { get; set; }

        [JsonProperty("encoding")]
        public long Encoding { get; set; }

        [JsonProperty("max_bit_rate_kbps")]
        public long MaxBitRateKbps { get; set; }

        [JsonProperty("max_resolution")]
        public MaxSizeFast MaxResolution { get; set; }
    }

    public class WebPushInitParams
    {
        [JsonProperty("$gpb")]
        public string Gpb35 { get; set; }

        [JsonProperty("application_server_key")]
        public string ApplicationServerKey { get; set; }

        [JsonProperty("web_service_url")]
        public Uri WebServiceUrl { get; set; }

        [JsonProperty("web_site_push_id")]
        public string WebSitePushId { get; set; }

        [JsonProperty("params")]
        public List<Param> Params { get; set; }
    }

    public class Param
    {
        [JsonProperty("$gpb")]
        public string Gpb36 { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class WebSpecificOptions
    {
        [JsonProperty("$gpb")]
        public string Gpb37 { get; set; }

        [JsonProperty("open_search_filter")]
        public bool OpenSearchFilter { get; set; }

        [JsonProperty("highlight_lexemes")]
        public bool HighlightLexemes { get; set; }
    }

    public class ClientLoginSuccess
    {
        [JsonProperty("$gpb")]
        public string Gpb38 { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

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

        [JsonProperty("user_info")]
        public UserInfo UserInfo { get; set; }

        [JsonProperty("encrypted_user_id")]
        public long EncryptedUserId { get; set; }

        [JsonProperty("external_provider_token_refresh")]
        public long ExternalProviderTokenRefresh { get; set; }
    }

    public class ClientLoginSuccessABTestingSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb39 { get; set; }

        [JsonProperty("tests")]
        public List<Test> Tests { get; set; }
    }

    public class UserInfo
    {
        [JsonProperty("$gpb")]
        public string Gpb40 { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("projection")]
        public List<long> Projection { get; set; }

        [JsonProperty("client_source")]
        public long ClientSource { get; set; }

        [JsonProperty("access_level")]
        public long AccessLevel { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("profile_complete_percent")]
        public long ProfileCompletePercent { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }

        [JsonProperty("verified_information")]
        public VerifiedInformation VerifiedInformation { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }

        [JsonProperty("dob")]
        public DateTimeOffset Dob { get; set; }

        [JsonProperty("gender")]
        public long Gender { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("verification_status")]
        public long VerificationStatus { get; set; }

        [JsonProperty("photo_count")]
        public long PhotoCount { get; set; }

        [JsonProperty("profile_photo")]
        public UserInfoProfilePhotos ProfilePhoto { get; set; }

        [JsonProperty("social_networks")]
        public List<SocialNetworkResModel> SocialNetworks { get; set; }

        [JsonProperty("profile_fields")]
        public List<ProfileFieldResModel> ProfileFields { get; set; }

        [JsonProperty("popularity_level")]
        public long PopularityLevel { get; set; }

        [JsonProperty("questions_info")]
        public QuestionsInfo QuestionsInfo { get; set; }
    }

    public class City
    {
        [JsonProperty("$gpb")]
        public string Gpb41 { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Location
    {
        [JsonProperty("$gpb")]
        public string Gpb42 { get; set; }

        [JsonProperty("display_image")]
        public Uri DisplayImage { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "profile.field")]
    public class ProfileFields
    {
        [JsonProperty("$gpb")]
        public string Gpb43 { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_value")]
        public string DisplayValue { get; set; }

        [JsonProperty("required_action", NullValueHandling = NullValueHandling.Ignore)]
        public long? RequiredAction { get; set; }
    }
    [JsonObject(Title = "user.info.profile.photo")]
    public class UserInfoProfilePhotos
    {
        [JsonProperty("$gpb")]
        public string Gpb44 { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("large_url")]
        public string LargeUrl { get; set; }

        [JsonProperty("large_photo_size")]
        public MaxSizeFast LargePhotoSize { get; set; }

        [JsonProperty("face_top_left")]
        public Face4442 FaceTopLeft { get; set; }

        [JsonProperty("face_bottom_right")]
        public Face4442 FaceBottomRight { get; set; }

        [JsonProperty("preview_url_expiration_ts")]
        public long PreviewUrlExpirationTs { get; set; }

        [JsonProperty("large_url_expiration_ts")]
        public long LargeUrlExpirationTs { get; set; }
    }
    [JsonObject(Title ="face")]
    public class Face4442
    {
        [JsonProperty("$gpb")]
        public string Gpb45 { get; set; }

        [JsonProperty("x")]
        public long X2 { get; set; }

        [JsonProperty("y")]
        public long Y2 { get; set; }
    }
    [JsonObject(Title = "questions.info")]
    public class QuestionsInfo
    {
        [JsonProperty("$gpb")]
        public string Gpb46 { get; set; }

        [JsonProperty("action_promo")]
        public ActionPromos ActionPromo { get; set; }
    }
    [JsonObject(Title = "pction.promo")]
    public class ActionPromos
    {
        [JsonProperty("$gpb")]
        public string Gpb47 { get; set; }

        [JsonProperty("mssg")]
        public string Mssg { get; set; }

        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("pictures")]
        public List<Picturese> Pictures { get; set; }

        [JsonProperty("promo_block_type")]
        public long PromoBlockType { get; set; }

        [JsonProperty("promo_block_position")]
        public long PromoBlockPosition { get; set; }

        [JsonProperty("buttons")]
        public List<Button> Buttons { get; set; }
    }
    [JsonObject(Title = "picture")]
    public class Pictures
    {
        [JsonProperty("$gpb")]
        public string Gpb48 { get; set; }

        [JsonProperty("display_images")]
        public Uri DisplayImages { get; set; }
    }
    [JsonObject(Title ="social.network")]
    public class SocialNetworkResModels
    {
        [JsonProperty("$gpb")]
        public string Gpb49 { get; set; }

        [JsonProperty("external_provider")]
        public ExternalProviderResModels ExternalProvider { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("handle")]
        public string Handle { get; set; }
    }
    [Newtonsoft.Json.JsonObject(Title = "external.provider")]
    public class ExternalProviderResModels
    {
        [JsonProperty("$gpb")]
        public string Gpb50 { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }
    }

    public class VerifiedInformation
    {
        [JsonProperty("$gpb")]
        public string Gpb51 { get; set; }

        [JsonProperty("display_message")]
        public string DisplayMessage { get; set; }

        [JsonProperty("methods")]
        public List<Method> Methods { get; set; }

        [JsonProperty("verification_status")]
        public long VerificationStatus { get; set; }
    }

    public class Method
    {
        [JsonProperty("$gpb")]
        public string Gpb52 { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_message")]
        public string DisplayMessage { get; set; }

        [JsonProperty("is_connected")]
        public bool IsConnected { get; set; }

        [JsonProperty("is_confirmed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsConfirmed { get; set; }

        [JsonProperty("allow_unlink")]
        public bool AllowUnlink { get; set; }

        [JsonProperty("pin_length", NullValueHandling = NullValueHandling.Ignore)]
        public long? PinLength { get; set; }

        [JsonProperty("phone_number_verification_type", NullValueHandling = NullValueHandling.Ignore)]
        public long? PhoneNumberVerificationType { get; set; }

        [JsonProperty("allowed_switch_types", NullValueHandling = NullValueHandling.Ignore)]
        public List<long> AllowedSwitchTypes { get; set; }

        [JsonProperty("external_provider_data", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalProviderData ExternalProviderData { get; set; }

        [JsonProperty("photo_verification", NullValueHandling = NullValueHandling.Ignore)]
        public PhotoVerification PhotoVerification { get; set; }
    }

    public class ExternalProviderData
    {
        [JsonProperty("$gpb")]
        public string Gpb53 { get; set; }

        [JsonProperty("id")]
 
        public long Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("auth_data")]
        public AuthData AuthData { get; set; }

        [JsonProperty("read_permissions", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ReadPermissions { get; set; }

        [JsonProperty("profile_photo")]
        public ExternalProviderDataProfilePhoto ProfilePhoto { get; set; }

        [JsonProperty("mandatory_read_permissions", NullValueHandling = NullValueHandling.Ignore)]
        public List<Uri> MandatoryReadPermissions { get; set; }
    }

    public class AuthData
    {
        [JsonProperty("$gpb")]
        public string Gpb54 { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("oauth_url")]
        public string OauthUrl { get; set; }

        [JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("app_key", NullValueHandling = NullValueHandling.Ignore)]
        public string AppKey { get; set; }
    }

    public class ExternalProviderDataProfilePhoto
    {
        [JsonProperty("$gpb")]
        public string Gpb55 { get; set; }

        [JsonProperty("preview_url")]
        public Uri PreviewUrl { get; set; }
    }

    public class PhotoVerification
    {
        [JsonProperty("$gpb")]
        public string Gpb56 { get; set; }

        [JsonProperty("challenge")]
        public Challenge Challenge { get; set; }
    }

    public class Challenge
    {
        [JsonProperty("$gpb")]
        public string Gpb57 { get; set; }

        [JsonProperty("image_id")]
        public List<Uri> ImageId { get; set; }

        [JsonProperty("mssg")]
        public string Mssg { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("other_text")]
        public string OtherText { get; set; }

        [JsonProperty("promo_block_position")]
        public long PromoBlockPosition { get; set; }
    }

    public class ClientSpotlightMetaData
    {
        [JsonProperty("$gpb")]
        public string Gpb58 { get; set; }

        [JsonProperty("picture_domain")]
        public string PictureDomain { get; set; }

        [JsonProperty("picture_query_string")]
        public string PictureQueryString { get; set; }

        [JsonProperty("is_verification_enabled")]
        public bool IsVerificationEnabled { get; set; }

        [JsonProperty("can_view_online_status")]
        public bool CanViewOnlineStatus { get; set; }

        [JsonProperty("is_rtl")]
        public bool IsRtl { get; set; }

        [JsonProperty("spotlight_server_typed")]
        public SpotlightServerTyped SpotlightServerTyped { get; set; }
    }

    public class SpotlightServerTyped
    {
        [JsonProperty("$gpb")]
        public string Gpb59 { get; set; }

        [JsonProperty("server_id")]
        public string ServerId { get; set; }

        [JsonProperty("city_id")]
        public long CityId { get; set; }

        [JsonProperty("lang_id")]
        public long LangId { get; set; }

        [JsonProperty("platform_id")]
        public long PlatformId { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("male_tolerance")]
        public long MaleTolerance { get; set; }

        [JsonProperty("female_tolerance")]
        public long FemaleTolerance { get; set; }

        [JsonProperty("gender")]
        public long Gender { get; set; }

        [JsonProperty("revision_id")]
        public long RevisionId { get; set; }

        [JsonProperty("max_bets")]
        public long MaxBets { get; set; }
    }

    public class CometConfiguration
    {
        [JsonProperty("$gpb")]
        public string Gpb60 { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("sequence")]
        public string Sequence { get; set; }
    }


}
