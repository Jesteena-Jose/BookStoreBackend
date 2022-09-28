using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Wishlist
    {
        public Wishlist()
        {
        }

        public Wishlist(int wishlistId, int bookId, int userId)
        {
            WishlistId = wishlistId;
            BookId = bookId;
            UserId = userId;
        }

        public int WishlistId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
    public class WishlistBook
    {
        public WishlistBook(Wishlist wishlist, Book book)
        {
            this.wishlist = wishlist;
            this.book = book;
        }

        public Wishlist wishlist { get; set; }
        public Book book { get; set; }
    }
}