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
    public class LoginController : ApiController
    {
        
        private IUserRepository repository;
        public LoginController()
        {
            repository = new UserSqlImpl();
        }
        [HttpPost]
        public IHttpActionResult Post(Login login)
        {
            var data = repository.LogIn(login.Email, login.Password);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
