using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BookStore.Models;

namespace BookStore.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
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
            var data = repository.GetOrderBooksById(OrderId);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetByUser(int UserId)
        {
            var data = repository.GetAllOrderBooks(UserId);
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetBooks()
        {
            var data = repository.GetOrderBooks();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult GetNew(int UserId,int status)
        {
            var data = repository.GetNewOrderBooks(UserId, status);
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
