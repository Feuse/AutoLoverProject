using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class AppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("message_type")]
        public long MessageType { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        [JsonProperty("body")]
        public BodyAppStartupModelResponseModel[] Body { get; set; }

        [JsonProperty("responses_count")]
        public long ResponsesCount { get; set; }
    }

    public class BodyAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("client_startup", NullValueHandling = NullValueHandling.Ignore)]
        public ClientStartupAppStartupModelResponseModel ClientStartup { get; set; }

        [JsonProperty("message_type")]
        public long MessageType { get; set; }

        [JsonProperty("client_login_success", NullValueHandling = NullValueHandling.Ignore)]
        public ClientLoginSuccessAppStartupModelResponseModel ClientLoginSuccess { get; set; }

        [JsonProperty("app_settings", NullValueHandling = NullValueHandling.Ignore)]
        public AppSettingsAppStartupModelResponseModel AppSettings { get; set; }

        [JsonProperty("client_common_settings", NullValueHandling = NullValueHandling.Ignore)]
        public ClientCommonSettingsSectionAppStartupModelResponseModel ClientCommonSettings { get; set; }

        [JsonProperty("comet_configuration", NullValueHandling = NullValueHandling.Ignore)]
        public CometConfigurationAppStartupModelResponseModel CometConfiguration { get; set; }

        [JsonProperty("client_spotlight_meta_data", NullValueHandling = NullValueHandling.Ignore)]
        public ClientSpotlightMetaDataAppStartupModelResponseModel ClientSpotlightMetaData { get; set; }
    }

    public class AppSettingsAppStartupModelResponseModel
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
        public MenuAppStartupModelResponseModel Menu { get; set; }

        [JsonProperty("privacy_enable_targeted_ads")]
        public bool PrivacyEnableTargetedAds { get; set; }

        [JsonProperty("privacy_ads_state")]
        public long PrivacyAdsState { get; set; }

        [JsonProperty("context")]
        public long Context { get; set; }
    }

    public class MenuAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("sections")]
        public SectionAppStartupModelResponseModel[] Sections { get; set; }
    }

    public class SectionAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("items")]
        public ItemAppStartupModelResponseModel[] Items { get; set; }
    }

    public class ItemAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class ClientCommonSettingsSectionAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("partner_id")]
        public long PartnerId { get; set; }

        [JsonProperty("change_host")]
        public ChangeHostSectionAppStartupModelResponseModel ChangeHost { get; set; }

        [JsonProperty("language_id")]
        public long LanguageId { get; set; }

        [JsonProperty("application_features")]
        public ApplicationFeatureSectionAppStartupModelResponseModel[] ApplicationFeatures { get; set; }

        [JsonProperty("allow_review")]
        public bool AllowReview { get; set; }

        [JsonProperty("a_b_testing_settings")]
        public ABTestingSettingsSectionAppStartupModelResponseModel ABTestingSettings { get; set; }

        [JsonProperty("external_endpoints")]
        public ExternalEndpointSectionAppStartupModelResponseModel[] ExternalEndpoints { get; set; }

        [JsonProperty("dev_features")]
        public DevFeatureSectionAppStartupModelResponseModel[] DevFeatures { get; set; }

        [JsonProperty("user_country")]
        public CountryLivestreamSettings UserCountry { get; set; }

        [JsonProperty("web_specific_options")]
        public WebSpecificOptionsAppStartupModelResponseModel WebSpecificOptions { get; set; }

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
        public long[] RequiredChecks { get; set; }

        [JsonProperty("report_long_profile_view_milliseconds")]
        public long[] ReportLongProfileViewMilliseconds { get; set; }

        [JsonProperty("encounters_queue_settings")]
        public EncountersQueueSettingsSectionAppStartupModelResponseModel EncountersQueueSettings { get; set; }

        [JsonProperty("show_client_whats_new")]
        public bool ShowClientWhatsNew { get; set; }

        [JsonProperty("show_server_whats_new")]
        public bool ShowServerWhatsNew { get; set; }

        [JsonProperty("freeze_connections_enabled")]
        public bool FreezeConnectionsEnabled { get; set; }

        [JsonProperty("allow_fullscreen_photos_in_other_profiles")]
        public bool AllowFullscreenPhotosInOtherProfiles { get; set; }

        [JsonProperty("signin_providers")]
        public long[] SigninProviders { get; set; }

        [JsonProperty("photo_upload_settings")]
        public PhotoUploadSettingsLivestreamSettings PhotoUploadSettings { get; set; }

        [JsonProperty("web_push_init_params")]
        public WebPushInitParamsAppStartupModelResponseModel WebPushInitParams { get; set; }

        [JsonProperty("sdk_integrations")]
        public SdkIntegrationLivestreamSettings[] SdkIntegrations { get; set; }

        [JsonProperty("video_upload_settings")]
        public VideoUploadSettingsAppStartupModelResponseModel VideoUploadSettings { get; set; }

        [JsonProperty("chat_settings")]
        public ChatSettingsSectionAppStartupModelResponseModel ChatSettings { get; set; }

        [JsonProperty("livestream_settings")]
        public LivestreamSettingsLivestreamSettings LivestreamSettings { get; set; }

        [JsonProperty("push_offer_id")]
        public string PushOfferId { get; set; }

        [JsonProperty("email_domains")]
        public string[] EmailDomains { get; set; }

        [JsonProperty("group_chats_settings")]
        public GroupChatsSettingsSectionAppStartupModelResponseModel GroupChatsSettings { get; set; }

        [JsonProperty("live_video_settings")]
        public LiveVideoSettingsSectionAppStartupModelResponseModel LiveVideoSettings { get; set; }

        [JsonProperty("hide_your_turn_badge_after_sec")]
        public long HideYourTurnBadgeAfterSec { get; set; }

        [JsonProperty("max_number_of_login_methods")]
        public long MaxNumberOfLoginMethods { get; set; }

        [JsonProperty("experimental_welcome_data")]
        public WelcomeDataSectionAppStartupModelResponseModel ExperimentalWelcomeData { get; set; }

        [JsonProperty("experimental_show_external_ads")]
        public bool ExperimentalShowExternalAds { get; set; }
    }

    public class ABTestingSettingsSectionAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("tests")]
        public TestSectionAppStartupModelResponseModel[] Tests { get; set; }

        [JsonProperty("lexeme_tests")]
        public TestSectionAppStartupModelResponseModel[] LexemeTests { get; set; }
    }

    public class TestSectionAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("test_id")]
        public string TestId { get; set; }

        [JsonProperty("variation_id")]
        public string VariationId { get; set; }

        [JsonProperty("settings_id")]
        public long SettingsId { get; set; }
    }

    public class ApplicationFeatureSectionAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

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
        public GoalProgressSectionAppStartupModelResponseModel GoalProgress { get; set; }

        [JsonProperty("product_type", NullValueHandling = NullValueHandling.Ignore)]
        public long? ProductType { get; set; }

        [JsonProperty("payment_amount", NullValueHandling = NullValueHandling.Ignore)]
        public long? PaymentAmount { get; set; }

        [JsonProperty("allow_webrtc_call_config", NullValueHandling = NullValueHandling.Ignore)]
        public AllowWebrtcCallConfigSectionAppStartupModelResponseModel AllowWebrtcCallConfig { get; set; }
    }

    public class AllowWebrtcCallConfigSectionAppStartupModelResponseModel
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

    public class GoalProgressSectionAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("goal")]
        public long Goal { get; set; }

        [JsonProperty("progress")]
        public long Progress { get; set; }
    }

    public class ChangeHostSectionAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("secure_hosts")]
        public string[] SecureHosts { get; set; }

        [JsonProperty("must_reconnect")]
        public bool MustReconnect { get; set; }

        [JsonProperty("fallback_endpoint")]
        public Uri FallbackEndpoint { get; set; }
    }

    public class ChatSettingsSectionAppStartupModelResponseModel
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
        public AudioRecordingSettingsSectionAppStartupModelResponseModel AudioRecordingSettings { get; set; }
    }

    public class AudioRecordingSettingsSectionAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("start_recording_delay_ms")]
        public long StartRecordingDelayMs { get; set; }

        [JsonProperty("max_recording_length_ms")]
        public long MaxRecordingLengthMs { get; set; }

        [JsonProperty("audio_format")]
        public AudioFormatSectionAppStartupModelResponseModel AudioFormat { get; set; }

        [JsonProperty("waveform_length")]
        public long WaveformLength { get; set; }
    }

    public class AudioFormatSectionAppStartupModelResponseModel
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

    public class DevFeatureSectionAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }

    public class EncountersQueueSettingsSectionAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("show_voting_buttons_for_number_of_votes")]
        public long ShowVotingButtonsForNumberOfVotes { get; set; }

        [JsonProperty("num_of_completed_votes_to_report")]
        public long NumOfCompletedVotesToReport { get; set; }
    }

    public class WelcomeDataSectionAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("total_registered_counter")]
        public long TotalRegisteredCounter { get; set; }

        [JsonProperty("total_online_counter")]
        public long TotalOnlineCounter { get; set; }
    }

    public class ExternalEndpointSectionAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class GroupChatsSettingsSectionAppStartupModelResponseModel
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

    public class LiveVideoSettingsSectionAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("playback")]
        public PlaybackLivestreamSettings Playback { get; set; }

        [JsonProperty("stats_interval_sec")]
        public long StatsIntervalSec { get; set; }

        [JsonProperty("max_stats_delay_ms")]
        public long MaxStatsDelayMs { get; set; }
    }

    public class PlaybackLivestreamSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("is_default_mute")]
        public bool IsDefaultMute { get; set; }

        [JsonProperty("forward_time_sec")]
        public long ForwardTimeSec { get; set; }

        [JsonProperty("backward_time_sec")]
        public long BackwardTimeSec { get; set; }

        [JsonProperty("can_change_resolution")]
        public bool CanChangeResolution { get; set; }

        [JsonProperty("autoplay")]
        public bool Autoplay { get; set; }
    }

    public class LivestreamSettingsLivestreamSettings
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
        public long[] SuppressEvents { get; set; }
    }

    public class PhotoUploadSettingsLivestreamSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("min_photo_size")]
        public MaxSizeFastLivestreamSettings MinPhotoSize { get; set; }

        [JsonProperty("max_size_fast")]
        public MaxSizeFastLivestreamSettings MaxSizeFast { get; set; }

        [JsonProperty("max_size_slow")]
        public MaxSizeFastLivestreamSettings MaxSizeSlow { get; set; }
    }

    public class MaxSizeFastLivestreamSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public class SdkIntegrationLivestreamSettings
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("app_key")]
        public string AppKey { get; set; }
    }

    public class CountryLivestreamSettings
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

        [JsonProperty("phone_length", NullValueHandling = NullValueHandling.Ignore)]
        public PhoneLengthAppStartupModelResponseModel PhoneLength { get; set; }

        [JsonProperty("phone_prefix_length", NullValueHandling = NullValueHandling.Ignore)]
        public long? PhonePrefixLength { get; set; }

        [JsonProperty("phone_number_length", NullValueHandling = NullValueHandling.Ignore)]
        public long? PhoneNumberLength { get; set; }
    }

    public class PhoneLengthAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("min_value")]
        public long MinValue { get; set; }

        [JsonProperty("max_value")]
        public long MaxValue { get; set; }
    }

    public class VideoUploadSettingsAppStartupModelResponseModel
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
        public FormatAppStartupModelResponseModel Format { get; set; }

        [JsonProperty("max_recording_duration_sec")]
        public long MaxRecordingDurationSec { get; set; }

        [JsonProperty("audio_format")]
        public AudioFormatSectionAppStartupModelResponseModel AudioFormat { get; set; }
    }

    public class FormatAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("encoding")]
        public long Encoding { get; set; }

        [JsonProperty("max_bit_rate_kbps")]
        public long MaxBitRateKbps { get; set; }

        [JsonProperty("max_resolution")]
        public MaxSizeFastLivestreamSettings MaxResolution { get; set; }
    }

    public class WebPushInitParamsAppStartupModelResponseModel
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
        public ParamAppStartupModelResponseModel[] Params { get; set; }
    }

    public class ParamAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class WebSpecificOptionsAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("open_search_filter")]
        public bool OpenSearchFilter { get; set; }

        [JsonProperty("highlight_lexemes")]
        public bool HighlightLexemes { get; set; }
    }

    public class ClientLoginSuccessAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("deprecated_new_people")]
        public long DeprecatedNewPeople { get; set; }

        [JsonProperty("deprecated_new_messages")]
        public long DeprecatedNewMessages { get; set; }

        [JsonProperty("is_first_login")]
        public bool IsFirstLogin { get; set; }

        [JsonProperty("host")]
        public string[] Host { get; set; }

        [JsonProperty("allow_review")]
        public bool AllowReview { get; set; }

        [JsonProperty("user_info")]
        public UserInfoAppStartupModelResponseModel UserInfo { get; set; }

        [JsonProperty("encrypted_user_id")]
        public string EncryptedUserId { get; set; }

        [JsonProperty("external_provider_token_refresh")]
        public long ExternalProviderTokenRefresh { get; set; }
    }

    public class UserInfoAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("projection")]
        public long[] Projection { get; set; }

        [JsonProperty("client_source")]
        public long ClientSource { get; set; }

        [JsonProperty("access_level")]
        public long AccessLevel { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("profile_complete_percent")]
        public long ProfileCompletePercent { get; set; }

        [JsonProperty("location")]
        public LocationAppStartupModelResponseModel Location { get; set; }

        [JsonProperty("country")]
        public CountryLivestreamSettings Country { get; set; }

        [JsonProperty("city")]
        public CityAppStartupModelResponseModel City { get; set; }

        [JsonProperty("verified_information")]
        public VerifiedInformationAppStartupModelResponseModel VerifiedInformation { get; set; }

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
        public UserInfoProfilePhotoAppStartupModelResponseModel ProfilePhoto { get; set; }

        [JsonProperty("social_networks")]
        public SocialNetworkAppStartupModelResponseModel[] SocialNetworks { get; set; }

        [JsonProperty("profile_fields")]
        public ProfileFieldAppStartupModelResponseModel[] ProfileFields { get; set; }

        [JsonProperty("popularity_level")]
        public long PopularityLevel { get; set; }

        [JsonProperty("questions_info")]
        public QuestionsInfoAppStartupModelResponseModel QuestionsInfo { get; set; }
    }

    public class CityAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class LocationAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("display_image")]
        public Uri DisplayImage { get; set; }
    }

    public class ProfileFieldAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_value")]
        public string DisplayValue { get; set; }
    }

    public class UserInfoProfilePhotoAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("large_url")]
        public string LargeUrl { get; set; }

        [JsonProperty("large_photo_size")]
        public MaxSizeFastLivestreamSettings LargePhotoSize { get; set; }

        [JsonProperty("face_top_left")]
        public FaceAppStartupModelResponseModel FaceTopLeft { get; set; }

        [JsonProperty("face_bottom_right")]
        public FaceAppStartupModelResponseModel FaceBottomRight { get; set; }

        [JsonProperty("preview_url_expiration_ts")]
        public long PreviewUrlExpirationTs { get; set; }

        [JsonProperty("large_url_expiration_ts")]
        public long LargeUrlExpirationTs { get; set; }
    }

    public class FaceAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("x")]
        public long X { get; set; }

        [JsonProperty("y")]
        public long Y { get; set; }
    }

    public class QuestionsInfoAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("action_promo")]
        public ActionPromoAppStartupModelResponseModel ActionPromo { get; set; }
    }

    public class ActionPromoAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("mssg")]
        public string Mssg { get; set; }

        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("pictures")]
        public PictureAppStartupModelResponseModel[] Pictures { get; set; }

        [JsonProperty("promo_block_type")]
        public long PromoBlockType { get; set; }

        [JsonProperty("promo_block_position")]
        public long PromoBlockPosition { get; set; }

        [JsonProperty("buttons")]
        public ButtonAppStartupModelResponseModel[] Buttons { get; set; }
    }

    public class ButtonAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("action")]
        public long Action { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }
    }

    public class PictureAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("display_images")]
        public Uri DisplayImages { get; set; }
    }

    public class SocialNetworkAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("external_provider")]
        public ExternalProviderAppStartupModelResponseModel ExternalProvider { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("handle")]
        public string Handle { get; set; }
    }

    public class ExternalProviderAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }
    }

    public class VerifiedInformationAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("display_message")]
        public string DisplayMessage { get; set; }

        [JsonProperty("methods")]
        public MethodAppStartupModelResponseModel[] Methods { get; set; }

        [JsonProperty("verification_status")]
        public long VerificationStatus { get; set; }
    }

    public class MethodAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

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
        public long[] AllowedSwitchTypes { get; set; }

        [JsonProperty("external_provider_data", NullValueHandling = NullValueHandling.Ignore)]
        public ExternalProviderDataAppStartupModelResponseModel ExternalProviderData { get; set; }

        [JsonProperty("verification_data", NullValueHandling = NullValueHandling.Ignore)]
        public string VerificationData { get; set; }

        [JsonProperty("access_restrictions", NullValueHandling = NullValueHandling.Ignore)]
        public AccessRestrictionsAppStartupModelResponseModel AccessRestrictions { get; set; }

        [JsonProperty("external_account_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ExternalAccountUrl { get; set; }

        [JsonProperty("photo_verification", NullValueHandling = NullValueHandling.Ignore)]
        public PhotoVerificationAppStartupModelResponseModel PhotoVerification { get; set; }
    }

    public class AccessRestrictionsAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("available_options")]
        public long[] AvailableOptions { get; set; }

        [JsonProperty("chosen_option")]
        public long ChosenOption { get; set; }

        [JsonProperty("people_with_access")]
        public long PeopleWithAccess { get; set; }
    }

    public class ExternalProviderDataAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("auth_data")]
        public AuthDataAppStartupModelResponseModel AuthData { get; set; }

        [JsonProperty("read_permissions", NullValueHandling = NullValueHandling.Ignore)]
        public string[] ReadPermissions { get; set; }

        [JsonProperty("profile_photo")]
        public ExternalProviderDataProfilePhotoAppStartupModelResponseModel ProfilePhoto { get; set; }

        [JsonProperty("mandatory_read_permissions", NullValueHandling = NullValueHandling.Ignore)]
        public Uri[] MandatoryReadPermissions { get; set; }
    }

    public class AuthDataAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("oauth_url")]
        public string OauthUrl { get; set; }

        [JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; set; }

        [JsonProperty("app_key", NullValueHandling = NullValueHandling.Ignore)]
        public string AppKey { get; set; }
    }

    public class ExternalProviderDataProfilePhotoAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("preview_url")]
        public Uri PreviewUrl { get; set; }

        [JsonProperty("large_url")]
        public Uri LargeUrl { get; set; }

        [JsonProperty("preview_url_expiration_ts", NullValueHandling = NullValueHandling.Ignore)]
        public long? PreviewUrlExpirationTs { get; set; }

        [JsonProperty("large_url_expiration_ts", NullValueHandling = NullValueHandling.Ignore)]
        public long? LargeUrlExpirationTs { get; set; }
    }

    public class PhotoVerificationAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("challenge")]
        public ChallengeAppStartupModelResponseModel Challenge { get; set; }
    }

    public class ChallengeAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("image_id")]
        public Uri[] ImageId { get; set; }

        [JsonProperty("mssg")]
        public string Mssg { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("other_text")]
        public string OtherText { get; set; }

        [JsonProperty("promo_block_position")]
        public long PromoBlockPosition { get; set; }
    }

    public class ClientSpotlightMetaDataAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

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
        public SpotlightServerTypedAppStartupModelResponseModel SpotlightServerTyped { get; set; }
    }

    public class SpotlightServerTypedAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

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

    public class ClientStartupAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("host")]
        public string[] Host { get; set; }

        [JsonProperty("location_services")]
        public long[] LocationServices { get; set; }

        [JsonProperty("language_id")]
        public long LanguageId { get; set; }

        [JsonProperty("startup_type")]
        public long StartupType { get; set; }

        [JsonProperty("allow_review")]
        public bool AllowReview { get; set; }

        [JsonProperty("full_site_url")]
        public Uri FullSiteUrl { get; set; }

        [JsonProperty("forbid_register_via_sms")]
        public bool ForbidRegisterViaSms { get; set; }

        [JsonProperty("partner_id")]
        public long PartnerId { get; set; }

        [JsonProperty("change_host")]
        public ChangeHostSectionAppStartupModelResponseModel ChangeHost { get; set; }

        [JsonProperty("is_push_enabled")]
        public bool IsPushEnabled { get; set; }

        [JsonProperty("startup_settings")]
        public StartupSettingsAppStartupModelResponseModel StartupSettings { get; set; }

        [JsonProperty("welcome_data")]
        public WelcomeDataSectionAppStartupModelResponseModel WelcomeData { get; set; }

        [JsonProperty("platform_id")]
        public long PlatformId { get; set; }

        [JsonProperty("registration_settings")]
        public RegistrationSettingsAppStartupModelResponseModel RegistrationSettings { get; set; }
    }

    public class RegistrationSettingsAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("default_registration_method")]
        public long DefaultRegistrationMethod { get; set; }

        [JsonProperty("default_external_provider")]
        public long DefaultExternalProvider { get; set; }

        [JsonProperty("offer_marketing_subscription")]
        public bool OfferMarketingSubscription { get; set; }

        [JsonProperty("marketing_subscription_default_value")]
        public bool MarketingSubscriptionDefaultValue { get; set; }
    }

    public class StartupSettingsAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("providers")]
        public ProviderAppStartupModelResponseModel[] Providers { get; set; }
    }

    public class ProviderAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("maximumPoolSize")]
        public long MaximumPoolSize { get; set; }

        [JsonProperty("maximumTimeout")]
        public long MaximumTimeout { get; set; }

        [JsonProperty("ab_test_variant", NullValueHandling = NullValueHandling.Ignore)]
        public long? AbTestVariant { get; set; }
    }

    public class CometConfigurationAppStartupModelResponseModel
    {
        [JsonProperty("$gpb")]
        public string Gpb { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("sequence")]
        public string Sequence { get; set; }
    }
}
