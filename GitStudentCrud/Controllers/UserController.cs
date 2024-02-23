using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using GitStudentCrud.Repositories;
using GitStudentCrud.Models;

namespace GitStudentCrud.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepositories _userRepositories;
        

        public UserController(ILogger<UserController> logger, IUserRepositories userRepositories)
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

        [HttpPost]
        public IActionResult Register(UserModel Reg)
        {
            _userRepositories.UserRegister(Reg);
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel Reg)
        {
            var user = _userRepositories.UserLogin(Reg);
            if (user != null)
            {
                HttpContext.Session.SetString("username", user.c_username);
                return RedirectToAction("Index","Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Edit()
        {
            return View();
        }
            public IActionResult Create()
        {
            string email = HttpContext.Session.GetString("email");
            if(email == null){
                return RedirectToAction("Login","User");
            }
            var courses = _courseHelper.GetAllCourses();
            ViewBag.Languages = new List<string> { "Gujarati", "Marathi", "English" };
            ViewBag.Courses = new SelectList(courses, "c_course_id", "c_course_name");
            return View();
        }
          [HttpPost]
        public IActionResult Create(StudentRegModal student)
        {
            if (student.c_studphotoFile != null)
            {
                student.c_studphoto = UploadFile(student.c_studphotoFile, "images");
            }

            if (student.c_studuploaddocFile != null)
            {
                student.c_studuploaddoc = UploadFile(student.c_studuploaddocFile, "docs");
            }

            _studentHelper.CreateStudent(student);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}