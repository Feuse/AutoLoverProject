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

namespace AutoMatcherProject.Controllers
{

    [Authorize]
    public class ActionsController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private ISche _schedulrAbstraction;
        private IBotFactory _factory;
        private ICredentialSaver _db;
        private IBot _bot;
        private ISessionManager _sessionManager;

        public ActionsController(UserManager<ApplicationUser> userManager, ISche schedulrAbstraction, IBotFactory factory, ICredentialSaver saver, ISessionManager sessionManager)
        {
            _userManager = userManager;
            _schedulrAbstraction = schedulrAbstraction;
            _factory = factory;
            _db = saver;
            _sessionManager = sessionManager;
        }
        [HttpPost]
        public IActionResult ValidateUser(Service service, string username, string password)
        {
            
            _bot = _factory.GetBot(service);
            var result = CheckCookies(username, password, service);
            if (result == null)
            {
                return Unauthorized();
            }

            return RedirectToAction("Dashboard", "Users");
        }
        [HttpPost]
        public Task<List<string>> AutoComplete(string input,Service service)
        {
            var sessionId = _sessionManager.GetSession(service);
            if (sessionId != null)
            {
                var bot = _factory.GetBot(service);
                return bot.GetCities(input, sessionId);
            }
            else
            {
                
            }
            return null;
        }
        [HttpPost]
        private string CheckCookies(string username, string password, Service service )
        {
            var user = _db.Get(username, password, service);
            if (user != null)
            {  
                var _bot = _factory.GetBot(service);
                var cookie = _bot.Login(username, password, user.Id);

                if (cookie.SessionId != null)
                {
                    cookie.Expiry = DateTime.SpecifyKind((DateTime)cookie.Expiry, DateTimeKind.Utc);
                    //CookieOptions options = new CookieOptions
                    //{
                    //    Expires = cookie.Expiry
                    //};

                    _sessionManager.SetSession(service, cookie);

                    return cookie.SessionId;
                }
            }
            else
            {           
                var _bot = _factory.GetBot(service);
                var cookie = _bot.Login(username, password);

                if (cookie.SessionId != null)
                {
                    cookie.Expiry = DateTime.SpecifyKind((DateTime)cookie.Expiry, DateTimeKind.Utc);
                    //CookieOptions options = new CookieOptions
                    //{
                    //    Expires = cookie.Expiry
                    //};
                    _sessionManager.SetSession(service, cookie);
                    
                    UsersCredentialsModel model = new UsersCredentialsModel() { Id =_userManager.GetUserId(User), Password = password, Service = service, Username = username };
                    _db.Save(model);
                    return cookie.SessionId;
                }
            }
            return null;
        }

        [HttpPost]
        public async Task ChangeDescription(string proffesion, string companyName, string school, string input, Service service)
        {
            var sessionId = _sessionManager.GetSession(service);
            var bot = _factory.GetBot(service);
            await bot.ChangeDescription(sessionId, proffesion, companyName, school);
        }


        [HttpPost]
        public async Task GetCountry(string input, Service service)
        {
            var sessionId = _sessionManager.GetSession(service);
            var bot = _factory.GetBot(service);

            await bot.GetCountryId(sessionId, input);

        }
        [HttpPost]
        public async Task SaveLocationBadoo(string location, Service service)
        {
            var sessionId = _sessionManager.GetSession(service);
            var bot = _factory.GetBot(service);
            await bot.SaveLocation(sessionId, location);
        }

        [HttpGet]
        public async Task<List<PictureUrlModel>> GetUserImages(Service service)
        {
            var userId = _sessionManager.GetUserId(service);
            var sessionId = _sessionManager.GetSession(service);
            var bot = _factory.GetBot(service);
            List<PictureUrlModel> list = await bot.GetImages(sessionId, userId);

            return list;
        }

        
        [HttpPost]
        public async Task<IActionResult> Schedule(DateTime time, int likes, Service service, ApplicationUser user)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var _user = _userManager.GetUserAsync(HttpContext.User).Result;
            await _schedulrAbstraction.Schedule(userId,time, likes, service, _user);

            return RedirectToAction("Dashboard", "Users");
        }

        [HttpPost]
        public void GetSession()
        {
            var ses = HttpContext.Session.GetString("Badoo-Session-id");
            var d = 0;
        }

    }
}
