using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Cart
    {
        public Cart()
        {

        }

        public Cart(int cartId, DateTime createdAt, int totalPrice, int addressId, int userId)
        {
            CartId = cartId;
            CreatedAt = createdAt;
            TotalPrice = totalPrice;
            AddressId = addressId;
            UserId = userId;
        }

        public int CartId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TotalPrice { get; set; }
        public int AddressId { get; set; }
        public int UserId { get; set; }

    }
}