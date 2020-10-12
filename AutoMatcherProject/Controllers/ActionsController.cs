using AutoMatcherProject.ViewModels;
using BotsImpl;
using Interfaces;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;
using Microsoft.AspNetCore.Http;
using ServicesImpl;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Security.Claims;
using System.Text.Json;
using AutoMatcherProject1.Migrations;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using RabbitMQ.Client.Impl;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Cors;
using System.Resources;
using OpenQA.Selenium.Interactions;
using HtmlAgilityPack;
using UtilModels;
using Microsoft.Extensions.Logging;

namespace AutoMatcherProject.Controllers
{
    //[Authorize]
    public class ActionsController : Controller
    {
        private readonly ILogger<ActionsController> _logger;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpClientFactory _clientFactory;
        private UserManager<ApplicationUser> _userManager;
        private readonly ISche SchedulrAbstraction;
        private readonly IBotFactory Factory;
        private readonly ICredentialDb CredentialDB;
        private readonly IConfiguration Config;
        private List<Service> ValidatedServices;
        private IMailer Mailer;
        public IWebHostEnvironment Hosting { get; }
        public string INSTAGRAM_APP_ID { get; private set; }
        public string INST_AUTH_URL { get; private set; }

        private ISessionManager SessionManager;
        public ActionsController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ISche schedulrAbstraction,
            IBotFactory factory,
            ICredentialDb saver,
            ISessionManager sessionManager,
            IWebHostEnvironment hosting,
            IHttpClientFactory clientFactory,
            IConfiguration configuration,
            IMailer mailer,
            ILogger<ActionsController> logger)
        {
            _signInManager = signInManager;
            _clientFactory = clientFactory;
            _userManager = userManager;
            SchedulrAbstraction = schedulrAbstraction;
            Factory = factory;
            CredentialDB = saver;
            SessionManager = sessionManager;
            Hosting = hosting;
            ValidatedServices = new List<Service>();
            Config = configuration;
            INSTAGRAM_APP_ID = Config.GetValue<string>("INSTAGRAM_APP_ID");
            INST_AUTH_URL = Config.GetValue<string>("REDIRECT_URL");
            Mailer = mailer;
            _logger = logger;

        }

        [HttpPost]
        public async Task<IActionResult> ValidateUser(Service service, string username, string password)
        {
            _logger.LogInformation("Hello, this is the index! ValidateUser method");
            List<Service> services = new List<Service>();
            var user = CredentialDB.GetServiceCredentialsModel(username, password, service);
            IBot _bot = Factory.GetBot(service);
            var result = await CheckCookies(username, password, service);
            if (result == null)
            {
                return Unauthorized();
            }

            if (user == null)
            {
                var userId = _userManager.GetUserId(User);
                CredentialDB.SaveUserServiceCredentials(username, password, service, userId);
            }
            return RedirectToAction("Dashboard", "Users");
        }
        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public void InitialValidation()
        {
            var userId = _userManager.GetUserId(User);
            var user = CredentialDB.GetById(userId);

        }

        public async Task<IActionResult> ValidateAuthenticatedUser(Service service, string username, string password)
        {
            var user = CredentialDB.ValidateAndGetServiceCredentials(username, password, service);
            IBot _bot = Factory.GetBot(service);
            var pwd = PasswordHasher.Decrypt(user.Password, user.Hash);
            var result = await ValidateServiceCredentials(user.Username, pwd, service);
            if (result == null)
            {
                return Unauthorized();
            }

            if (user == null)
            {
                var userId = _userManager.GetUserId(User);
                CredentialDB.SaveUserServiceCredentials(username, password, service, userId);
            }
            return RedirectToAction("Dashboard", "Users");
        }
        public async Task<JsonResult> ValidateAuthenticatedUsers(List<string> services)
        {
            List<string> verifiedServices = new List<string>();
            var currentUser = _userManager.GetUserId(User);
            foreach (var service in services)
            {
                if (!(service == null))
                {
                    var parsedService = EnumParser.Parse(service);

                    var foundUser = await CredentialDB.GetByIdAndServiceServiceCredentialsModel(currentUser, parsedService);
                    var result = await ValidateServiceCredentials(foundUser.Username, foundUser.Password, parsedService);
                    if (result != null)
                    {
                        verifiedServices.Add(service);
                    }
                }
            }
            return Json(verifiedServices);
        }

