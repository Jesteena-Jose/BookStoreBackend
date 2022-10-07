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

        public User(int userId, string name, string email, string password,string activestatus, int phoneNo)
        {
            UserId = userId;
            Name = name;
            Email = email;
            Password = password;
            ActiveStatus = activestatus;
            PhoneNo = phoneNo;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PhoneNo { get; set; }
        public string ActiveStatus { get; set; }
    }

    public class Login
    {
        public Login(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Status
    {
        public Status(int userId, string activeStatus)
        {
            UserId = userId;
            ActiveStatus = activeStatus;
        }

        public int UserId { get; set; }
        public string ActiveStatus { get; set; }
    }
}