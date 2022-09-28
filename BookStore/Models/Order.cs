using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Order
    {
        public Order() { }
        public Order(int orderId, DateTime orderDate, int totalPrice, string status, DateTime deliveryDate, int addressId, int userId)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            TotalPrice = totalPrice;
            OrderStatus = status;
            DeliveryDate = deliveryDate;
            AddressId = addressId;
            UserId = userId;
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int AddressId { get; set; }
        public int UserId { get; set; }
    }
}