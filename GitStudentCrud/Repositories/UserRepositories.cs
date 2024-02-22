using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitStudentCrud.Models;
using GitStudentCrud.Repositories;
using Npgsql;

namespace GitStudentCrud.Repositories
{
    public class UserRepositories : CommanRepositories , IUserRepositories
    {

        public void UserRegister()
        {
            conn.Open();
            using(var cmd = new NpgsqlCommand("Insert into t_regusers(c_username,c_email,c_password) values (@c_username,@c_email,@c_password)",conn))
            {
                cmd.Parameters.AddWithValue("@c_username");
                cmd.Parameters.AddWithValue("@c_email");
                cmd.Parameters.AddWithValue("@c_password");
            }
        }

        public void UserLogin()
        {

        }
    }
}