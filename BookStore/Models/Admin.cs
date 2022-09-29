using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Admin
    {
        public Admin(int adminId, string username, string password)
        {
            AdminId = adminId;
            Username = username;
            Password = password;
        }

        public int AdminId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}