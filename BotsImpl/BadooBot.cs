using Interfaces;
using Microsoft.AspNetCore.Http;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Utils;


namespace BotsImpl
{
    public class BadooBot : IBot
    {
        private int _likesLeft;
        private static IWebDriver _driver;
        private Random random;


        private const string API_URL = "https://us1.badoo.com/api.phtml";

        private const string URL = "https://badoo.com/signin";

        public BadooBot()
        {

        }
        public async Task<List<PictureUrlModel>> GetImages(string sessionId, string userId)
        {

            var jsonInput = ("{\"version\":1,\"message_type\":86,\"message_id\":56,\"body\":[{\"message_type\":86,\"server_get_album\":{\"person_id\":\"" + userId + "\",\"album_type\":2,\"preview_size\":{\"width\":180,\"height\":180}}}],\"is_background\":false}");
            List<PictureUrlModel> pictures = new List<PictureUrlModel>();
            var albumResult = await SendAndReturn(sessionId, jsonInput, userId);
            var albumModel = JsonConvert.DeserializeObject<AlbumResponseModel>(albumResult);

            var item = albumModel.Body[0];

            if (item.Album.Photos != null)
            {
                foreach (var photo in item.Album.Photos)
                {
                    PictureUrlModel url = new PictureUrlModel();
                    url.PreviewUrl = photo.PreviewUrl;
                    pictures.Add(url); ;
                }
            }


            return pictures;
        }


        public CookieModel Login(string username, string password,string? userId )
        {
            var _driver = GetSeleniumDriver();
            CookieModel badooCookie;
            random = new Random();
            try
            {
                _driver.Navigate().GoToUrl(URL);
                _driver.FindElement(By.ClassName("js-signin-login")).Clear();
                _driver.FindElement(By.ClassName("js-signin-login")).SendKeys(username);
                _driver.FindElement(By.ClassName("js-signin-password")).SendKeys(password);
                _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                //wait
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
                wait.Until(driver1 => ((IJavaScriptExecutor)_driver).ExecuteScript("return document.readyState").Equals("complete"));
                badooCookie = new CookieModel();
                OpenQA.Selenium.Cookie cookie = null;
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        var test = $"s{i}";
                        cookie = _driver.Manage().Cookies.GetCookieNamed($"s{i}");
                        if (cookie != null)
                        {
                            break;
                        }
                    }
                    catch (Exception) { }
                }
             

                badooCookie.SessionId = cookie.Value.ToString().Replace("%3A", ":");
                badooCookie.Expiry = cookie.Expiry;
                badooCookie.UserId = userId;


                if (_driver.Url == "https://badoo.com/promo/spp")
                {
                    _driver.FindElement(By.ClassName("js-spp-close")).Click();
                }
                else if (_driver.Url == URL)
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }

            return badooCookie;
        }

        public async Task<List<string>> GetCities(string input, string sessionId)
        {

            var jsonInput = "{\"version\":1,\"message_type\":29,\"message_id\":92,\"body\":[{\"message_type\":29,\"server_search_locations\":{\"with_countries\":false,\"query\":\"" + input + "\"}}],\"is_background\":false}";
            var locationResultModel = await SendAndReturn(sessionId, jsonInput, input);

            var objRes = JsonConvert.DeserializeObject<LocationResultModel>(locationResultModel);
            List<string> locationModel = new List<string>();
            foreach (var item in objRes.BodyResultModel)
            {
                if (item.ClientLocations.Locations != null)
                {
                    var locationList = item.ClientLocations.Locations;
                    foreach (var singleLocation in locationList)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(singleLocation.City.Name + " ,");
                        sb.Append(singleLocation.Region.Name + " ,");
                        sb.Append(singleLocation.Country.Name);
                        locationModel.Add(sb.ToString());
                    }
                }
            }
            return locationModel;
        }
        public async Task GetCountryId(string sessionId, string input)
        {

            var jsonInput = "{\"version\":1,\"message_type\":29,\"message_id\":92,\"body\":[{\"message_type\":29,\"server_search_locations\":{\"with_countries\":false,\"query\":\"" + input + "\"}}],\"is_background\":false}";

            var locationResultModel = await SendAndReturn(sessionId, jsonInput, input);

            var objRes = JsonConvert.DeserializeObject<LocationResultModel>(locationResultModel);

            var locationModel = new List<string>();
            foreach (var item in objRes.BodyResultModel)
            {
                if (item.ClientLocations.Locations != null)
                {
                    var locationList = item.ClientLocations.Locations;
                    foreach (var singleLocation in locationList)
                    {
                        await SaveLocation(sessionId, singleLocation.City.Id.ToString());

                    }
                }
            }
        }

        public async Task SaveLocation(string sessionId, string location)
        {

            var jsonInput = "{\"version\":1,\"message_type\":32,\"message_id\":23,\"body\":[{\"message_type\":32,\"p_integer\":{\"value\":" + location + "}}],\"is_background\":false}";
            await SendAndReturn(sessionId, jsonInput);
        }

        public async Task ChangeDescription(string sessionId, string proffesion, string companyName, string school)
        {

            string jsonInput = "{\"version\":1,\"message_type\":616,\"message_id\":26,\"body\":[{\"message_type\":616,\"server_experience_action\":{\"context\":130,\"action\":2,\"experiences\":[{\"$gpb\":\"badoo.bma.Experience\",\"id\":\"keep_only_one\",\"type\":1,\"name\":\"" + proffesion + "\",\"organization_name\":\"" + companyName + "\",\"selected\":true,\"source\":1,\"moderation_failed\":false,\"name_length_limit\":250,\"organization_name_length_limit\":30},{\"$gpb\":\"badoo.bma.Experience\",\"id\":\"keep_only_one\",\"type\":2,\"name\":\"\",\"organization_name\":\"" + school + "\",\"selected\":true,\"source\":1,\"moderation_failed\":false,\"name_length_limit\":0,\"organization_name_length_limit\":250}]}}],\"is_background\":false}";
            await SendAndReturn(sessionId, jsonInput);
        }


        public int ExecuteLikes(int mssageId, string userId, int likes, DateTime time, string sessionId)
        {

            _likesLeft = likes;

            try
            {

            }
            catch (Exception)
            {
                return _likesLeft;
            }

            return 0;
        }

        public void Like(int likes, string url)
        {
            var rand = random.Next(5, 10);
            while (_likesLeft > 0)
            {
                TimeSpan ts = TimeSpan.FromSeconds(rand);
                _driver.Manage().Timeouts().ImplicitWait = ts;


                _driver.FindElement(By.ClassName("js-profile-header-vote-yes")).Click();
                try
                {
                    var but = _driver.FindElement(By.ClassName("js-chrome-pushes-deny"));
                    but.Click();
                }
                catch (Exception)
                {


                }
                _likesLeft--;
            }
            ShutDown();
        }

        public async Task<string> SendAndReturn(string sessionId, string jsonInput, string input = "")
        {
            var json = jsonInput;
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(json);
            content.Headers.Add("X-Session-id", sessionId);
            var res = await client.PostAsync(API_URL, content);
            var rere = res.Content.ReadAsStringAsync();
            return await res.Content.ReadAsStringAsync();
        }
        private static ChromeDriver GetSeleniumDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            return new ChromeDriver(options);
        }

        public void ShutDown()
        {
            _driver.Dispose();
            _driver.Close();
        }

        public int ExecuteLikes(int _mssageId, string _userId, int _likes, Service _service, DateTime _time)
        {
            throw new NotImplementedException();
        }
    }
}
