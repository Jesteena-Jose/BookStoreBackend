using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository repository;
        public UserController()
        {
            repository = new UserSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetUsers();
            return Ok(data);
        }
        [HttpGet]
        public IHttpActionResult Get(string Email,string Password)
        {
            var data = repository.LogIn(Email, Password);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Add(User user)
        {
            var data = repository.AddUser(user);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int UserId)
        {
            repository.DeleteUser(UserId);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(int UserId, User user)
        {
            repository.UpdateUser(UserId, user);
            return Ok();
        }
    }
}
