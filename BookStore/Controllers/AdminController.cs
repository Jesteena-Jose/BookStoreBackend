using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class AdminController : ApiController
    {
        private IAdminRepository repository;
        public AdminController()
        {
            repository = new AdminSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get(string Username, string Password)
        {
            var data = repository.GetAdmin(Username, Password);
            return Ok(data);
        }
    }
}
