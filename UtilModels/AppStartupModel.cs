using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;
using System.Text;

namespace UtilModels
{
    public class AppStartupModel: IJsonMessage
    {
        [JsonProperty("version")]
        public long Version { get; set; } = 1;

        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 2;

        [JsonProperty("message_id")]
        public long MessageId { get; set; } = 1;

        [JsonProperty("body")]
        public BodyAppStartupModel[] Body { get; set; }

        [JsonProperty("is_background")]
        public bool IsBackground { get; set; } = false;
        public AppStartupModel()
        {
            Body = new BodyAppStartupModel[] { new BodyAppStartupModel() };
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

    public class BodyAppStartupModel
    {
        [JsonProperty("message_type")]
        public long MessageType { get; set; } = 2;

        [JsonProperty("server_app_startup")]
        public ServerAppStartupAppStartupModel ServerAppStartup { get; set; }
        public BodyAppStartupModel()
        {
            ServerAppStartup = new ServerAppStartupAppStartupModel();
        }
    }

    public class ServerAppStartupAppStartupModel
    {
        [JsonProperty("app_build")]
        public string AppBuild { get; set; } = "Badoo";

        [JsonProperty("app_name")]
        public string AppName { get; set; } = "hotornot";

        [JsonProperty("app_version")]
        public string AppVersion { get; set; } = "1.0.00";

        [JsonProperty("can_send_sms")]
        public bool CanSendSms { get; set; } = false;

        [JsonProperty("user_agent")]
        public string UserAgent { get; set; } = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36";

        [JsonProperty("screen_width")]
        public long ScreenWidth { get; set; } = 1920;

        [JsonProperty("screen_height")]
        public long ScreenHeight { get; set; } = 1080;

        [JsonProperty("language")]
        public long Language { get; set; } = 0;

        [JsonProperty("locale")]
        public string Locale { get; set; } = "en-US";

        [JsonProperty("app_platform_type")]
        public long AppPlatformType { get; set; } = 5;

        [JsonProperty("app_product_type")]
        public long AppProductType { get; set; } = 100;

        [JsonProperty("device_info")]
        public DeviceInfoAppStartupModel DeviceInfo { get; set; }
       
        [JsonProperty("supported_streaming_sdk")]
        public long[] SupportedStreamingSdk { get; set; } = { 3, 5, 6 };

        [JsonProperty("build_configuration")]
        public long BuildConfiguration { get; set; } = 2;

        [JsonProperty("supported_features")]
        public long[] SupportedFeatures { get; set; } = { 1, 58, 2, 4, 6, 7, 8, 172, 9, 10, 11, 13, 15, 18, 19, 20, 21, 25, 27, 28, 29, 32, 34, 35, 46, 36, 37, 39, 42, 44, 54, 62, 64, 70, 73, 75, 78, 96, 100, 103, 105, 106, 107, 108, 109, 111, 113, 114, 125, 129, 91, 116, 136, 104, 132, 142, 127, 169, 161, 183, 179, 209, 197, 248, 259, 243, 148 };
        [JsonProperty("supported_minor_features")]
        public long[] SupportedMinorFeatures { get; set; } = { 292, 444, 93, 267, 40, 41, 12, 22, 59, 61, 52, 25, 21, 74, 31, 129, 24, 19, 115, 48, 86, 90, 81, 245, 132, 118, 36, 125, 65, 143, 80, 131, 114, 251, 89, 104, 8, 135, 137, 2, 148, 83, 164, 163, 20, 171, 142, 157, 102, 139, 103, 179, 207, 180, 188, 189, 219, 202, 159, 187, 178, 136, 226, 146, 210, 169, 208, 218, 196, 122, 127, 175, 194, 134, 244, 253, 183, 214, 184, 181, 182, 259, 242, 261, 306, 130, 269, 268, 266, 313, 153, 168, 230, 63, 305, 285, 274, 348, 328, 364, 254, 291, 394, 382, 365, 403, 280, 396, 420, 470, 474, 397, 493, 483, 576, 440, 450, 548, 549, 390, 530, 391, 537, 290, 39, 115, 605, 620 };

        [JsonProperty("supported_notifications")]
        public long[] SupportedNotifications { get; set; } = { 100, 3, 25, 40, 41, 47, 50, 55, 39, 38, 42, 62, 60, 66, 76, 73, 81, 96, 98, 108, 35, 33, 44 };


        //[JsonProperty("supported_promo_blocks")]
        //public SupportedPromoBlockAppStartupModel[] SupportedPromoBlocks { get; set; }

        [JsonProperty("supported_onboarding_types")]
        public long[] SupportedOnboardingTypes { get; set; } = { 2, 1, 23, 30, 32, 33 };

        [JsonProperty("supported_server_sharing_contexts")]
        public long[] SupportedServerSharingContexts { get; set; } = { 124 };
    

        [JsonProperty("external_provider_apps")]
        public long[] ExternalProviderApps { get; set; } = { 12 };

        [JsonProperty("supported_payment_providers")]
        public long[] SupportedPaymentProviders { get; set; } = { 110004, 100, 35, 100001, 26, 102, 143, 501, 502, 170, 160 };

        [JsonProperty("supported_user_substitutes")]
        public SupportedUserSubstituteAppStartupModel[] SupportedUserSubstitutes { get; set; } = { };

        [JsonProperty("system_locale")]
        public string SystemLocale { get; set; } = "he-IL";

        [JsonProperty("build_fingerprint")]
        public string BuildFingerprint { get; set; }= "22170";

        [JsonProperty("start_source")]
        public StartSourceAppStartupModel StartSource { get; set; }

        [JsonProperty("user_field_filter_webrtc_start_call")]
        public UserFieldFilterAppStartupModel UserFieldFilterWebrtcStartCall { get; set; }

        [JsonProperty("user_field_filter_client_login_success")]
        public UserFieldFilterClientLoginSuccessAppStartupModel UserFieldFilterClientLoginSuccess { get; set; }

        [JsonProperty("user_field_filter_chat_message_from")]
        public UserFieldFilterChatMessageFromAppStartupModel UserFieldFilterChatMessageFrom { get; set; }

        [JsonProperty("hotpanel_session_id")]
        public string HotpanelSessionId { get; set; } = "aa9f5489-9575-4972-885a-23c56d176bcc";

        [JsonProperty("device_id")]
        public string DeviceId { get; set; } = "7ff6fea2-fea2-a29b-9b3f-3f44e2897478";

        [JsonProperty("a_b_testing_settings")]
        public ABTestingSettingsAppStartupModel ABTestingSettings { get; set; }

        [JsonProperty("dev_features")]
        public string[] DevFeatures { get; set; } = { };
        public ServerAppStartupAppStartupModel()
        {
            DeviceInfo = new DeviceInfoAppStartupModel();
            StartSource = new StartSourceAppStartupModel();
            UserFieldFilterWebrtcStartCall = new UserFieldFilterAppStartupModel();
            UserFieldFilterClientLoginSuccess = new UserFieldFilterClientLoginSuccessAppStartupModel();
            UserFieldFilterChatMessageFrom = new UserFieldFilterChatMessageFromAppStartupModel();
            ABTestingSettings = new ABTestingSettingsAppStartupModel();

        }
    }
    public class UserFieldFilterClientLoginSuccessAppStartupModel
    {
        [JsonProperty("projection")]
        public long[] Projection { get; set; } = {310,90,490,290,100,291,50,230,340,200,210,690,91,93,460,10,220,1000};
    }
    public class UserFieldFilterChatMessageFromAppStartupModel
    {
        [JsonProperty("projection")]
        public long[] Projection { get; set; } = { 210, 230, 200 };
    }

    public class ABTestingSettingsAppStartupModel
    {
        [JsonProperty("tests")]
        public TestAppStartupModel[] Tests { get; set; } = { new TestAppStartupModel { TestId = "badoo__web__liked_you_screen_" }, new TestAppStartupModel { TestId = "badoo_web_profile_onboarding" }, new TestAppStartupModel { TestId = "cach_first_encounter_card" }, new TestAppStartupModel { TestId = "web_chat_filter" }, new TestAppStartupModel { TestId = "badoo_web_empty_encounter_profile" }, new TestAppStartupModel { TestId = "encounter_40" }, new TestAppStartupModel { TestId = "encounter_smart_about_me" }, new TestAppStartupModel { TestId = "ie11_soft_blocker" }, new TestAppStartupModel { TestId = "log_out_instead_of_delete" }, new TestAppStartupModel { TestId = "web_fullscreen_paywall" }, new TestAppStartupModel { TestId = "new_entry_point_for_simplified_profile_quality_walk_through" }, new TestAppStartupModel { TestId = "xpdw__profile_quality_walkthrough_payer" } };
        public ABTestingSettingsAppStartupModel()
        {
           
        }
    }

    public class TestAppStartupModel
    {
        [JsonProperty("test_id")]
        public string TestId { get; set; }
    }

    public class DeviceInfoAppStartupModel
    {
        [JsonProperty("screen_density")]
        public long ScreenDensity { get; set; } = 1;

        [JsonProperty("form_factor")]
        public long FormFactor { get; set; } = 3;

        [JsonProperty("webcam_available")]
        public bool WebcamAvailable { get; set; } = false;
    }

    public class StartSourceAppStartupModel
    {
        [JsonProperty("current_url")]
        public string CurrentUrl { get; set; } = "https://badoo.com/encounters/";

        [JsonProperty("http_referrer")]
        public string HttpReferrer { get; set; } = "";
    }

    //public class SupportedPromoBlockAppStartupModel
    //{
    //    [JsonProperty("context")]
    //    public long Context { get; set; } = 0;

    //    [JsonProperty("position")]
    //    public long Position { get; set; } = 0;

    //    [JsonProperty("types")]
    //    public long[] Types { get; set; }
    //}

    public class SupportedUserSubstituteAppStartupModel
    {
        [JsonProperty("context")]
        public long Context { get; set; }

        [JsonProperty("types")]
        public long[] Types { get; set; }
    }

    public class UserFieldFilterAppStartupModel
    {
        [JsonProperty("projection")]
        public long[] Projection { get; set; } = { 200, 490 };
    }
}
