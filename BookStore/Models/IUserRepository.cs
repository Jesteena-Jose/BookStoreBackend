using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    internal interface IUserRepository
    {
        List<User> GetUsers();
        User LogIn(string Email, string Password);
        User AddUser(User user);
        void DeleteUser(int UserId);
        void UpdateUser(int UserId, User user);
    }
}