        [HttpPost]
        public async Task<string> ValidateServiceCredentials(string username, string password, Service service)
        {
            _logger.LogInformation("Hello, this is the index! ValidateServiceCredentials method");
            var _bot = Factory.GetBot(service);
            var userId = _userManager.GetUserId(User);
            var cookie = _bot.Login(username, password, userId);

            if (cookie.SessionId != null)
            {
                // var userId = await SaveUsers(username, password, service, _bot, cookie);
                SaveCookie(service, _bot, cookie);
                return cookie.SessionId;
            }
            else
            {
                //send email to client with reason of error. if client fault

            }

            return null;
        }



        [HttpGet]
        private async Task<string> CheckCookies(string username, string password, Service service)
        {
            var user = CredentialDB.GetUsersCredentialsModel(username, password, service);
            var _bot = Factory.GetBot(service);
            var cookie = _bot.Login(username, password);

            if (cookie.SessionId != null)
            {
                // var userId = await SaveUsers(username, password, service, _bot, cookie);
                SaveCookie(service, _bot, cookie);
                return cookie.SessionId;
            }

            return null;
        }

        [HttpPost]
        private async Task<string> SaveUsers(string username, string password, Service service, IBot _bot, CookieModel cookie)
        {
            //Save users and cookie to database.
            //cookie.Expiry = DateTime.SpecifyKind((DateTime)cookie.Expiry, DateTimeKind.Utc);
            var projectionModel = await _bot.LoginWithApi(username, password, cookie.SessionId);
            projectionModel.UserId = _userManager.GetUserId(User);
            projectionModel.SessionId = cookie.SessionId;
            var parseProjections = JsonConvert.SerializeObject(projectionModel.Projections);
            var parsedUserIds = JsonConvert.SerializeObject(projectionModel.UsersIds);
            ProjectionModel projModel = new ProjectionModel()
            {
                Projections = parseProjections,
                UsersIds = parsedUserIds,
                SessionId = cookie.SessionId,
                time = projectionModel.time,
                UserId = projectionModel.UserId
            };

            CredentialDB.SaveProjections(projModel);
            return projModel.UserId;
        }
        public List<string> GetUserServices()
        {
            var userId = _userManager.GetUserId(User);
            var userServices = CredentialDB.GetUserServices(userId);
            //foreach (var service in userServices)
            //{
            //    IBot _bot = Factory.GetBot(service);
            //    var serviceCredentials = CredentialDB.GetByIdServiceCredentialsModel(userId);
            //    //var result = _bot.Login(serviceCredentials.Username, serviceCredentials.Password);
            //    //if (result == null)
            //    //{
            //    //    CredentialDB.RemoveServiceFromUser(userId, service);
            //    //}
            //}
            return userServices.Select(i => i.ToString()).ToList();
        }

        [HttpPost]
        public Task<List<string>> AutoComplete(string input, Service service)
        {
            var sessionId = SessionManager.GetCookieSession(service);
            if (sessionId != null)
            {
                var bot = Factory.GetBot(service);
                return bot.GetCities(input, sessionId);
            }
            return null;
        }
        private void SaveCookie(Service service, IBot _bot, CookieModel cookie)
        {
            SessionManager.SetCookieSession(service, cookie);
        }

        [HttpPost]
        public async Task ChangeAboutMe(string input, Service service)
        {
            var bot = Factory.GetBot(service);
            var sessionId = SessionManager.GetCookieSession(service);
            await bot.ChangeAboutMe(sessionId, input);
        }
        [HttpPost]
        public async Task ChangeDescription(string proffesion, string companyName, string school, string input, Service service)
        {
            var bot = Factory.GetBot(service);
            var sessionId = SessionManager.GetCookieSession(service);
            await bot.ChangeDescription(sessionId, proffesion, companyName, school);
        }

