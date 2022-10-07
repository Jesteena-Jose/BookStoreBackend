using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BookStore.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UserCartController : ApiController
    {
        private IUserCartRepository repository;
        public UserCartController()
        {
            repository = new UserCartSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get(int UserId)
        {
            var data = repository.GetusercartBooks(UserId);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Add(UserCart userCart)
        {
            var data = repository.AddUserCart(userCart);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int UserCartId)
        {
            repository.DeleteUserCart(UserCartId);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(int UserCartId, UserCart userCart)
        {
            repository.UpdateUserCart(UserCartId, userCart);
            return Ok();
        }
    }
}
