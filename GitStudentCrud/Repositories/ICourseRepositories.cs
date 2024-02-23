using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitStudentCrud.Models;

namespace GitStudentCrud.Repositories
{
    public interface ICourseRepositories
    {
        IEnumerable<CourseModel> GetAllCourses();
    }
}