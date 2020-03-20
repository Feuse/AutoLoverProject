using AutoMatcherProject.ViewModels;
using Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMatcherProject.Controllers
{

    [Authorize]
    public class ActionsController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private ISche _schedulrAbstraction;
        private IBotFactory _factory;
        private ICredentialSaver _saver;
        private IBot _bot;
        private string _username;
        private string _password;


        public ActionsController(UserManager<ApplicationUser> userManager, ISche schedulrAbstraction, IBotFactory factory, ICredentialSaver saver)
        {
            _userManager = userManager;
            _schedulrAbstraction = schedulrAbstraction;
            _factory = factory;
            _saver = saver;
        }

        [HttpPost]
        public async Task<IActionResult> ValidateUser(Service service, string username, string password)
        {
            //check if user exists and if the password is correct, if not validate and save
            var user = _saver.Get(username, password);
            if (user != null)
            {
                return RedirectToAction("Dashboard", "Users");
            }
            else
            {
                _bot = _factory.GetBot(service);
                var result = _bot.Login(username, password);
                if (result == "")
                {
                    var id = _userManager.GetUserId(HttpContext.User);
                    UsersCredentialsModel model = new UsersCredentialsModel() { Id = id, Service = service, Password = password, Username = username };
                    _saver.Save(model);
                    _bot.ShutDown();
                }
                else
                {
                    return Unauthorized();
                }
            }
            return RedirectToAction("Dashboard", "Users");
        }
        [HttpPost]
        public async Task<IActionResult> ChangeDescription(Service service, string username, string password)
        {
            _bot.Login(username, password);
            //description object?
            _bot.ChangeDescription();

            //1. check if user log in credentials is working,
            //2. get user credentials, and execute description changing bot.

            return RedirectToAction("Dashboard", "Users");
        }
        [HttpPost]
        public async Task<IActionResult> Schedule(int messageId, DateTime time, int likes, Service service, ApplicationUser user)
        {
            var _user = _userManager.GetUserAsync(HttpContext.User).Result;
            await _schedulrAbstraction.Schedule(messageId, time, likes, service, _user);

            return RedirectToAction("Dashboard", "Users");
        }

    }
}
