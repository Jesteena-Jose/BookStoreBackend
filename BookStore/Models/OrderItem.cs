using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class OrderItem
    {
        public OrderItem()
        {

        }
        public OrderItem(int orderItemId, int bookId, int orderId)
        {
            OrderItemId = orderItemId;
            BookId = bookId;
            OrderId = orderId;
        }

        public int OrderItemId { get; set; }
        public int BookId { get; set; }
        public int OrderId { get; set; }
    }
}