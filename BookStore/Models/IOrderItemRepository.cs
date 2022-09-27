using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    internal interface IOrderItemRepository
    {
        List<OrderItem> GetOrderItems(int OrderId);
        OrderItem AddOrderItem(OrderItem orderItem);
        void DeleteOrderItem(int OrderItemId);
        void UpdateOrderItem(int OrderItemId,OrderItem orderItem);
    }
}
