using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class ShippingAddressController : ApiController
    {
        private IShippingAddressRepository repository;
        public ShippingAddressController()
        {
            repository = new ShippingAddressSqlImpl();
        }
        [HttpGet]
        public IHttpActionResult Get(int UserId)
        {
            var data = repository.GetShippingAddresses(UserId);
            return Ok(data);
        }
        [HttpPost]
        public IHttpActionResult Add(ShippingAddress address)
        {
            var data = repository.AddAddress(address);
            return Ok(data);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int AddressId)
        {
            repository.DeleteAddress(AddressId);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult Update(int AddressId, ShippingAddress address)
        {
            repository.UpdateAddress(AddressId,address);
            return Ok();
        }
    }
}
