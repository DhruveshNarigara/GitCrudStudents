using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitStudentCrud.Models;
using Npgsql;



namespace GitStudentCrud.Repositories
{
    public class StudentRepositories : CommanRepositories, IStudentRepositories
    {
       private readonly IConfiguration _configuration;

        public StudentRepositories(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       
        public void CreateStudent(StudentRegModel studentadd)
        {

        }
        public IEnumerable<StudentRegModel> GetAllStudents()
        {
            var students = new List<StudentRegModel>();
            // Provide the connection string here

            conn.Open();
            using (var cmd = new NpgsqlCommand("SELECT c_studid,c_studname,c_studdob,c_studemail,c_studpassword,c_studgender,c_studmobile,c_studaddress,c_studcourse_id,c_studlanguages,c_studphoto,c_studuploaddoc FROM t_student", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var student = new StudentRegModel
                        {
                            c_studid = Convert.ToInt32(reader["c_studid"]),
                            c_studname = reader["c_studname"].ToString(),
                            c_studdob = Convert.ToDateTime(reader["c_studdob"])!,
                            c_studemail = reader["c_studemail"].ToString(),
                            c_studpassword = reader["c_studpassword"].ToString(),
                            c_studgender = reader["c_studgender"].ToString(),
                            c_studmobile = reader["c_studmobile"].ToString(),
                            c_studaddress = reader["c_studaddress"].ToString(),
                            c_studcourse_id = Convert.ToInt32(reader["c_studcourse_id"]),
                            c_studlanguages = reader["c_studlanguages"].ToString().Split(","),
                            c_studphoto = reader["c_studphoto"].ToString(),
                            c_studuploaddoc = reader["c_studuploaddoc"].ToString()
                        };
                        students.Add(student);
                    }
                }

                conn.Close();
            }
            return students;
        }

        public StudentRegModel GetStudent(int id)
        {
            var student = new StudentRegModel();
            //using (var conn = new NpgsqlConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM t_student WHERE c_studid = @id",conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            student.c_studid = Convert.ToInt32(reader["c_studid"]);
                            student.c_studname = reader["c_studname"].ToString();
                            student.c_studdob = Convert.ToDateTime(reader["c_studdob"]);
                            student.c_studemail = reader["c_studemail"].ToString();
                            student.c_studpassword = reader["c_studpassword"].ToString();
                            student.c_studgender = reader["c_studgender"].ToString();
                            student.c_studmobile = reader["c_studmobile"].ToString();
                            student.c_studaddress = reader["c_studaddress"].ToString();
                            student.c_studcourse_id = Convert.ToInt32(reader["c_studcourse_id"]);
                            student.c_studlanguages = reader["c_studlanguages"].ToString().Split(",");
                            student.c_studphoto = reader["c_studphoto"].ToString();
                            student.c_studuploaddoc = reader["c_studuploaddoc"].ToString();
                        }
                    }
                }
            }
            return student;
        }
        public void DeleteStudent(int id)
        {
           // using (var conn = new NpgsqlConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM t_student WHERE c_studid = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}