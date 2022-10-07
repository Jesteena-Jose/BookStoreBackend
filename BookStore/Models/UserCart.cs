using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class UserCart
    {
        public UserCart(int userCartId, int bookId, int userId)
        {
            UserCartId = userCartId;
            BookId = bookId;
            UserId = userId;
        }

        public int UserCartId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
    public class UserCartBook
    {
        public UserCartBook(UserCart userCart, Book book)
        {
            this.UserCart = userCart;
            this.book = book;
        }

        public UserCart UserCart { get; set; }
        public Book book { get; set; }
    }
}