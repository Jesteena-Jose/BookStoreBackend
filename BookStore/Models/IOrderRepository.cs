using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    internal interface IOrderRepository
    {
        List<Order> GetOrders(int UserId);
        decimal AddOrder(Order order);
        void DeleteOrder(int OrderId);
        void UpdateOrder(int OrderId, Order order);
    }
}
