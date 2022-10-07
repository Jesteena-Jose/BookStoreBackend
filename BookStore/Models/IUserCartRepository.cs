using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    internal interface IUserCartRepository
    {
        List<UserCartBook> GetusercartBooks(int UserId);
        UserCart AddUserCart(UserCart userCart);
        void DeleteUserCart(int UserCartId);
        void UpdateUserCart(int UserCartId, UserCart userCart);
    }
}
