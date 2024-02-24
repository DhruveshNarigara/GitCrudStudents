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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GitStudentCrud.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepositories _userRepositories;
        private readonly ICourseRepositories _courseRepositories;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IStudentRepositories _studentRepositories;
        

        public UserController(ILogger<UserController> logger, IUserRepositories userRepositories, ICourseRepositories courseRepositories, IWebHostEnvironment webHostEnvironment, IStudentRepositories studentRepositories)
        {
            _logger = logger;
            _userRepositories = userRepositories;
            _courseRepositories = courseRepositories;
            _webHostEnvironment = webHostEnvironment;
            _studentRepositories = studentRepositories;
           
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


        public IActionResult Edit(int id)
        {
            var student = _studentRepositories.GetStudent(id);
            var courses = _courseRepositories.GetAllCourses();
            ViewBag.Languages = new List<string> { "Gujarati", "Marathi", "English" };
            ViewBag.Courses = new SelectList(courses, "c_course_id", "c_course_name", student.c_studcourse_id);
            return View(student);
        }
            public IActionResult Create()
        {
            string email = HttpContext.Session.GetString("email");
            if(email == null){
                return RedirectToAction("Login","User");
            }
            var courses = _courseRepositories.GetAllCourses();
            ViewBag.Languages = new List<string> { "Gujarati", "Marathi", "English" };
            ViewBag.Courses = new SelectList(courses, "c_course_id", "c_course_name");
            return View();
        }
        //   [HttpPost]
        // public IActionResult Create(StudentRegModel student)
        // {
        //     if (student.c_studphotoFile != null)
        //     {
        //         student.c_studphoto = UploadFile(student.c_studphotoFile, "images");
        //     }

        //     if (student.c_studuploaddocFile != null)
        //     {
        //         student.c_studuploaddoc = UploadFile(student.c_studuploaddocFile, "docs");
        //     }

        //     _userRepositories.CreateStudent(student);
        //     return RedirectToAction("Index");
        // }
         private string UploadFile(IFormFile file, string folderName)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, folderName, fileName);
            using (var stream = System.IO.File.Create(filePath))
            {
                file.CopyTo(stream);
            }
            return filePath;
        }

        // public IActionResult GetPhoto(int id)
        // {
        //     var student = _studentRepositories.GetStudent(id);
        //     var photoPath = student.c_studphoto;
        //     var photoBytes = System.IO.File.ReadAllBytes(photoPath);
        //     return File(photoBytes, "image/jpeg");
        // }

        // public IActionResult GetDocument(int id)
        // {
        //     var student = _studentRepositories.GetStudent(id);
        //     var docPath = student.c_studuploaddoc;
        //     var docBytes = System.IO.File.ReadAllBytes(docPath);
        //     return File(docBytes, "application/octet-stream");
        // }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}