        [HttpPost]
        public async Task ChangeAboutMeOnAllServices(string id, string input, List<Service> services)
        {
            foreach (var service in services)
            {
                var user = CredentialDB.GetById(id);
                var sessionId = SessionManager.GetCookieSession(service);
                var bot = Factory.GetBot(service);
                await bot.ChangeAboutMe(input, sessionId);
            }
        }

        [HttpPost]
        public void ValidateServices(string id, List<Service> services)
        {
            foreach (var service in services)
            {

                var user = CredentialDB.GetById(id);
                var bot = Factory.GetBot(service);
                var cookie = bot.Login(user.Username, user.Password);
                if (cookie != null)
                {
                    SessionManager.SetCookieSession(service, cookie);
                    var sessionId = SessionManager.GetCookieSession(service);

                }
            }
        }
        [HttpGet]
        public async Task GetCountry(string input, Service service)
        {
            var sessionId = SessionManager.GetCookieSession(service);
            var bot = Factory.GetBot(service);
            await bot.GetCountryId(sessionId, input);
        }

        [HttpPost]
        public async Task SaveLocationBadoo(string location, Service service)
        {
            var sessionId = SessionManager.GetCookieSession(service);
            var bot = Factory.GetBot(service);
            await bot.SaveLocation(sessionId, location);
        }
        [HttpGet]
        public async Task<JsonResult> GetImages(Service service)
        {
            var sessionId = SessionManager.GetCookieSession(service);
            var bot = Factory.GetBot(service);
            var userId = _userManager.GetUserId(User);

            List<PictureUrlModel> images = await bot.GetImages(sessionId, userId);
            return Json(images);
        }

