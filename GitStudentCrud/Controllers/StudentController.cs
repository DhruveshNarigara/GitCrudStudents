using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GitStudentCrud.Repositories;
using GitStudentCrud.Models;

namespace GitStudentCrud.Controllers
{
   // [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;

        private readonly IStudentRepositories _studentRepositories;

        private readonly IUserRepositories _userRepositories;

        public StudentController(ILogger<StudentController> logger , IUserRepositories userRepositories , IStudentRepositories studentRepositories)
        {
            _logger = logger;
            _userRepositories = userRepositories; 
            _studentRepositories = studentRepositories;
        }

        public IActionResult Index()
        {
            return View();
        }

       

        
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Create()
        {
            // var courses = .GetAllCourses();
            // ViewBag.Languages = new List<string> { "Gujarati", "Marathi", "English" };
            // ViewBag.Courses = new SelectList(courses, "c_course_id", "c_course_name");
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}