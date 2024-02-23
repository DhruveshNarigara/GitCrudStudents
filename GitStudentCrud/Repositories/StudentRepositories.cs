using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitStudentCrud.Models;
using Npgsql;



namespace GitStudentCrud.Repositories
{
    public class StudentRepositories : CommanRepositories , IStudentRepositories
    {
       public void CreateStudent(StudentRegModel studentadd)
       {

       }
    }
}