        [HttpGet]
        public async Task<JsonResult> GetUser(Service service)
        {
            BadooUserModel model = new BadooUserModel();
            List<string> botPictureIds = new List<string>();
            List<string> pictureIds = new List<string>();
            //gets the user id from the session
            var userId = _userManager.GetUserId(User);
            //gets service sessisionId
            var sessionId = SessionManager.GetCookieSession(service);
            var bot = Factory.GetBot(service);

            //List<PictureUrlModel> updatedPicturesList = new List<PictureUrlModel>();
            //List<PictureUrlModel> botList = await bot.GetImages(sessionId, userId);
            //List<PictureUrlModel> presistanceList = CredentialDB.GetBadooPictures(userId, service);
            //List<PictureUrlModel> orderedBotList = botList.OrderBy(a => a.PhotoId).ToList();
            //List<PictureUrlModel> orderedPersistanceList = presistanceList.OrderBy(a => a.PhotoId).ToList();

            //var comparedLists = orderedBotList.Except(orderedPersistanceList, new PictureUrlModelExtention()).ToList();

            //if (comparedLists.Count > 0)
            //{
            //    CredentialDB.SaveBadooPictures(comparedLists);
            //}
            if (userId != null)
            {
                var userResponse = await bot.StartupBot(sessionId);
                string hiddenUrl = string.Empty;
                bool flag = true;
                foreach (var item in userResponse.Body)
                {
                    if (flag)
                    {
                        if (item.ClientCommonSettings != null)
                        {
                            foreach (var url in item.ClientCommonSettings.ExternalEndpoints)
                            {
                                if (url.Url.Contains("hidden"))
                                {
                                    hiddenUrl = url.Url;
                                    flag = false;
                                    break;
                                }
                            }
                        }
                    }

                }
                SessionManager.SetSession(service + "pictureUrl", hiddenUrl);

                var useri = await bot.GetUser(sessionId);
                var userSettings = await bot.GetUserSettings(sessionId);
                model.Images = await bot.GetImages(sessionId, userId);

                model.UserId = useri.Body33.Where(i => i.ClientLoginSuccess != null).Select(i => i.ClientLoginSuccess.UserInfo.UserId).FirstOrDefault().ToString();
                var locationList = useri.Body33.Where(i => i.ClientLoginSuccess != null).Select(i => i.ClientLoginSuccess.UserInfo.ProfileFields).FirstOrDefault();
                foreach (var item in locationList)
                {

                    if (item.IdUsersResponseModel.Contains("location"))
                    {
                        model.Location = item.DisplayValueUsersResponseModel;
                    }
                    else if (item.IdUsersResponseModel.Contains("aboutme_text"))
                    {
                        model.AboutMe = item.DisplayValueUsersResponseModel;
                    }
                    if (model.Location != null && model.AboutMe != null)
                    {
                        break;
                    }
                }
                model.AgeMinValue = userSettings.Body.Where(i => i.ClientSearchSettings != null).Select(i => i.ClientSearchSettings.SettingsForm.AgeSliderSettings.MinRange).FirstOrDefault();
                model.AgeMaxValue = userSettings.Body.Where(i => i.ClientSearchSettings != null).Select(i => i.ClientSearchSettings.SettingsForm.AgeSliderSettings.MaxValue).FirstOrDefault();
                model.DistanceMaxValue = userSettings.Body.Where(i => i.ClientSearchSettings != null).Select(i => i.ClientSearchSettings.SettingsForm.DistanceSliderSettings.MaxValue).FirstOrDefault();
                model.LookingFor = userSettings.Body.Where(i => i.ClientSearchSettings != null).Select(i => i.ClientSearchSettings.CurrentSettings.Gender).FirstOrDefault();

            }
            return Json(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUserSearchSettings([FromBody]UserSearchSettingsModel model)
        {
            var userId = _userManager.GetUserId(User);
            var service = EnumParser.Parse(model.Service);
            var sessionId = SessionManager.GetCookieSession(service);
            var bot = Factory.GetBot(service);
            await bot.UpdateUserSearchSettings(Convert.ToInt64(model.StartAge), Convert.ToInt64(model.EndAge), Convert.ToInt64(model.Distance), model.Gender, sessionId);


            return RedirectToAction("Dashboard", "Users");
        }

        [HttpGet]
        public List<PictureUrlModel> GetServicePictures(Service service)
        {
            var userId = _userManager.GetUserId(User);
            var s = CredentialDB.GetBadooPictures(userId, service);
            return CredentialDB.GetBadooPictures(userId, service);
        }
        [HttpGet]
        public async Task<IActionResult> AuthenticateInstagramAPI()
        {
            var instagramModel = SessionManager.GetInstagramModel();
            if (instagramModel.AccessToken == null)
            {
                return Redirect("https://www.instagram.com/oauth/authorize?client_id=346912513373650&redirect_uri=https://localhost:49000/Actions/AccessTokenAuth&scope=user_media,user_profile&response_type=code");
            }
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> AccessTokenAuth()
        {


            HttpClient client = new HttpClient();
            var code = Request.QueryString.Value.Remove(0, 6);

            var formVars = new Dictionary<string, string>();
            formVars.Add("client_id", "346912513373650");
            formVars.Add("client_secret", "7455bf4a5f09c4c9ef289eb292f9f522");
            formVars.Add("code", code);
            formVars.Add("grant_type", "authorization_code");
            formVars.Add("redirect_uri", "https://localhost:49000/Actions/AccessTokenAuth");

            HttpContent content = new FormUrlEncodedContent(formVars);

            var jsonString = await client.PostAsync("https://api.instagram.com/oauth/access_token", content);
            var parsedContent = await jsonString.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<InstagramUserModel>(parsedContent);

            var userId = _userManager.GetUserId(User);
            SessionManager.SaveInstagramModel(model);


            return View("Close");
        }
        public string GetInstagramBadooSession()
        {
            var s = SessionManager.GetSession("Token");
            return SessionManager.GetSession("Token");
        }

        [HttpGet]
        public async Task<JsonResult> GetUserInstagramMediaFromAPI()
        {
            //var services = Enum.GetValues(typeof(Service)).Cast<Service>();
            //foreach (var service in services)
            //{
            //    var bot = Factory.GetBot(service);
            //    await bot.AuthenticateBadooInstagram(SessionManager.GetSession(service.ToString()));
            //}

            HttpClient client = new HttpClient();
            List<InstagramMediaModel> userMedia = new List<InstagramMediaModel>();
            var model = SessionManager.GetInstagramModel();
            var userMediaList = await client.GetAsync("https://graph.instagram.com/" + model.UserId + "/media?access_token=" + model.AccessToken);
            var userMediaContent = await userMediaList.Content.ReadAsStringAsync();
            var userId = _userManager.GetUserId(User);

            InstagramUserDataModel dataModel = JsonConvert.DeserializeObject<InstagramUserDataModel>(userMediaContent);
            foreach (var id in dataModel.Data)
            {
                var response = await client.GetAsync("https://graph.instagram.com/" + id.Id + "?fields=id,media_type,media_url,username,timestamp&access_token=" + model.AccessToken);
                var media = await response.Content.ReadAsStringAsync();
                var mediaObject = JsonConvert.DeserializeObject<InstagramMediaModel>(media);
                mediaObject.UserId = userId;
                userMedia.Add(mediaObject);
            }
            InstagramMediaWrapper inst = new InstagramMediaWrapper();
            inst.InstagramList = userMedia;

            return Json(inst);
        }

        [HttpPost]
        public async Task<IActionResult> Schedule(int messageId, DateTime time, int likes, Service service, ApplicationUser user)
        {
            //var userId = _userManager.GetUserId(HttpContext.User);
            var _user = _userManager.GetUserAsync(HttpContext.User).Result;
            await SchedulrAbstraction.Schedule(messageId, time, likes, service, _user);

            return RedirectToAction("Dashboard", "Users");
        }

        [HttpPost]
        public async Task<string> UploadImage(InstagramMediaWithServiceModel model)
        {
            var bot = Factory.GetBot(model.Service);
            var sessionId = SessionManager.GetCookieSession(model.Service);
            var url = SessionManager.GetSession(model.Service + "pictureUrl");
            var response = await bot.UploadImage(sessionId, model.Images, url);

            return response;
        }

        [HttpPost]
        public async Task<JsonResult> RemoveImage([FromBody]UserWithImageModel input)
        {
            Service service = EnumParser.Parse(input.service);
            var sessionId = SessionManager.GetCookieSession(service);
            var bot = Factory.GetBot(service);
            await bot.RemoveImage(sessionId, input.imgId);

            var user = await GetUser(service);

            return user;

        }

        [HttpPost]
        public string AddServiceAsValidated(Service service)
        {
            var str = service.ToString();
            SessionManager.SetSession(str, str);
            //add to database

            return "ok";
        }
        [HttpGet]
        public bool CheckServiceValidation(string service)
        {
            string str = service.ToString();
            var session = SessionManager.GetSession(str);
            if (str == session)
                return true;
            else return false;
        }
        [HttpPost]
        public JsonResult CheckServicesValidation(List<string> services)
        {
            List<string> verifiedServices = new List<string>();
            foreach (var service in services)
            {
                if (service != null)
                {
                    var session = SessionManager.GetSession(service);
                    if (service == session)
                    {
                        verifiedServices.Add(service);
                    }
                }
            }
            return Json(verifiedServices);
        }
        [HttpPost]
        public void ClearSession()
        {
            SessionManager.ClearSession();
        }
        [HttpGet]
        public void ShutDown()
        {
            // go over all open services and quit drivers.
            var services = GetUserServices();
            foreach (var s in services)
            {
                Service service = EnumParser.Parse(s);
                IBot bot = Factory.GetBot(service);
                bot.ShutDown();
            }
        }
    }
}
