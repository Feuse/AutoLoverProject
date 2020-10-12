using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Models;
using Moq;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UtilModels;


namespace BotsImpl
{
    public class BadooBot : IBot
    {
        private readonly ILogger<BadooBot> Logger;
        private readonly ICredentialDb CredentialDb;
        private readonly IJsonFactory JsonFactory;
        private static IWebDriver Driver;
        private ServicePropertiesModel Model;
        private IMailer Mailer;
        private const string UPLOAD_PHOTO_API = "https://badoo.com/webapi.phtml?SERVER_MULTI_UPLOAD_PHOTO";
        private const string EU_API_URL = "https://eu1.badoo.com/webapi.phtml";
        private const string US_API_URL = "https://us1.badoo.com/webapi.phtml";
        private const string API_URL = "https://badoo.com/webapi.phtml";
        private const string URL = "https://badoo.com/signin";

        public BadooBot(ICredentialDb db, IJsonFactory factory, IMailer mailer, ILogger<BadooBot> logger)
        {
            Model = new ServicePropertiesModel();
            CredentialDb = db;
            JsonFactory = factory;
            Mailer = mailer;
            Logger = logger;
        }

        public async Task<List<PictureUrlModel>> GetImages(string sessionId, string userId)
        {
            IJsonMessage jsonMessage = JsonFactory.GetJson(JsonTypes.GetImages);
            string json = JsonConvert.SerializeObject(jsonMessage);

            List<PictureUrlModel> pictures = new List<PictureUrlModel>();
            var albumResult = await SendAndReturn(sessionId, json, userId);
            var albumModel = JsonConvert.DeserializeObject<AlbumResponseModel>(albumResult);

            var item = albumModel.Body[0];

            if (item.Album.Photos != null)
            {
                foreach (var photo in item.Album.Photos)
                {
                    PictureUrlModel url = new PictureUrlModel();
                    url.PreviewUrl = photo.PreviewUrl;
                    url.PhotoId = photo.Id.ToString();
                    url.Service = Service.Badoo;
                    url.UserId = userId;
                    pictures.Add(url);
                }
            }
            return pictures;
        }

        public async Task AuthenticateBadooInstagram(string sessionId)
        {
            IJsonMessage startImportMessage = JsonFactory.GetJson(JsonTypes.StartExternalProviderImport);
            string json = JsonConvert.SerializeObject(startImportMessage);
            var response = await SendAndReturn(sessionId, json);
            var responseObject = JsonConvert.DeserializeObject<ExternalProviderImportResponse>(response);

            IJsonMessage getExternalPhotos = JsonFactory.GetJson(JsonTypes.GetExternalProviderPhotos);
            getExternalPhotos.SetProperty(responseObject.Body.First().ExternalProviderImportProgress.ImportId);
            json = JsonConvert.SerializeObject(getExternalPhotos);
            await SendAndReturn(sessionId, json);
        }

