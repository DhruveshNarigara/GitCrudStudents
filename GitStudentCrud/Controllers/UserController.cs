using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GitStudentCrud.Models;
using GitStudentCrud.Repositories;
using Npgsql;

namespace GitStudentCrud.Controllers
{
    //[Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private readonly IUserRepositories _userRepositories;

        public UserController(ILogger<UserController> logger , IUserRepositories userRepositories)
        {
            _logger = logger;
            _userRepositories = userRepositories;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        // [HttpPost]
        // public IActionResult Register(UserModel register)
        // {
        //     _userRepositories.UserRegister(register);
        //     return RedirectToAction("Login");
        // }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}