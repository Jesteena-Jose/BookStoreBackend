using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class User
    {
        public User()
        {
        }

        public User(int userId, string name, string email, string password, int phoneNo)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Password = password;
            PhoneNo = phoneNo;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PhoneNo { get; set; }
    }
}