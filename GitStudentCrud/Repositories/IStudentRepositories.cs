using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitStudentCrud.Models;

namespace GitStudentCrud.Repositories
{
    public interface IStudentRepositories
    {
         void CreateStudent(StudentRegModel studentadd);
         IEnumerable<StudentRegModel> GetAllStudents();
          StudentRegModel GetStudent(int id);
          void DeleteStudent(int id);



    }
}