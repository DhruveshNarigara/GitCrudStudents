using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GitStudentAPIcrud.Controllers
{
    [Route("[controller]")]
    public class StudentAPIController : Controller
    {
        private readonly ILogger<StudentAPIController> _logger;

        public StudentAPIController(ILogger<StudentAPIController> logger)
        {
            _logger = logger;   
        }

        public IActionResult Index()
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