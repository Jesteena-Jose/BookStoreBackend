using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    internal interface ICartItemRepository
    {
        List<CartItem> GetCartItems(int CartId);
        CartItem AddCartItem(CartItem cartItem);
        void UpdateCartItem(int CartItemId, CartItem cartItem);
        void DeleteCartItem(int CartItemId);
        List<Book> GetBooksInCart(int CartId);
    }
}
