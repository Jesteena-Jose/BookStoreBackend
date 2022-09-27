using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class OrderItemController : ApiController
    {
        private IOrderItemRepository repository;
        public OrderItemController()
        {
            repository = new OrderItemSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get(int OrderId)
        {
            var data = repository.GetOrderItems(OrderId);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Add(OrderItem orderItem)
        {
            var data = repository.AddOrderItem(orderItem);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int OrderItemId)
        {
            repository.DeleteOrderItem(OrderItemId);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(int OrderItemId, OrderItem orderItem)
        {
            repository.UpdateOrderItem(OrderItemId, orderItem);
            return Ok();
        }
    }
}
