using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMatcherProject.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }
        [Authorize]
        public IActionResult Statistics()
        {
            return View();
        }
        [Authorize]
        public IActionResult CheckOut()
        {
            return View();
        }
        [Authorize]
        public IActionResult Instagram()
        {
            return View();
        }
    }
}
