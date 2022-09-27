using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    internal interface ICartRepository
    {
        Cart GetCart(int UserId);
        Cart AddCart(Cart cart);
        void UpdateCart(int CartId, Cart cart);
        void DeleteCart(int CartId);
    }
}
