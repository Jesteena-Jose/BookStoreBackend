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
    public class StatusChangeController : ApiController
    {
        private IUserRepository repository;
        public StatusChangeController()
        {
            repository = new UserSqlImpl();
        }
        [HttpPost]
        public IHttpActionResult Post(Status status)
        {
            var data = repository.UpdateStatus(status.UserId, status.ActiveStatus);
            return Ok(data);
        }
    }
}
