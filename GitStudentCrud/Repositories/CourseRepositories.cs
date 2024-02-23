using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitStudentCrud.Models;
using Npgsql;

namespace GitStudentCrud.Repositories
{
    public class CourseRepositories:CommanRepositories,ICourseRepositories
    {
        public IEnumerable<CourseModel> GetAllCourses()
        {
            var courses = new List<CourseModel>();
            try
            {
                conn.Open();  // Open the connection using the inherited 'conn' field
                using (var cmd = new NpgsqlCommand("SELECT * FROM t_studcourse", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var course = new CourseModel
                            {
                                c_course_id = Convert.ToInt32(reader["c_course_id"]),
                                c_course_name = reader["c_course_name"].ToString(),
                            };
                            courses.Add(course);
                        }
                    }
                }
            }
            finally
            {
                conn.Close();  // Always close the connection, even if an exception occurs
            }
            return courses;
        }
    }
}