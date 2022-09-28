using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class CartItem
    {
        public CartItem() { }
        public CartItem(int cartItemId, int bookId, int cartId)
        {
            CartItemId = cartItemId;
            BookId = bookId;
            CartId = cartId;
        }

        public int CartItemId { get; set; }
        public int BookId { get; set; }
        public int CartId { get; set; }
    }
    public class CartBooks
    {
        public CartBooks(CartItem cartItem, Book book)
        {
            this.cartItem = cartItem;
            this.book = book;
        }

        public CartItem cartItem { get; set; }
        public Book book { get; set; }
    }
}