        public async Task<string> UploadImage(string sessionId, List<InstagramPartialModel> images, string url)
        {
            var response = string.Empty;
            HttpClient clientAsync = new HttpClient();
            using WebClient client = new WebClient();
            client.Headers.Set("Content-Type", "image/jpeg");
            HttpContent content = new MultipartContent("undefined", sessionId);
            HttpContent content2 = new MultipartContent("album_type", "2");
            foreach (var image in images)
            {
                var fileName = image.PhotoId + ".jpeg";
                await client.DownloadFileTaskAsync(new Uri(image.ImageUrl), @"wwwroot\images\" + fileName);
                var files = Directory.GetFiles(@"wwwroot\images\", "*.jpeg");

                var filePath = Path.Combine(@"wwwroot\images\", fileName);

                using var stream = File.OpenRead(filePath);


                var file_content = new ByteArrayContent(await new StreamContent(stream).ReadAsByteArrayAsync());
                file_content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                var formData = new MultipartFormDataContent();

                formData.Add(file_content, "file", fileName);
                var res = await clientAsync.PostAsync(url, formData);
                response = await res.Content.ReadAsStringAsync();
                stream.Close();
                File.Delete(filePath);

            }

            return response;
        }


        private void UploadImageToBadoo(string[] images)
        {

            //HttpClient client = new HttpClient();
            //byte[] data;
            //using (var br = new BinaryReader(file.OpenReadStream()))
            //    data = br.ReadBytes((int)file.OpenReadStream().Length);

            //ByteArrayContent bytes = new ByteArrayContent(data);


            //MultipartFormDataContent multiContent = new MultipartFormDataContent();

            //multiContent.Add(bytes, "file", file.FileName);

            //var result = client.PostAsync("api/Values", multiContent).Result;
        }

        public async Task RemoveImage(string sessionId, string msgId)
        {
            IJsonMessage jsonMessage = JsonFactory.GetJson(JsonTypes.RemoveImage);
            jsonMessage.SetProperty(msgId);
            string json = JsonConvert.SerializeObject(jsonMessage);
            await SendAndReturn(sessionId, json);

        }
        public async Task<LoginResponseModel> GetUser(string sessionId)
        {
            IJsonMessage jsonMessage = JsonFactory.GetJson(JsonTypes.AppStartupModel);
            string json = JsonConvert.SerializeObject(jsonMessage);
            var userResult = await SendAndReturn(sessionId, json);
            var serializedUserObj = JsonConvert.DeserializeObject<LoginResponseModel>(userResult);

            return serializedUserObj;
        }
        public async Task<AppStartupModelResponseModel> GetStartupUser(string sessionId)
        {
            IJsonMessage jsonMessage = JsonFactory.GetJson(JsonTypes.AppStartupModel);
            string json = JsonConvert.SerializeObject(jsonMessage);
            var userResult = await SendAndReturn(sessionId, json);
            var serializedUserObj = JsonConvert.DeserializeObject<AppStartupModelResponseModel>(userResult);

            return serializedUserObj;
        }
        public async Task<GetSearchSettingResponseModel> GetUserSettings(string sessionId)
        {
            IJsonMessage jsonMessage = JsonFactory.GetJson(JsonTypes.GetSearchSettings);
            string json = JsonConvert.SerializeObject(jsonMessage);
            var userResult = await SendAndReturn(sessionId, json);
            var serializedUserObj = JsonConvert.DeserializeObject<GetSearchSettingResponseModel>(userResult);


            return serializedUserObj;

        }

        public async Task UpdateUserSearchSettings(long ageStart, long ageEnd, long distance, long[] genders, string sessionId)
        {
            IJsonMessage jsonMessage = JsonFactory.GetJson(JsonTypes.UpdateUserSearchSettings);
            jsonMessage.SetProperties(ageStart, ageEnd, distance, genders);
            var json = JsonConvert.SerializeObject(jsonMessage);
            await SendAndReturn(sessionId, json);
            //not checkeds
        }

        public async Task<LocalProjectionModel> LoginWithApi(string username, string password, string? sessionId)
        {
            string loginResult = string.Empty;
            LocalProjectionModel projectionModel = new LocalProjectionModel();
            IJsonMessage jsonMessage = JsonFactory.GetJson(JsonTypes.Login);
            jsonMessage.SetProperties(username, password);
            var json = JsonConvert.SerializeObject(jsonMessage);

            while (!loginResult.Contains("user_info"))
            {
                loginResult = await SendAndReturn(sessionId, json);
            }
            try
            {
                var objRes = JsonConvert.DeserializeObject<LoginResponseModel>(loginResult);

                // The body33 list always only has 1 item

                projectionModel.Projections = objRes.Body33.First().ClientLoginSuccess.UserInfo.Projection;
                projectionModel.UserId = objRes.Body33.First().ClientLoginSuccess.UserInfo.UserId.ToString();
                var serialized = JsonConvert.SerializeObject(projectionModel.Projections);
                jsonMessage = JsonFactory.GetJson(JsonTypes.GetEncounters);
                jsonMessage.SetProperty(projectionModel.Projections);
                json = JsonConvert.SerializeObject(jsonMessage);
                var getUsersResult = await SendAndReturn(sessionId, json);

                if (!getUsersResult.Contains("no_more_search_results"))
                {
                    var usersRes = JsonConvert.DeserializeObject<UsersResponseModel>(getUsersResult);
                    projectionModel.UsersIds = usersRes.Body.First().ClientEncounters.Results.Select(i => i.User.UserId).ToList();

                }
                else
                {
                    throw new Exception("send email to user: No more connections, change search properties.");
                }

            }
            catch (Exception)
            {

                throw new Exception("send email to user: No more connections, change search properties | FROM CATCH BLOCK.");
            }

            projectionModel.time = DateTime.Now;
            return projectionModel;
        }

        public CookieModel Login(string username, string password, string userId)
        {
            Driver = null;

            Driver = GetSeleniumDriver();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            CookieModel badooCookie = new CookieModel();
            if (Driver.Url.Contains("encounters"))
            {
                return getBadooSiteCookie(userId, badooCookie, wait);
            }
            else
            {
                try
                {
                    Driver.Navigate().GoToUrl(URL);
                    Driver.FindElement(By.ClassName("js-signin-login")).Clear();
                    Driver.FindElement(By.ClassName("js-signin-login")).SendKeys(username);
                    Driver.FindElement(By.ClassName("js-signin-password")).SendKeys(password);
                    Driver.FindElement(By.XPath("//button[@type='submit']")).Click();

                    wait.Until(driver1 => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));

                    //check if there was a login error, if so send email of the error to the user.

                    try
                    {
                        wait.Until(driver1 => (driver1.FindElement(By.ClassName("new-form__error"))));
                        try
                        {
                            if (Driver.FindElement(By.ClassName("new-form__error")).Text != "")
                            {
                                var error = Driver.FindElement(By.ClassName("new-form__error")).Text;
                                var user = CredentialDb.GetById(userId);
                                Mailer.SendEmailAsync(user.Username, "AutoLover Message", error);
                                Logger.LogInformation("username" + username + "had the following login error: " + error);
                            }
                            else
                            {              
                                wait.Until(driver => Driver.Url.Contains("encounters"));
                                badooCookie = getBadooSiteCookie(userId, badooCookie, wait);
                                if (Driver.Url == "https://badoo.com/promo/spp")
                                {
                                    Driver.FindElement(By.ClassName("js-spp-close")).Click();
                                }
                                else if (Driver.Url == URL)
                                {
                                    return null;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Logger.LogInformation(e.Message);
                        }
                    }
                    catch (Exception e)
                    {
                        Logger.LogInformation(e.Message);
                    }
                }
                catch (Exception e)
                {
                    Logger.LogInformation(e.Message);
                }
            }
            return badooCookie;
        }
        public async Task<List<string>> GetCities(string input, string sessionId)
        {
            //var jsonInput = "{\"version\":1,\"message_type\":29,\"message_id\":92,\"body\":[{\"message_type\":29,\"server_search_locations\":{\"with_countries\":false,\"query\":\"" + input + "\"}}],\"is_background\":false}";
            IJsonMessage jsonMessage = JsonFactory.GetJson(JsonTypes.GetCities);
            jsonMessage.SetProperty(input);
            string json = JsonConvert.SerializeObject(jsonMessage);
            var locationResultModel = await SendAndReturn(sessionId, json, input);

            var objRes = JsonConvert.DeserializeObject<LocationResultModel>(locationResultModel);
            List<string> locationModel = new List<string>();
            var reponseBody = objRes.BodyResultModel.First();
            try
            {
                if (reponseBody.ClientLocations.Locations != null)
                {
                    foreach (var singleLocation in reponseBody.ClientLocations.Locations)
                    {
                        string newLocation = $"{singleLocation.City.Name}, {singleLocation.Region.Name}, {singleLocation.Country.Name}";
                        locationModel.Add(newLocation);
                    }
                }
            }
            catch (Exception e )
            {
                Logger.LogInformation(e.Message);
            }
           

            return locationModel;
        }
        public async Task GetCountryId(string sessionId, string input)
        {
            //var jsonInput = "{\"version\":1,\"message_type\":29,\"message_id\":92,\"body\":[{\"message_type\":29,\"server_search_locations\":{\"with_countries\":false,\"query\":\"" + input + "\"}}],\"is_background\":false}";
            IJsonMessage jsonMessage = JsonFactory.GetJson(JsonTypes.GetCountryById);
            jsonMessage.SetProperty(input);
            string json = JsonConvert.SerializeObject(jsonMessage);
            var locationResultModel = await SendAndReturn(sessionId, json, input);
            var objRes = JsonConvert.DeserializeObject<LocationResultModel>(locationResultModel);

            var locationList = objRes.BodyResultModel.First().ClientLocations.Locations;
            if (locationList != null)
            {
                foreach (var singleLocation in locationList)
                {
                    await SaveLocation(sessionId, singleLocation.City.Id.ToString());
                }
            }
            else
            {
                //log
            }
        }

        public async Task SaveLocation(string sessionId, string input)
        {
            //var jsonInput = "{\"version\":1,\"message_type\":32,\"message_id\":23,\"body\":[{\"message_type\":32,\"p_integer\":{\"value\":" + location + "}}],\"is_background\":false}";
            IJsonMessage jsonMessage = JsonFactory.GetJson(JsonTypes.SaveLocation);
            jsonMessage.SetProperty(input);
            string json = JsonConvert.SerializeObject(jsonMessage);

            await SendAndReturn(sessionId, json);
        }

        public async Task ChangeDescription(string sessionId, string proffesion, string companyName, string school)
        {
            //if user changes description 2nd time right after fist time session id == null.
            //string jsonInput = "{\"version\":1,\"message_type\":616,\"message_id\":26,\"body\":[{\"message_type\":616,\"server_experience_action\":{\"context\":130,\"action\":2,\"experiences\":[{\"$gpb\":\"badoo.bma.Experience\",\"id\":\"keep_only_one\",\"type\":1,\"name\":\"" + proffesion + "\",\"organization_name\":\"" + companyName + "\",\"selected\":true,\"source\":1,\"moderation_failed\":false,\"name_length_limit\":250,\"organization_name_length_limit\":30},{\"$gpb\":\"badoo.bma.Experience\",\"id\":\"keep_only_one\",\"type\":2,\"name\":\"\",\"organization_name\":\"" + school + "\",\"selected\":true,\"source\":1,\"moderation_failed\":false,\"name_length_limit\":0,\"organization_name_length_limit\":250}]}}],\"is_background\":false}";
            IJsonMessage jsonMessage = JsonFactory.GetJson(JsonTypes.ChangeDescription);
            jsonMessage.SetProperties(proffesion, companyName, school);
            string json = JsonConvert.SerializeObject(jsonMessage);
            await SendAndReturn(sessionId, json);
        }
        public async Task ChangeAboutMe(string sessionId, string input)
        {
            //https://us1.badoo.com/webapi.phtml
            //if user changes description 2nd time right after fist time session id == null.
            //string jsonInput = "{\"version\":1,\"message_type\":616,\"message_id\":26,\"body\":[{\"message_type\":616,\"server_experience_action\":{\"context\":130,\"action\":2,\"experiences\":[{\"$gpb\":\"badoo.bma.Experience\",\"id\":\"keep_only_one\",\"type\":1,\"name\":\"" + proffesion + "\",\"organization_name\":\"" + companyName + "\",\"selected\":true,\"source\":1,\"moderation_failed\":false,\"name_length_limit\":250,\"organization_name_length_limit\":30},{\"$gpb\":\"badoo.bma.Experience\",\"id\":\"keep_only_one\",\"type\":2,\"name\":\"\",\"organization_name\":\"" + school + "\",\"selected\":true,\"source\":1,\"moderation_failed\":false,\"name_length_limit\":0,\"organization_name_length_limit\":250}]}}],\"is_background\":false}";
            IJsonMessage jsonMessage = JsonFactory.GetJson(JsonTypes.ChangeAboutMe);
            jsonMessage.SetProperty(input);
            string json = JsonConvert.SerializeObject(jsonMessage);
            await SendAndReturn(sessionId, json, "us");
        }



        public async Task<LocalProjectionModel> GetLast(LocalProjectionModel projList, string sessionId)
        {
            LocalProjectionModel model = new LocalProjectionModel();

            var last = projList.UsersIds[projList.UsersIds.Count - 1];
            var lastPersonId = last.Replace("]", "");
            lastPersonId = lastPersonId.Replace("\"", "");

            //var json = "{\"version\":1,\"message_type\":81,\"message_id\":41,\"body\":[{\"message_type\":81,\"server_get_encounters\":{\"number\":20,\"context\":1,\"last_person_id\":\"" + lastPersonId + "\",\"user_field_filter\":{\"projection\":" + parsed + ",\"request_albums\":[{\"album_type\":7}],\"united_friends_filter\":[{\"count\":5,\"section_type\":3},{\"count\":5,\"section_type\":1},{\"count\":5,\"section_type\":2}]}}}],\"is_background\":false}";
            IJsonMessage jsonMessage = JsonFactory.GetJson(JsonTypes.GetLast);
            jsonMessage.SetProperties(lastPersonId, projList.Projections);
            string json = JsonConvert.SerializeObject(jsonMessage);
            var result = await SendAndReturn(sessionId, json);

            var objRes = JsonConvert.DeserializeObject<UsersResponseModel>(result);
            model.SessionId = sessionId;
            model.UsersIds = projList.UsersIds;
            model.UserId = projList.UserId;

            foreach (var itemRes in objRes.Body.SelectMany(item => item.ClientEncounters.Results))
            {
                model.UsersIds.Add(itemRes.User.UserId);
                model.Projections = itemRes.User.Projection;
            }
            return model;
        }
        public void GetAboutMe(string sessionId, string userId)
        {

        }

        public async Task<int> ExecuteLikes(MessageWithoutUser message)
        {
            var likesLeft = message.Likes;
            List<string> userIds = ExtractUserIdsFromList(Model.UsersIds);
            var id = userIds[message.Likes - message.Likes + 1];

            //var json = "{\"version\":1,\"message_type\":80,\"message_id\":16,\"body\":[{\"message_type\":80,\"server_encounters_vote\":{\"person_id\":\"" + id + "\",\"vote\":2,\"photo_id\":\"\",\"vote_source\":1}}],\"is_background\":false}";
            IJsonMessage jsonMessage = JsonFactory.GetJson(JsonTypes.ExecuteLikes);
            jsonMessage.SetProperty(id);
            string json = JsonConvert.SerializeObject(jsonMessage);

            try
            {
                var res = await SendAndReturn(Model.SessionId, json, "us");
                likesLeft--;
                //could get error of reached likes limit, need to handle.
                //send email to user.
                Console.WriteLine("liked - " + id + " likes left - " + likesLeft);
            }
            catch (Exception)
            {
                return likesLeft;
            }
            return likesLeft;
        }

        private List<string> ExtractUserIdsFromList(string userIds)
        {
            var leftRemoved = userIds.Replace("[", "");
            var rightRemoved = leftRemoved.Replace("]", "");
            var allRemovd = rightRemoved.Replace("\"", "");
            var slashRemoved = allRemovd.Replace("\\", "");
            var li = slashRemoved.Split(",").ToList();
            return li;
        }

        public async Task InitializeBot(ServiceCredentialsModel user, MessageWithoutUser message)
        {
            var users = CredentialDb.GetUsersModel(user.UserId);
            var userIdsFromList = ExtractUserIdsFromList(users.UsersIds);

            LocalProjectionModel projModel = new LocalProjectionModel();
            var cookie = Login(user.Username, user.Password, message.UserId);

            var projList = await LoginWithApi(user.Username, user.Password, cookie.SessionId);

            for (int i = 1; i < message.Likes / 20; i++)
            {
                if (projList.UsersIds.Count < message.Likes)
                {
                    projList = await GetLast(projList, cookie.SessionId);
                }
            }

            var serialized = JsonConvert.SerializeObject(projList.UsersIds);
            var serializedProjections = JsonConvert.SerializeObject(projList.Projections);
            Model.SessionId = cookie.SessionId;
            Model.UserId = user.UserId;
            Model.UsersIds = serialized;
            Model.Projections = serializedProjections;

            ProjectionModel projectionModel = new ProjectionModel()
            {
                Projections = serializedProjections,
                UsersIds = serialized,
                SessionId = cookie.SessionId,
                time = projList.time,
                UserId = projList.UserId
            };

            CredentialDb.SaveProjections(projectionModel);
        }

        public async Task<string> SendAndReturn(string sessionId, string jsonInput, string input = "")
        {
            HttpResponseMessage res = null;
            HttpClient client = new HttpClient();
            HttpContent content = new StringContent(jsonInput);
            content.Headers.Add("X-Session-Id", sessionId);
            if (input.Contains("us"))
            {
                res = await client.PostAsync(US_API_URL, content);
                var ss = await res.Content.ReadAsStringAsync();
            }
            else if (input.Contains("eu"))
            {
                res = await client.PostAsync(EU_API_URL, content);
                var ss = await res.Content.ReadAsStringAsync();
            }
            else if (jsonInput.Contains("server_multi_upload_photo"))
            {

                res = await client.PostAsync(UPLOAD_PHOTO_API, content);
                var ss = await res.Content.ReadAsStringAsync();
            }
            else
            {
                res = await client.PostAsync(API_URL, content);
                var ss = await res.Content.ReadAsStringAsync();
            }
            return await res.Content.ReadAsStringAsync();
        }
        private static ChromeDriver GetSeleniumDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            return new ChromeDriver(options);
        }

        private CookieModel getBadooSiteCookie(string userId, CookieModel badooCookie, WebDriverWait wait)
        {
            OpenQA.Selenium.Cookie cookie = wait.Until(driver1 => GetCookie(Driver));
            badooCookie.SessionId = cookie.Value.ToString().Replace("%3A", ":");
            badooCookie.Expiry = cookie.Expiry;
            badooCookie.UserId = userId;
            return badooCookie;
        }

        public OpenQA.Selenium.Cookie GetCookie(IWebDriver driver)
        {
            OpenQA.Selenium.Cookie cookie = null;
            while (cookie == null)
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        var test = $"s{i}";
                        cookie = Driver.Manage().Cookies.GetCookieNamed($"s{i}");
                        if (cookie != null)
                        {
                            return cookie;
                        }
                    }
                    catch (Exception e)
                    {
                        //Log
                    }
                }
            }
            return cookie;
        }
        public void ShutDown()
        {
            Driver.Quit();
            Driver = null;
        }


        public async Task<AppStartupModelResponseModel> StartupBot(string sessionId)
        {
            return await GetStartupUser(sessionId);

        }
    }
}
