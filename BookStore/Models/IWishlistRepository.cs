using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    internal interface IWishlistRepository
    {
        List<Wishlist> GetWishlists(int UserId);
        Wishlist AddWishlist(Wishlist wishlist);
        void DeleteWishlist(int WishlistId);
        void UpdateWishlist(int WishlistId, Wishlist wishlist);
    }
}
