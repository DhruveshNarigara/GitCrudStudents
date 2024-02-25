using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GitStudentCrud.Repositories;
using GitStudentCrud.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GitStudentCrud.Controllers
{
    // [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;

        private readonly IStudentRepositories _studentRepositories;

        private readonly IUserRepositories _userRepositories;

        private readonly ICourseRepositories _courseRepositories;
        public StudentController(ILogger<StudentController> logger, IUserRepositories userRepositories, IStudentRepositories studentRepositories, ICourseRepositories courseRepositories)
        {
            _logger = logger;
            _userRepositories = userRepositories;
            _studentRepositories = studentRepositories;
            _courseRepositories = courseRepositories;
        }

        public IActionResult Index()
        {
            return View();
        }




        //  public IActionResult Edit(int id)
        // {
        //     var student = _studentRepositories.GetStudent(id);
        //     var courses = _courseRepositories.GetAllCourses();
        //     ViewBag.Languages = new List<string> { "Gujarati", "Marathi", "English" };
        //     ViewBag.Courses = new SelectList(courses, "c_course_id", "c_course_name", student.c_studcourse_id);
        //     return View(student);
        // }
        // public IActionResult Edit(int id)
        // {
        //     var student = _studentRepositories.GetStudent(id);
        //     var courses = _courseRepositories.GetAllCourses();
        //     ViewBag.Languages = new List<string> { "Gujarati", "Marathi", "English" };
        //     ViewBag.Courses = new SelectList(courses, "c_course_id", "c_course_name", student.c_studcourse_id);
        //     return View();
        // }


        public IActionResult Create()
        {
            var courses = _courseRepositories.GetAllCourses();
            ViewBag.Courses = new SelectList(courses, "c_course_id", "c_course_name");
            return View();
        }
        [HttpGet]
        [ActionName("Index")]
        public IActionResult Index1()
        {
            var students = _studentRepositories.GetAllStudents();
            return View(students);
        }
        public IActionResult Edit(int id)
        {
            var student = _studentRepositories.GetStudent(id);
            var courses = _courseRepositories.GetAllCourses();
            ViewBag.Languages = new List<string> { "Gujarati", "Marathi", "English" };
            ViewBag.Courses = new SelectList(courses, "c_course_id", "c_course_name", student.c_studcourse_id);
            return View(student);
        }

        // [HttpPost]
        // public IActionResult Edit(StudentRegModel student)
        // {
        //     if (student.c_studphotoFile != null)
        //     {
        //         student.c_studphoto = UploadFile(student.c_studphotoFile, "images");
        //     }

        //     if (student.c_studuploaddocFile != null)
        //     {
        //         student.c_studuploaddoc = UploadFile(student.c_studuploaddocFile, "docs");
        //     }

        //     _studentRepositories.UpdateStudent(student);
        //     return RedirectToAction("Index");
        // }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _studentRepositories.GetStudent(id);
            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _studentRepositories.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            return View(_studentRepositories.GetStudent(id));
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}