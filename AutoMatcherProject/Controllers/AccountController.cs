
using AutoMatcherProject.ViewModels;
using Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Utils;

namespace AutoMatcherProject.Controllers
{
    public class AccountController : Controller
    {
        private ILogger<AccountController> _logger;
        private SignInManager<ApplicationUser> _signInManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly ICredentialDb CredentialDB;
        const string LoginViewName = "Login";


        public AccountController(ILogger<AccountController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, ICredentialDb credentialDB)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            CredentialDB = credentialDB;
        }
        [HttpGet]

        public async Task<IActionResult> Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            return View(model);
        }
        [HttpGet]

        public IActionResult LoginToTinder()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Country = model.Country };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    var founduser = _userManager.Users.Where(i => i.UserName == model.Email).FirstOrDefault();
                    var theId = founduser.Id;
                    CredentialDB.Save(new UsersCredentialsModel { Hash = null, Password = model.Password, Services = null, UserId = theId, Username = model.Email });
                    return RedirectToAction("Dashboard", "Users");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl)
        {
            var temp = model;
            model = new LoginViewModel
            {
                Email = temp.Email,
                Password = temp.Password,
                ReturnUrl = ReturnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {



                    return RedirectToAction("Dashboard", "Users");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }
        [HttpPost]

        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var rediectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, rediectUrl);
            var s = new ChallengeResult(provider, properties);
            return s;
        }
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl, string remoteError = null)
        {
            returnUrl ??= Url.Content("/Dashboard");

            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()

            };
            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Error from external provider:{remoteError}");
                return View(LoginViewName, model);
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Error loading external login information");
                return View(LoginViewName, model);
            }
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            if (signInResult.Succeeded)
            {

                return RedirectToAction("Dashboard", "Users");
            }
            else
            {
                return await SomeInternalLogic(returnUrl, model, info);
            }
        }
        [AllowAnonymous]
        private async Task<IActionResult> SomeInternalLogic(string returnUrl, LoginViewModel model, ExternalLoginInfo info)
        {
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            if (email != null)

            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                        Email = info.Principal.FindFirstValue(ClaimTypes.Email),
                        Country = "Israel"
                        

                    };
                    var s = info.Principal.FindFirstValue(ClaimTypes.Country);
                    await _userManager.CreateAsync(user);
                    var founduser = _userManager.Users.Where(i => i.UserName == email).FirstOrDefault();
                    var theId = founduser.Id;
                    CredentialDB.Save(new UsersCredentialsModel { Hash = null, Password = model.Password, Services = null, UserId = theId, Username = model.Email });
                }
                await _userManager.AddLoginAsync(user, info);
                await _signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Dashboard", "Users");
            }
            else
            {
                return View(LoginViewName, model);
            }
        }
    }
}
