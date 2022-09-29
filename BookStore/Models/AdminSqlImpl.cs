using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace BookStore.Models
{
    public class AdminSqlImpl : IAdminRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public AdminSqlImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myDB"].ConnectionString);
            comm = new SqlCommand();
        }
        public Admin GetAdmin(string GUsername, string GPassword)
        {
            Admin admin;
            comm.CommandText = "select * from Admin where Username='" + GUsername + "' and Password='" + GPassword + "'";
            conn.Open();
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int AdminId = Convert.ToInt32(reader["AdminId"]);
                string Username = reader["Username"].ToString();
                string Password = reader["Password"].ToString();
                admin = new Admin(AdminId, Username, Password);
                return admin;
            }
            conn.Close();
            return null;
        }
    }
}