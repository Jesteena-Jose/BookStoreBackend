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
    public class CartItemController : ApiController
    {
        private ICartItemRepository repository;
        public CartItemController()
        {
            repository = new CartItemSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get(int CartId)
        {
            var data = repository.GetBooksInCart(CartId);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Add(CartItem cartitem)
        {
            var data = repository.AddCartItem(cartitem);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int CartItemId)
        {
            repository.DeleteCartItem(CartItemId);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(int CartItemId, CartItem cartItem)
        {
            repository.UpdateCartItem(CartItemId, cartItem);
            return Ok();
        }
    }
}
