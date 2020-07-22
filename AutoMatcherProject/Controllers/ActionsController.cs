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

namespace AutoMatcherProject.Controllers
{
    //[Authorize]
    public class ActionsController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ISche SchedulrAbstraction;
        private readonly IBotFactory Factory;
        private readonly ICredentialDb CredentialDB;

        public IWebHostEnvironment Hosting { get; }
        private ISessionManager _sessionManager;
        public ActionsController(UserManager<ApplicationUser> userManager,
            ISche schedulrAbstraction,
            IBotFactory factory,
            ICredentialDb saver,
            ISessionManager sessionManager,
            IWebHostEnvironment hosting)
        {
            _userManager = userManager;
            SchedulrAbstraction = schedulrAbstraction;
            Factory = factory;
            CredentialDB = saver;
            _sessionManager = sessionManager;
            Hosting = hosting;
        }

        [HttpPost]
        public async Task<IActionResult> ValidateUser(Service service, string username, string password)
        {
            var user = CredentialDB.GetServiceCredentialsModel(username, password);
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
        [HttpGet]
        private async Task<string> CheckCookies(string username, string password, Service service)
        {
            //var user = CredentialDB.Get(username, password, service);
            var _bot = Factory.GetBot(service);
            var cookie = _bot.Login(username, password);

            if (cookie.SessionId != null)
            {
                var userId = await SaveCookieAndUsers(username, password, service, _bot, cookie);

                //if (user == null)
                //{
                //    //UsersCredentialsModel model = new UsersCredentialsModel() { UserId = _userManager.GetUserId(User), Password = password, Username = username };
                //    //ServiceModel sm = new ServiceModel
                //    //{
                //    //    Service = service,
                //    //    ServiceUserId = userId
                //    //};
                //    //List<ServiceModel> serviceModels = new List<ServiceModel>();
                //    //serviceModels.Add(sm);
                //    //model.Services = serviceModels;

                //    //CredentialDB.Save(model);
                //}
                return cookie.SessionId;
            }

            return null;
        }
        public async Task<List<string>> GetUserServices()
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
            var sessionId = _sessionManager.GetSession(service);
            if (sessionId != null)
            {
                var bot = Factory.GetBot(service);
                return bot.GetCities(input, sessionId);
            }
            return null;
        }
        [HttpPost]

        private async Task<string> SaveCookieAndUsers(string username, string password, Service service, IBot _bot, CookieModel cookie)
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

            _sessionManager.SetSession(service, cookie);
            CredentialDB.SaveProjections(projModel);
            return projectionModel.UserId;
        }

        [HttpPost]
        public async Task ChangeDescription(string proffesion, string companyName, string school, string input, Service service)
        {
            var sessionId = _sessionManager.GetSession(service);
            var bot = Factory.GetBot(service);
            await bot.ChangeDescription(sessionId, proffesion, companyName, school);
        }

        [HttpPost]
        public async Task ChangeDescriptions(string id, string description, List<Service> services)
        {
            foreach (var service in services)
            {
                var user = CredentialDB.GetById(id);
                var sessionId = _sessionManager.GetSession(service);
                var bot = Factory.GetBot(service);
                await bot.ChangeDescriptions(description, service, sessionId);
            }
        }

        [HttpPost]
        public async Task ValidateServices(string id, List<Service> services)
        {
            foreach (var service in services)
            {

                var user = CredentialDB.GetById(id);
                var bot = Factory.GetBot(service);
                var cookie = bot.Login(user.Username, user.Password);
                if (cookie != null)
                {
                    _sessionManager.SetSession(service, cookie);
                    var sessionId = _sessionManager.GetSession(service);

                }
            }
        }
        [HttpPost]
        public async Task GetCountry(string input, Service service)
        {
            var sessionId = _sessionManager.GetSession(service);
            var bot = Factory.GetBot(service);
            await bot.GetCountryId(sessionId, input);
        }

        [HttpPost]
        public async Task SaveLocationBadoo(string location, Service service)
        {
            var sessionId = _sessionManager.GetSession(service);
            var bot = Factory.GetBot(service);
            await bot.SaveLocation(sessionId, location);
        }

        [HttpGet]
        public async Task<List<PictureUrlModel>> GetUserImages(Service service)
        {
            List<string> botPictureIds = new List<string>();
            List<string> pictureIds = new List<string>();
            //gets the user id from the session
            var userId = _userManager.GetUserId(User);
            //gets service sessisionId
            var sessionId = _sessionManager.GetSession(service);
            var bot = Factory.GetBot(service);

            List<PictureUrlModel> botList = await bot.GetImages(sessionId, userId);
            List<PictureUrlModel> presistanceList = CredentialDB.GetBadooPictures(userId);
            List<PictureUrlModel> updatedPicturesList = new List<PictureUrlModel>();
            List<PictureUrlModel> orderedBotList = botList.OrderBy(a => a.PhotoId).ToList();
            List<PictureUrlModel> orderedPersistanceList = botList.OrderBy(a => a.PhotoId).ToList();
           

            for (int i = 0; i < orderedBotList.Count-1; i++)
            {
                if (!(orderedBotList[i].PhotoId== orderedPersistanceList[i].PhotoId))
                {
                    updatedPicturesList.Add(orderedBotList[i]);
                }
            }
            if (updatedPicturesList.Count > 0)
            {        
                CredentialDB.SaveBadooPictures(updatedPicturesList);
            }
            return botList;
        }
        [HttpPost]
        public async Task<List<PictureUrlModel>> GetServicePictures(Service service)
        {
            var userId = _userManager.GetUserId(User);
          
            return CredentialDB.GetBadooPictures(userId);
        }

        [HttpPost]
        public async Task<IActionResult> Schedule(int messageId,DateTime time, int likes, Service service, ApplicationUser user)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var _user = _userManager.GetUserAsync(HttpContext.User).Result;
            await SchedulrAbstraction.Schedule(messageId, time, likes, service, _user);

            return RedirectToAction("Dashboard", "Users");
        }

        [HttpPost]
        public string UploadImage(Service service, IFormFile photo)
        {
            if (photo != null)
            {
                string uploadsFolder = Path.Combine(Hosting.WebRootPath, "images");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                photo.CopyTo(new FileStream(filePath, FileMode.Create));
                return filePath;
            }

            var sessionId = _sessionManager.GetSession(service);
            var bot = Factory.GetBot(service);
            return null;
        }

        public void TESTMETHOD()
        {
            CredentialDB.TESTSave();
        }
    }
}
