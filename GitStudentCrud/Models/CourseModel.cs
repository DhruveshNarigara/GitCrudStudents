using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GitStudentCrud.Models
{
    public class CourseModel
    {
         [Display(Name = "Course ID")]
        public int c_course_id { get; set; }
        
        [Display(Name = "Course Name")]
        public string c_course_name{ get; set; }
    }
}