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
    public class OrderController : ApiController
    {
        private IOrderRepository repository;
        public OrderController()
        {
            repository = new OrderSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get(int UserId)
        {
            var data = repository.GetOrders(UserId);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Add(Order order)
        {
            var data = repository.AddOrder(order);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int OrderId)
        {
            repository.DeleteOrder(OrderId);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(int OrderId, Order order)
        {
            repository.UpdateOrder(OrderId, order);
            return Ok();
        }
    }
}
