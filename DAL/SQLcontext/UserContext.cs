using DAL.DBconnection;
using DAL.Interface;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.SQLcontext
{
    public class UserContext : iUser
    {
        private readonly DB Data = new DB();

        public bool AdminCheck(UserDTO user)
        {
            bool isAdmin = false;

            using (SqlConnection conn = new SqlConnection(Data.con.ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("AdminCheck", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@UserID", user.UserID));

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        isAdmin = (bool)reader["Admin"];
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return isAdmin;
        }

        public UserDTO GetUserInfo(string id)
        {
            var user = new UserDTO();

            using (SqlConnection conn = new SqlConnection(Data.con.ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("GetUserInfo", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@UserID", id));

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        user.Username = reader["Username"].ToString();
                        user.Firstname = reader["Firstname"].ToString();
                        user.Lastname = reader["Lastname"].ToString();
                        user.Address = reader["Address"].ToString();
                        user.Zipcode = reader["Zipcode"].ToString();
                        user.Place = reader["Place"].ToString();
                        user.Phone = reader["Phone"].ToString();
                        user.Email = reader["Email"].ToString();
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return user;
        }

        public UserDTO Login(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(Data.connection))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("Login", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Username", user.Username));

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        user.UserID = reader["ID"].ToString();
                        user.Username = reader["Username"].ToString();
                        user.Password = reader["Password"].ToString();
                        user.Salt = reader["Salt"].ToString();
                    }
                    reader.Close();
                }
                finally
                {
                    conn.Close();
                }
            }
            return user;
        }

        public bool Registration(UserDTO user)
        {
            bool RegistrationSuccess = false;
            using (SqlConnection conn = new SqlConnection(Data.con.ConnectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("SignUp", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Username", user.Username));
                    command.Parameters.Add(new SqlParameter("@Password", user.Password));
                    command.Parameters.Add(new SqlParameter("@Firstname", user.Firstname));
                    command.Parameters.Add(new SqlParameter("@Lastname", user.Lastname));
                    command.Parameters.Add(new SqlParameter("@Address", user.Address));
                    command.Parameters.Add(new SqlParameter("@Zipcode", user.Zipcode));
                    command.Parameters.Add(new SqlParameter("@Place", user.Place));
                    command.Parameters.Add(new SqlParameter("@Phone", user.Phone));
                    command.Parameters.Add(new SqlParameter("@Email", user.Email));
                    command.Parameters.Add(new SqlParameter("@Salt", user.Salt));
                    command.Parameters.Add(new SqlParameter("@Admin", user.Admin));

                    command.ExecuteReader();
                    RegistrationSuccess = true;
                }
                catch (Exception e)
                {
                    var a = e;
                    RegistrationSuccess = false;
                }
                finally
                {
                    conn.Close();
                }
            }
            return RegistrationSuccess;
        }
    }
}
