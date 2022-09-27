using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class CartController : ApiController
    {
        private ICartRepository repository;
        public CartController()
        {
            repository = new CartSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get(int UserId)
        {
            var data = repository.GetCart(UserId);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Add(Cart cart)
        {
            var data = repository.AddCart(cart);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int CartId)
        {
            repository.DeleteCart(CartId);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(int CartId, Cart cart)
        {
            repository.UpdateCart(CartId, cart);
            return Ok();
        }
    }
}
