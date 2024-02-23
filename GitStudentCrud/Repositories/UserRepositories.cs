using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitStudentCrud.Models;
using GitStudentCrud.Repositories;
using Npgsql;

namespace GitStudentCrud.Repositories
{
    public class UserRepositories : CommanRepositories, IUserRepositories
    {

        public void UserRegister(UserModel Reg)
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand("insert into t_regusers(c_username , c_email , c_password) values (@username,@email,@password);", conn))
            {
                cmd.Parameters.AddWithValue("@username", Reg.c_username);
                cmd.Parameters.AddWithValue("@email", Reg.c_email);
                cmd.Parameters.AddWithValue("@password", Reg.c_password);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public UserModel UserLogin(UserModel Login)
        {
            conn.Open();
            UserModel user = null;
            using (var cmd = new NpgsqlCommand("select c_username,c_password from t_regusers where c_email=@email and c_password=@password;", conn))
            {
                cmd.Parameters.AddWithValue("@email", Login.c_email);
                cmd.Parameters.AddWithValue("@password", Login.c_password);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel();
                        user.c_username = reader.GetString(0);
                        user.c_password = reader.GetString(1);
                    }
                }
            }
            conn.Close();
            return user;
        }
    }
}