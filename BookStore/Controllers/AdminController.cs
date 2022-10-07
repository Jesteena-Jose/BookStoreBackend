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
    public class AdminController : ApiController
    {
        private IAdminRepository repository;
        public AdminController()
        {
            repository = new AdminSqlImpl();
        }
        [HttpPost]
        public IHttpActionResult Post(AdminLogin login)
        {
            var data = repository.GetAdmin(login.Username, login.Password);
            return Ok(data);
        }
    }
}
