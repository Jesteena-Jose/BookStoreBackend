using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models
{
    public class UserSqlImpl : IUserRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public UserSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString);
            comm = new SqlCommand();
        }

        public User AddUser(User user)
        {
            comm.CommandText = "insert into [User] Values('"+user.Name+"','"+user.Email+"','"+user.Password+"','"+user.PhoneNo+"')";
            comm.Connection = conn;
            conn.Open();
            try
            {
                int row = comm.ExecuteNonQuery();
                if (row > 0)
                {
                    return user;
                }
                return null;
            }
            catch(Exception e)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteUser(int UserId)
        {
            comm.CommandText = "Delete from [User] where UserId=" + UserId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            comm.CommandText = "select * from [User]";
            conn.Open();
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {  
                int UserId = Convert.ToInt32(reader["UserId"]);
                string Name = reader["Name"].ToString();
                string Email = reader["Email"].ToString();
                string Password = reader["Password"].ToString();
                int PhoneNo = Convert.ToInt32(reader["PhoneNo"]);
                users.Add(new User(UserId,Name,Email,Password,PhoneNo));

            }
            conn.Close();
            return users;
        }

        public User LogIn(string GEmail, string GPassword)
        {
            User user;
            comm.CommandText = "select * from [User] where Email='"+GEmail+"' and Password='"+GPassword+"'";
            conn.Open();
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int UserId = Convert.ToInt32(reader["UserId"]);
                string Name = reader["Name"].ToString();
                string Email = reader["Email"].ToString();
                string Password = reader["Password"].ToString();
                int PhoneNo = Convert.ToInt32(reader["PhoneNo"]);
                user=new User(UserId, Name, Email, Password, PhoneNo);
                return user;
            }
            conn.Close();
            return null;
        }

        public void UpdateUser(int UserId, User user)
        {
            comm.CommandText = "Update [User] set Name='"+user.Name+"',Email='"+user.Email+"',Password='"+user.Password+"',PhoneNo="+user.PhoneNo+" where UserId=" + UserId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}